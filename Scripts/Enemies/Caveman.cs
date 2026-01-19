using Godot;

/// <summary>
/// Stone Age enemy - melee combatant with primitive weapons
/// Era: Stone Age (0:00 - 4:00)
/// </summary>
public partial class Caveman : Enemy
{
    // Caveman-specific stats from GDD
    public const int CavemanBaseHP = 50;
    public const uint CavemanDamage = 10;
    public const float CavemanSpeed = 2.0f;
    public const float CavemanAttackRange = 1.5f;
    public const float CavemanAttackCooldown = 1.5f;
    public const int CavemanXP = 5;

    public override void _Ready()
    {
        // Set Caveman-specific stats
        Lifepoints = CavemanBaseHP;
        Damages = CavemanDamage;
        MovementSpeed = CavemanSpeed;
        Experience = CavemanXP;
        
        base._Ready();
    }

    /// <summary>
    /// Override attack range for Caveman melee attacks
    /// </summary>
    public new bool IsPlayerInAttackRange => (_gameManager.Player.GlobalPosition - GlobalPosition).Length() <= CavemanAttackRange;
}