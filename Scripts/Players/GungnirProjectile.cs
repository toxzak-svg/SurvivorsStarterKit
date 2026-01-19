using Godot;
using System.Collections.Generic;

public partial class GungnirProjectile : Area3D
{
    private enum State { Outbound, Returning }

    [Export]
    public uint Damage { get; set; } = 30;

    [Export]
    public float OutSpeed { get; set; } = 18.0f;

    [Export]
    public float ReturnSpeed { get; set; } = 12.0f;

    [Export]
    public int MaxPierceOutbound { get; set; } = 2;

    [Export]
    public float MaxRange { get; set; } = 12.0f;

    private State _currentState = State.Outbound;
    private Vector3 _startPosition;
    private Vector3 _direction;
    private Player _owner;
    private int _currentPierceCount;
    private float _traveledDistance = 0f;
    
    private GameManager _gameManager;
    private List<long> _hitEnemyIds = new();

    public override void _Ready()
    {
        base._Ready();
        _gameManager = GetNode<GameManager>("/root/GameManager");

        // Setup collision
        BodyEntered += OnBodyEntered;
        AreaEntered += OnAreaEntered;

        _currentPierceCount = MaxPierceOutbound;
        _startPosition = GlobalPosition;

        // Auto-Setup for testing
        if (FindChild("CollisionShape3D") == null)
        {
            var collisionShape = new CollisionShape3D();
            var shape = new SphereShape3D { Radius = 0.3f }; // Slightly larger hit area
            collisionShape.Shape = shape;
            collisionShape.Name = "CollisionShape3D";
            AddChild(collisionShape);
        }

        if (FindChild("MeshInstance3D") == null)
        {
            var meshInstance = new MeshInstance3D();
            // Spear look: Cylinder
            var mesh = new CylinderMesh();
            mesh.TopRadius = 0.05f;
            mesh.BottomRadius = 0.05f;
            mesh.Height = 1.0f;
            meshInstance.Mesh = mesh;
            meshInstance.RotateX(Mathf.DegToRad(90)); // Point forward
            meshInstance.Name = "MeshInstance3D";
            AddChild(meshInstance);
        }
    }

    public void Initialize(Vector3 direction, Player owner)
    {
        _direction = direction.Normalized();
        _owner = owner;
        LookAt(GlobalPosition + _direction, Vector3.Up);
    }

    public override void _Process(double delta)
    {
        if (_currentState == State.Outbound)
        {
            float step = OutSpeed * (float)delta;
            GlobalPosition += _direction * step;
            _traveledDistance += step;

            if (_traveledDistance >= MaxRange)
            {
                SwitchToReturn();
            }
        }
        else // Returning
        {
            if (!IsInstanceValid(_owner))
            {
                QueueFree();
                return;
            }

            Vector3 toOwner = (_owner.GlobalPosition - GlobalPosition);
            float distToOwner = toOwner.Length();
            
            if (distToOwner < 1.0f)
            {
                QueueFree(); // Caught by player
                return;
            }

            _direction = toOwner.Normalized();
            GlobalPosition += _direction * ReturnSpeed * (float)delta;
            // Optional: Rotate to look at player?
            // LookAt(_owner.GlobalPosition, Vector3.Up); 
        }
    }

    private void SwitchToReturn()
    {
        if (_currentState == State.Returning) return;
        _currentState = State.Returning;
        _hitEnemyIds.Clear(); // Allow hitting enemies again on the way back
    }

    private void OnBodyEntered(Node3D body)
    {
        if (body is Enemy enemy)
        {
            HandleEnemyHit(enemy);
        }
    }

    private void OnAreaEntered(Area3D area)
    {
        if (area is Enemy enemy)
        {
            HandleEnemyHit(enemy);
        }
    }

    private void HandleEnemyHit(Enemy enemy)
    {
        long enemyId = (long)enemy.GetInstanceId();
        if (_hitEnemyIds.Contains(enemyId)) return;

        _hitEnemyIds.Add(enemyId);
        
        // Deal Damage
        enemy.TakeDamages(Damage);
        _gameManager?.EnemyHit(enemy, (int)Damage);

        if (_currentState == State.Outbound)
        {
            _currentPierceCount--;
            if (_currentPierceCount <= 0)
            {
                SwitchToReturn();
            }
        }
        // Returning mode has infinite pierce
    }
}
