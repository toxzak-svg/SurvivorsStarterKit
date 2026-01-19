using Godot;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

/// <summary>
/// Simple SaveManager to persist minimal run state to disk (user data folder).
/// Provides 3 slots: 0 = Auto, 1 = Manual1, 2 = Manual2
/// Uses System.Text.Json for serialization and writes to OS.GetUserDataDir()/saves/
/// </summary>
public partial class SaveManager : Node
{
    public const int Slots = 3;

    public record SaveData
    {
        public double GameTime { get; init; }
        public int PlayerLevel { get; init; }
        public float PlayerHP { get; init; }
        public Dictionary<string, int> PowerupCounts { get; init; } = new();
        public Dictionary<string, int> EnemyPowerupCounts { get; init; } = new();
        // Add more fields as needed
    }

    private readonly string _savesDir;
    private JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

    public SaveManager()
    {
        _savesDir = Path.Combine(OS.GetUserDataDir(), "saves");
        try
        {
            if (!Directory.Exists(_savesDir))
                Directory.CreateDirectory(_savesDir);
        }
        catch (Exception e)
        {
            GD.PrintErr($"SaveManager: failed to create saves dir: {e.Message}");
        }
    }

    private string GetSlotPath(int slot)
    {
        slot = Math.Clamp(slot, 0, Slots - 1);
        return Path.Combine(_savesDir, $"slot_{slot}.json");
    }

    public bool SaveSlot(int slot, SaveData data)
    {
        try
        {
            string path = GetSlotPath(slot);
            string json = JsonSerializer.Serialize(data, _jsonOptions);
            File.WriteAllText(path, json);
            GD.Print($"SaveManager: saved slot {slot} -> {path}");
            return true;
        }
        catch (Exception e)
        {
            GD.PrintErr($"SaveManager: SaveSlot error: {e.Message}");
            return false;
        }
    }

    public SaveData LoadSlot(int slot)
    {
        try
        {
            string path = GetSlotPath(slot);
            if (!File.Exists(path))
            {
                GD.Print($"SaveManager: slot {slot} not found -> returning default SaveData");
                return new SaveData();
            }

            string json = File.ReadAllText(path);
            var data = JsonSerializer.Deserialize<SaveData>(json, _jsonOptions);
            return data ?? new SaveData();
        }
        catch (Exception e)
        {
            GD.PrintErr($"SaveManager: LoadSlot error: {e.Message}");
            return new SaveData();
        }
    }

    public bool DeleteSlot(int slot)
    {
        try
        {
            string path = GetSlotPath(slot);
            if (File.Exists(path))
            {
                File.Delete(path);
                GD.Print($"SaveManager: deleted slot {slot}");
            }
            return true;
        }
        catch (Exception e)
        {
            GD.PrintErr($"SaveManager: DeleteSlot error: {e.Message}");
            return false;
        }
    }
}
