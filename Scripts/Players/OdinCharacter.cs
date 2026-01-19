using Godot;
using System;

/// <summary>
/// Odin - The All-Father
/// Archetype: Summoner, Wisdom (XP gain), Ranged Utility
/// 
/// Base Stats:
/// - Max HP: 200
/// - Movement Speed: 5.0 (Default)
/// - XP Pickup Range: 75 (+50%)
/// - XP Gain: +10%
/// 
/// Passive: All-Seeing Eye
/// - XP Pickup Range: +50% (75 units total)
/// - XP Gain: +10% from all sources
/// 
/// Starting Weapon: Gungnir
/// - Damage: 30
/// - Projectile Speed: 18 (out), 12 (return)
/// - Range: 12 units
/// </summary>
public partial class OdinCharacter : Player
{
    // Override Stats
    public override float XPGainMultiplier => 1.1f; // +10% XP Gain
    public override float XPPickupRange => 75.0f; // 75 units

    // Gungnir Weapon
    [Export]
    public PackedScene GungnirScene { get; set; }

    private Timer _gungnirTimer;
    private const float GungnirFireRate = 0.7f; // attacks per second (1.4s cooldown)
    private const float GungnirCooldown = 1.4f;

    private GameManager _gameManager;

    public override void _Ready()
    {
        base._Ready();
        
        _gameManager = GetNode<GameManager>("/root/GameManager");

        // Setup Gungnir timer
        _gungnirTimer = new Timer();
        _gungnirTimer.WaitTime = GungnirCooldown;
        _gungnirTimer.Autostart = true;
        _gungnirTimer.Timeout += OnGungnirTimerTimeout;
        AddChild(_gungnirTimer);
    }

    private void OnGungnirTimerTimeout()
    {
        if (_gameManager == null) return;

        var nearestEnemy = _gameManager.GetNearestEnemy();
        if (nearestEnemy == null) return;

        // Check if enemy is within generic range (or just fire towards nearest?)
        // Gungnir has 12 units outbound range.
        float distanceToEnemy = GlobalPosition.DistanceTo(nearestEnemy.GlobalPosition);
        if (distanceToEnemy > 15.0f) // Allow firing a bit further than max range so it travels
            return;

        FireGungnir(nearestEnemy);
    }

    private void FireGungnir(Enemy target)
    {
        if (GungnirScene != null)
        {
            var gungnir = GungnirScene.Instantiate<GungnirProjectile>();
            GetParent().AddChild(gungnir);
            gungnir.GlobalPosition = GlobalPosition + Vector3.Up * 1.0f;

            // Calculate direction
            Vector3 direction = (target.GlobalPosition - GlobalPosition).Normalized();
            direction.Y = 0; // Keep horizontal

            // Initialize projectile
            gungnir.Initialize(direction, this);
        }
    }
}
