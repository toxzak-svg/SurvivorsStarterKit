using Godot;
using System;

/// <summary>
/// Manages the Era progression system for enemy evolution over time
/// Based on GDD: 5 Eras from Stone Age (0:00) to Future Era (20:00)
/// </summary>
public partial class EraManager : Node
{
    public enum Era
    {
        StoneAge,      // 0:00 - 4:00
        Ancient,       // 4:00 - 8:00
        Medieval,      // 8:00 - 12:00
        Modern,        // 12:00 - 16:00
        Future         // 16:00 - 20:00
    }

    // Era definitions with start times (in seconds)
    private static readonly float[] EraStartTimes = { 0f, 240f, 480f, 720f, 960f };
    
    // Spawn rate multipliers per era (from GDD)
    private static readonly float[] SpawnRateMultipliers = { 1.0f, 1.5f, 2.0f, 2.5f, 3.0f };
    
    // HP multipliers per era (from GDD scaling formula)
    private static readonly float[] HealthMultipliers = { 1.0f, 1.5f, 2.0f, 2.5f, 3.0f };
    
    // Damage multipliers per era (from GDD scaling formula)
    private static readonly float[] DamageMultipliers = { 1.0f, 1.3f, 1.6f, 1.9f, 2.2f };
    
    // Speed multipliers per era (from GDD scaling formula)
    private static readonly float[] SpeedMultipliers = { 1.0f, 1.1f, 1.2f, 1.3f, 1.4f };

    // Game state
    private double _gameTime = 0;
    private Era _currentEra = Era.StoneAge;
    
    // Events
    [Signal]
    public delegate void EraChangedEventHandler(Era newEra, double gameTime);
    
    [Signal]
    public delegate void GameTimeUpdatedEventHandler(double gameTime);

    /// <summary>
    /// Current game time in seconds
    /// </summary>
    public double GameTime => _gameTime;
    
    /// <summary>
    /// Current era
    /// </summary>
    public Era CurrentEra => _currentEra;
    
    /// <summary>
    /// Current era index (0-4)
    /// </summary>
    public int CurrentEraIndex => (int)_currentEra;
    
    /// <summary>
    /// Spawn rate multiplier for current era
    /// </summary>
    public float SpawnRateMultiplier => SpawnRateMultipliers[(int)_currentEra];
    
    /// <summary>
    /// Health multiplier for current era
    /// </summary>
    public float HealthMultiplier => HealthMultipliers[(int)_currentEra];
    
    /// <summary>
    /// Damage multiplier for current era
    /// </summary>
    public float DamageMultiplier => DamageMultipliers[(int)_currentEra];
    
    /// <summary>
    /// Speed multiplier for current era
    /// </summary>
    public float SpeedMultiplier => SpeedMultipliers[(int)_currentEra];

    public override void _Process(double delta)
    {
        _gameTime += delta;
        
        // Check for era transition
        int newEraIndex = GetCurrentEraIndex(_gameTime);
        if (newEraIndex != (int)_currentEra)
        {
            Era previousEra = _currentEra;
            _currentEra = (Era)newEraIndex;
            EmitSignal(SignalName.EraChanged, _currentEra, _gameTime);
            GD.Print($"Era transition: {previousEra} -> {_currentEra} at {_gameTime:F2}s");
        }
        
        EmitSignal(SignalName.GameTimeUpdated, _gameTime);
    }
    
    /// <summary>
    /// Get era index based on game time
    /// </summary>
    private int GetCurrentEraIndex(double gameTime)
    {
        for (int i = EraStartTimes.Length - 1; i >= 0; i--)
        {
            if (gameTime >= EraStartTimes[i])
            {
                return i;
            }
        }
        return 0;
    }
    
    /// <summary>
    /// Reset game time (for new game)
    /// </summary>
    public void ResetGame()
    {
        _gameTime = 0;
        _currentEra = Era.StoneAge;
    }
    
    /// <summary>
    /// Format game time as MM:SS
    /// </summary>
    public string FormatTime()
    {
        int minutes = (int)(_gameTime / 60);
        int seconds = (int)(_gameTime % 60);
        return $"{minutes:D2}:{seconds:D2}";
    }
    
    /// <summary>
    /// Get time remaining in current era
    /// </summary>
    public float GetEraTimeRemaining()
    {
        int currentEraIndex = (int)_currentEra;
        if (currentEraIndex >= EraStartTimes.Length - 1)
        {
            return float.MaxValue; // Last era continues indefinitely
        }
        return EraStartTimes[currentEraIndex + 1] - (float)_gameTime;
    }
}