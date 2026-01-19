using Godot;
using System;

/// <summary>
/// Zeus - The Thunder King
/// Archetype: High Burst Damage, Chain Attacks
/// 
/// Base Stats:
/// - Max HP: 180
/// - Movement Speed: 5.5
/// - Damage Multiplier: 1.15
/// - XP Pickup Range: 50
/// 
/// Passive: Static Charge
/// - Charge Build: 1 charge per 2 units of distance moved
/// - Max Charge: 100
/// - Charge Decay: 5 charges per second when not moving
/// - Bonus Damage: 200% damage when fully charged
/// 
/// Starting Weapon: Thunderbolt
/// - Damage: 25
/// - Projectile Speed: 20
/// - Fire Rate: 0.8 attacks/second
/// - Pierce Count: 3 enemies
/// - Cooldown: 1.25s
/// - Range: 15 units
/// </summary>
public partial class ZeusCharacter : CharacterBody3D
{
    // Base Stats (Zeus-specific)
    [Export]
    public float BaseMaxHP { get; set; } = 180.0f;
    
    [Export]
    public float MovementSpeed { get; set; } = 5.5f;
    
    [Export]
    public float DamageMultiplier { get; set; } = 1.15f;
    
    [Export]
    public float XPPickupRange { get; set; } = 50.0f;

    // Current Stats
    public float CurrentMaxHP { get; private set; }
    public float CurrentDamageMultiplier { get; private set; }
    private float _currentHP;
    
    // Static Charge Passive
    private float _staticCharge = 0.0f;
    private const float MaxCharge = 100.0f;
    private const float ChargeBuildPerUnit = 0.5f; // 1 charge per 2 units moved
    private const float ChargeDecayPerSecond = 5.0f;
    private Vector3 _previousPosition;
    
    // Thunderbolt Weapon
    [Export]
    public PackedScene ThunderboltScene { get; set; }
    
    private Timer _thunderboltTimer;
    private const float ThunderboltFireRate = 0.8f; // attacks per second
    private const float ThunderboltCooldown = 1.25f;
    
    // References
    private GameManager _gameManager;
    private ProgressBar _healthBar;
    private ProgressBar _chargeBar;
    private Timer _chargeDecayTimer;

    public override void _Ready()
    {
        base._Ready();
        
        // Initialize stats
        CurrentMaxHP = BaseMaxHP;
        CurrentDamageMultiplier = DamageMultiplier;
        _currentHP = CurrentMaxHP;
        _previousPosition = Position;
        
        // Get references
        _gameManager = GetNode<GameManager>("/root/GameManager");
        _gameManager.Player = this;
        
        _healthBar = GetTree().CurrentScene.GetNode<ProgressBar>("HUD/HealthBar");
        _chargeBar = GetTree().CurrentScene.GetNode<ProgressBar>("HUD/ChargeBar");
        
        if (_healthBar != null)
        {
            _healthBar.MaxValue = CurrentMaxHP;
            _healthBar.Value = _currentHP;
        }
        
        if (_chargeBar != null)
        {
            _chargeBar.MaxValue = MaxCharge;
            _chargeBar.Value = _staticCharge;
        }
        
        // Setup thunderbolt timer
        _thunderboltTimer = new Timer();
        _thunderboltTimer.WaitTime = ThunderboltFireRate;
        _thunderboltTimer.Autostart = true;
        _thunderboltTimer.Timeout += OnThunderboltTimerTimeout;
        AddChild(_thunderboltTimer);
        
        // Setup charge decay timer
        _chargeDecayTimer = new Timer();
        _chargeDecayTimer.WaitTime = 1.0f;
        _chargeDecayTimer.Autostart = true;
        _chargeDecayTimer.Timeout += OnChargeDecay;
        AddChild(_chargeDecayTimer);
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        
        // Update UI
        if (_healthBar != null)
            _healthBar.Value = _currentHP;
        
        if (_chargeBar != null)
            _chargeBar.Value = _staticCharge;
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector3 velocity = Velocity;
        
        // Get input direction and handle movement
        Vector2 inputDir = Input.GetVector("left", "right", "up", "down");
        Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
        
        if (direction != Vector3.Zero)
        {
            velocity.X = direction.X * MovementSpeed;
            velocity.Z = direction.Z * MovementSpeed;
            
            // Build static charge when moving
            float distanceMoved = Position.DistanceTo(_previousPosition);
            _staticCharge = Mathf.Clamp(_staticCharge + distanceMoved * ChargeBuildPerUnit, 0, MaxCharge);
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, MovementSpeed);
            velocity.Z = Mathf.MoveToward(Velocity.Z, 0, MovementSpeed);
        }
        
        Velocity = velocity;
        MoveAndSlide();
        
        _previousPosition = Position;
    }

    private void OnThunderboltTimerTimeout()
    {
        if (_gameManager == null) return;
        
        var nearestEnemy = _gameManager.GetNearestEnemy();
        if (nearestEnemy == null) return;
        
        // Check if enemy is in range
        float distanceToEnemy = Position.DistanceTo(nearestEnemy.Position);
        if (distanceToEnemy > 15.0f) // Thunderbolt range: 15 units
            return;
        
        // Calculate bonus damage from static charge
        float bonusMultiplier = 1.0f;
        if (_staticCharge >= MaxCharge)
        {
            bonusMultiplier = 3.0f; // 200% bonus = 3x total damage
            GD.Print("Static Charge Full! Damage doubled!");
        }
        
        // Fire thunderbolt
        if (ThunderboltScene != null)
        {
            var thunderbolt = ThunderboltScene.Instantiate<ThunderboltProjectile>();
            GetParent().AddChild(thunderbolt);
            thunderbolt.GlobalPosition = GlobalPosition + Vector3.Up * 1.0f;
            
            // Calculate direction to enemy
            Vector3 direction = (nearestEnemy.GlobalPosition - GlobalPosition);
            direction.Y = 0; // Keep horizontal
            
            // Apply damage multiplier
            thunderbolt.Damage = (uint)(25 * CurrentDamageMultiplier * bonusMultiplier);
            thunderbolt.Initialize(direction);
        }
    }

    private void OnChargeDecay()
    {
        // Decay charge when not moving
        if (Velocity.Length() < 0.1f)
        {
            _staticCharge = Mathf.Max(0, _staticCharge - ChargeDecayPerSecond);
        }
    }

    public void TakeDamages(uint damages)
    {
        _currentHP = Mathf.Clamp(_currentHP - damages, 0, CurrentMaxHP);
        
        if (_currentHP <= 0)
        {
            Die();
        }
    }

    public void Heal(uint amount)
    {
        _currentHP = Mathf.Clamp(_currentHP + amount, 0, CurrentMaxHP);
    }

    private void Die()
    {
        GD.Print("Zeus has fallen!");
        // TODO: Implement game over logic
        QueueFree();
    }
}