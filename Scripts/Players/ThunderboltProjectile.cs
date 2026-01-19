using Godot;

/// <summary>
/// Thunderbolt - Zeus's starting weapon
/// Fires at the nearest enemy
/// Damage: 25, Speed: 20, Pierce: 3 enemies
/// Fire rate: 0.8 attacks/second
/// Cooldown: 1.25s, Range: 15 units
/// </summary>
public partial class ThunderboltProjectile : Area3D
{
    [Export]
    public uint Damage { get; set; } = 25;
    
    [Export]
    public float Speed { get; set; } = 20.0f;
    
    [Export]
    public int PierceCount { get; set; } = 3;
    
    [Export]
    public float Lifetime { get; set; } = 2.0f; // Time before auto-destroy
    
    private int _currentPierce = 0;
    private float _timeAlive = 0.0f;
    private Vector3 _velocity;
    private GameManager _gameManager;

    public override void _Ready()
    {
        base._Ready();
        
        _gameManager = GetNode<GameManager>("/root/GameManager");
        
        // Setup collision
        AreaEntered += OnAreaEntered;
        BodyEntered += OnBodyEntered;
        
        // Add collision shape if not present
        if (FindChild("CollisionShape3D") == null)
        {
            var collisionShape = new CollisionShape3D();
            var shape = new SphereShape3D();
            shape.Radius = 0.2f;
            collisionShape.Shape = shape;
            collisionShape.Name = "CollisionShape3D";
            AddChild(collisionShape);
        }
        
        // Add visual mesh if not present
        if (FindChild("MeshInstance3D") == null)
        {
            var mesh = new MeshInstance3D();
            mesh.Mesh = new SphereMesh();
            ((SphereMesh)mesh.Mesh).Radius = 0.15f;
            ((SphereMesh)mesh.Mesh).Height = 0.15f;
            mesh.Name = "MeshInstance3D";
            AddChild(mesh);
        }
    }

    public void Initialize(Vector3 direction)
    {
        _velocity = direction.Normalized() * Speed;
        LookAt(Position + _velocity, Vector3.Up);
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        
        _timeAlive += (float)delta;
        
        // Destroy after lifetime expires
        if (_timeAlive >= Lifetime)
        {
            QueueFree();
            return;
        }
        
        // Move projectile
        Position += _velocity * (float)delta;
    }

    private void OnAreaEntered(Area3D area)
    {
        if (area is Enemy enemy)
        {
            HitEnemy(enemy);
        }
    }

    private void OnBodyEntered(Node3D body)
    {
        if (body is Enemy enemy)
        {
            HitEnemy(enemy);
        }
    }

    private void HitEnemy(Enemy enemy)
    {
        // Deal damage
        enemy.TakeDamages(Damage);
        
        // Inform game manager of hit
        _gameManager?.EnemyHit(enemy, (int)Damage);
        
        // Check pierce count
        _currentPierce++;
        if (_currentPierce >= PierceCount)
        {
            QueueFree();
        }
    }
}