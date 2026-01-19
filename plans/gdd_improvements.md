# GDD Improvements: Gods vs Mortals

## Overview

This document provides detailed improvements and additions to fill the gaps identified in the GDD analysis. Each section includes specific quantitative values, mechanics, and implementation details.

---

## Part 1: Ability Stat Improvements

### 1.1 Zeus - The Thunder King

**Base Stats:**

- Max HP: 180
- Movement Speed: 5.5
- Damage Multiplier: 1.15
- XP Pickup Range: 50

**Passive: Static Charge**

- Charge Build: 1 charge per 2 units of distance moved
- Max Charge: 100
- Charge Decay: 5 charges per second when not moving
- Bonus Damage: 200% damage when fully charged
- Visual Indicator: Blue electrical aura around player, intensity based on charge level

**Starting Weapon: Thunderbolt**

- Damage: 25
- Projectile Speed: 20
- Fire Rate: 0.8 attacks/second
- Pierce Count: 3 enemies
- Cooldown: 1.25s
- Range: 15 units

**Unique Abilities:**

| Ability | Damage | Cooldown | Range/Area | Duration | Special |
|---------|--------|----------|------------|----------|---------|
| Chain Lightning | 15 per arc | 2.5s | 8 unit chain radius | Instant | Arcs 5 times, each arc deals 80% of previous |
| Thunderclap | 40 | 8s | 6 unit radius | 0.5s stun | Stuns all enemies in radius |
| Storm Cloud | 20 per strike | 12s | 4 unit radius | 10s | Drifts randomly, strikes every 1.5s |

**Ultimate: Olympus Wrath**

- Resource: Divine Energy (max 100)
- Cost: 100 Divine Energy
- Duration: 5 seconds
- Damage per Strike: 80
- Strike Interval: 0.5s
- Total Strikes: 10
- Strike Pattern: Random locations across screen, prioritizes enemy clusters

---

### 1.2 Odin - The All-Father

**Base Stats:**

- Max HP: 200
- Movement Speed: 5.0
- Damage Multiplier: 1.0
- XP Pickup Range: 75 (+50%)
- XP Gain: +10%

**Passive: All-Seeing Eye**

- XP Pickup Range: +50% (75 units total)
- XP Gain: +10% from all sources
- Visual Indicator: Golden glow around XP orbs, increased pickup range indicator

**Starting Weapon: Gungnir**

- Damage: 30
- Projectile Speed: 18 (out), 12 (return)
- Fire Rate: 0.7 attacks/second
- Pierce Count: 2 enemies (outbound), infinite on return
- Cooldown: 1.4s
- Range: 12 units (outbound)

**Unique Abilities:**

| Ability | Damage | Cooldown | Range/Area | Duration | Special |
|---------|--------|----------|------------|----------|---------|
| Raven Scouts | 8 per peck | 3s | 6 unit orbit radius | Permanent | 2 birds, peck every 0.8s |
| Rune Trap | 50 | 6s | 2 unit trigger radius | 30s duration | Places 3 traps, max 6 active |
| Wolves of War | 25 | 10s | Chase range 20 units | 15s | 2 wolves, chase nearest enemy |

**Ultimate: Wild Hunt**

- Resource: Divine Energy (max 100)
- Cost: 100 Divine Energy
- Duration: 6 seconds
- Damage per Rider: 100
- Rider Count: 5
- Rider Speed: 25
- Pattern: Sweep across screen from left to right, then right to left

---

### 1.3 Ra - The Sun God

**Base Stats:**

- Max HP: 220
- Movement Speed: 4.8
- Damage Multiplier: 0.9
- Damage Reduction: 10%

**Passive: Solar Radiance**

- Burn Damage: 5 per second
- Radius: 4 units
- Visual Indicator: Orange/yellow aura, enemies in radius show burn effect

**Starting Weapon: Sun Beam**

- Damage: 15 per tick
- Tick Rate: 10 ticks/second
- Beam Width: 1 unit
- Range: 18 units
- Cooldown: None (continuous while holding)

**Unique Abilities:**

| Ability | Damage | Cooldown | Range/Area | Duration | Special |
|---------|--------|----------|------------|----------|---------|
| Solar Flare | 35 | 5s | 8 unit radius | 3s slow | Blinds (50% miss chance) + 30% slow |
| Obelisk | 20 per bolt | 15s | 15 unit range | 30s | Fires every 0.6s, max 2 active |
| Desert Heat | +50% burn damage | 8s | Passive buff | 15s | +50% burn duration |

**Ultimate: Supernova**

- Resource: Divine Energy (max 100)
- Cost: 100 Divine Energy
- Duration: 5 seconds
- Damage per Tick: 40
- Tick Rate: 8 ticks/second
- Radius: 10 units (expanding from 3 to 10 over 1s)
- Effects: Invulnerable, +200% movement speed, melts enemies

---

### 1.4 Generic Arsenal - Complete Stats

| Ability | Damage | Cooldown | Range/Area | Duration | Special |
|---------|--------|----------|------------|----------|---------|
| Aegis Shield | 15 on contact | 0.5s rotation | 2 unit radius | Permanent | Blocks projectiles, 1 shield (upgradable) |
| Titanic Stomp | 45 | 10s | 6 unit radius | 0.3s knockback | Knocks back 5 units |
| Divine Arrow | 35 | 2s | 20 unit range | 3s lifetime | Seeks enemies, pierces 2 |
| Plague of Locusts | 3 per tick | 8s | Follows enemy | 6s | 20 locusts, 5 ticks/sec |
| Meteor Shower | 30 per meteor | 12s | 3 unit impact radius | Instant | 3 meteors, random locations |
| Cyclone Blade | 20 | 1.5s per blade | 4 unit orbit radius | 8s | 3 blades, orbit speed 2 rotations/sec |
| Frost Orb | 25 | 3s | 4 unit field radius | 4s slow | 40% slow, ice field persists |
| Chain Whip | 40 | 2.5s | 8 unit horizontal line | Instant | Hits all in line |
| Ricochet Chakram | 28 | 4s | 15 unit bounce range | 5s | Bounces 5 times |

---

## Part 2: Evolution System Improvements

### 2.1 Passive Blessings - Stat Values

| Passive | Effect Value | Max Stacks |
|---------|--------------|------------|
| Hermes' Sandals | +15% Movement Speed | 5 |
| Ambrosia | +5 HP Recovery/sec, +20 Max HP | 5 |
| Hercules' Gauntlet | +10% Damage | 5 |
| Chronos' Hourglass | -10% Cooldowns | 5 |
| Apollo's Lens | +15% Area of Effect | 5 |
| Midas' Touch | +15% Gold/XP Gain | 5 |
| Aegis Fragment | +5 Armor (reduces damage by 5%) | 5 |
| Magnet Stone | +20% Pickup Range | 5 |
| Oracle's Eye | +5% Crit Chance (2x damage) | 5 |
| Berserker's Blood | +10% Attack Speed | 5 |
| Alchemist's Flask | +20% Duration | 5 |
| Gemini Twin | +1 Projectile | 3 |

### 2.2 Weapon Evolutions - Detailed Effects

| Base Weapon | Evolution Name | Changes |
|-------------|----------------|---------|
| **Sun Beam** | Solar Ray of Death | +100% damage, +50% beam width, +50% range, penetrates enemies |
| **Lifesteal** | Vampiric Aura | Becomes passive AoE, heals 5% of damage dealt to all enemies in 6 unit radius |
| **Titanic Stomp** | Earth Shatter | +150% damage, +100% radius, creates lingering damage field (10 damage/sec for 3s) |
| **Thunderbolt** | Thunder God's Wrath | +200% damage, +2 pierce, +50% speed, leaves electrified trail (15 damage/sec for 2s) |
| **Meteor Shower** | Armageddon | +100% damage, +2 meteors, meteors leave burning ground (20 damage/sec for 4s) |
| **Spirit Water** | Holy Flood | Creates expanding wave, +100% damage, pushes enemies back, heals player 20 HP |
| **Aegis Shield** | Phalanx Wall | +2 additional shields, shields rotate in formation, block threshold +50% |
| **Floating Sphere** | Orbiting Death Stars | +2 spheres, +100% damage, spheres explode on contact (30 AoE damage) |
| **Divine Arrow** | Artemis' Bow | Fires 3 arrows in spread, +50% damage per arrow, homing improved |
| **Chain Whip** | Nemesis Lash | +100% range, +50% damage, hits enemies in arc (180 degrees) |
| **Plague of Locusts** | Pestilence | +50% damage, locusts spread to nearby enemies on death, +50% duration |
| **Ricochet Chakram** | Infinity Disc | +3 bounces, +50% damage, bounces between enemies infinitely for 8s |

### 2.3 Tier 3 Divine Fusions - Complete Mechanics

| Fusion Name | Components | Effect |
|-------------|------------|--------|
| **Plasma Storm** | Thunder God's Wrath + Solar Ray of Death | Creates a massive electrical storm that follows the player. Deals 50 damage/sec to all enemies in 12 unit radius. Strikes random enemies for 100 damage every 0.5s. Duration: 15s. |
| **Blood Fortress** | Vampiric Aura + Phalanx Wall | Creates a fortress of 6 rotating shields. Player gains 20% lifesteal on all damage. Shields reflect 50% of blocked damage back to attacker. |
| **Ragnarok** | Earth Shatter + Armageddon | Triggers a cataclysmic event. Every 2 seconds for 20s, a massive earthquake deals 80 damage to all enemies and creates 3 meteors that deal 100 damage each. |
| **Pandora's Box** | Pestilence + Orbiting Death Stars | Releases chaos. 5 explosive orbs orbit the player. When an orb expires, it releases a swarm of locusts that spread to nearby enemies. Each explosion deals 60 damage in 4 unit radius. |

---

## Part 3: Enemy Stat Improvements

### 3.1 Era-Based Enemy Stats

**Base Scaling Formula:**

- Enemy HP = Base HP × (1 + (EraLevel × 0.5))
- Enemy Damage = Base Damage × (1 + (EraLevel × 0.3))
- Enemy Speed = Base Speed × (1 + (EraLevel × 0.1))

#### Stone Age (0:00 - 4:00)

| Enemy | HP | Damage | Speed | Attack Range | Attack Cooldown | Special |
|-------|----|--------|-------|--------------|-----------------|---------|
| Caveman | 50 | 10 | 2.0 | Melee (1.5) | 1.5s | None |
| Rock Thrower | 35 | 8 | 1.8 | 6 units | 2.0s | Throws rock (projectile) |

#### Ancient Era (4:00 - 8:00)

| Enemy | HP | Damage | Speed | Attack Range | Attack Cooldown | Special |
|-------|----|--------|-------|--------------|-----------------|---------|
| Hoplite | 80 | 15 | 2.2 | Melee (1.5) | 1.2s | Shield blocks first hit (20 HP shield) |
| Chariot | 100 | 25 | 4.5 | Charge (8) | 3.0s | Charge attack, knockback 3 units |

#### Medieval Era (8:00 - 12:00)

| Enemy | HP | Damage | Speed | Attack Range | Attack Cooldown | Special |
|-------|----|--------|-------|--------------|-----------------|---------|
| Knight | 120 | 20 | 2.0 | Melee (1.5) | 1.0s | 25% physical damage reduction |
| Archer | 50 | 12 | 2.5 | 15 units | 1.5s | Fires arrows, can hit from distance |
| Priest | 60 | 5 | 2.0 | 8 units | 2.0s | Heals nearby allies for 15 HP every 3s |

#### Modern Era (12:00 - 16:00)

| Enemy | HP | Damage | Speed | Attack Range | Attack Cooldown | Special |
|-------|----|--------|-------|--------------|-----------------|---------|
| Soldier | 90 | 18 | 2.8 | 12 units | 0.5s | Rapid fire (3 round burst) |
| Tank (Mini-Boss) | 500 | 40 | 1.5 | Melee (2.0) | 1.5s | Drops Ambrosia Key (100%) |

#### Future Era (16:00 - 20:00)

| Enemy | HP | Damage | Speed | Attack Range | Attack Cooldown | Special |
|-------|----|--------|-------|--------------|-----------------|---------|
| Cyborg | 150 | 25 | 3.0 | 10 units | 0.8s | Energy shield (50 HP, regenerates) |
| The Singularity (Final Boss) | 3000 | 60 | 1.0 | Screen-wide | Varies | Multiple attack patterns |

### 3.2 Boss Mechanics

#### Mini-Bosses (Elites)

- Spawn at: 4:00, 8:00, 12:00
- HP Multiplier: 3x base enemy HP
- Damage Multiplier: 2x base enemy damage
- Size: 1.5x normal size
- Drops: Tribute Chest (guaranteed)
- Special: Each has one unique ability based on era

#### The Singularity (Final Boss)

**Phase 1 (100% - 70% HP):**

- Pattern: Rotating laser beams
- Damage: 40 per second
- Warning: Laser paths shown before firing

**Phase 2 (70% - 40% HP):**

- Pattern: Homing missiles
- Damage: 50 per missile
- Count: 5 missiles, fired every 2s

**Phase 3 (40% - 0% HP):**

- Pattern: Bullet hell + laser beams
- Damage: 60 per hit
- Adds: Spawns 2 Cyborgs every 10s

#### Possessed Titan (God Mode Boss)

- HP: 5000
- Damage: 100
- Speed: 3.0
- Attack Pattern:
  - Melee slam (6 unit radius, 80 damage, 2s cooldown)
  - Energy beam (20 damage/sec, 5s duration, 8s cooldown)
  - Summon minions (spawns 3 random enemies, 10s cooldown)
- Defeat Reward: Guaranteed Divine Artifact (Tier 3) for next run

---

## Part 4: Era System Implementation

### 4.1 Era Manager Specification

```csharp
// EraDefinition structure
public enum Era
{
    StoneAge,      // 0:00 - 4:00
    Ancient,       // 4:00 - 8:00
    Medieval,      // 8:00 - 12:00
    Modern,        // 12:00 - 16:00
    Future         // 16:00 - 20:00
}

public class EraDefinition : Resource
{
    [Export] public Era EraType;
    [Export] public float StartTime; // In seconds
    [Export] public float EndTime;   // In seconds
    [Export] public Godot.Collections.Array<EnemyClass> EnemyPool;
    [Export] public float SpawnRateMultiplier;
    [Export] public float EnemyHealthMultiplier;
    [Export] public float EnemyDamageMultiplier;
    [Export] public float EnemySpeedMultiplier;
}
```

### 4.2 Era Transition Mechanics

- **Transition Type:** Time-based only (simpler implementation)
- **Transition Warning:** 10-second countdown before era change
- **Visual Indicator:** Screen edge color change, era name announcement
- **Spawn Pool Switch:** Instantaneous at era change time
- **Existing Enemies:** Remain in play, new era enemies start spawning

### 4.3 Spawn Rate Progression

| Era | Base Spawn Rate | Rate Increase per Minute |
|-----|-----------------|--------------------------|
| Stone Age | 1.0 enemies/sec | +0.1/sec |
| Ancient | 1.5 enemies/sec | +0.15/sec |
| Medieval | 2.0 enemies/sec | +0.2/sec |
| Modern | 2.5 enemies/sec | +0.25/sec |
| Future | 3.0 enemies/sec | +0.3/sec |

---

## Part 5: Divine Energy (Ultimate) System

### 5.1 Divine Energy Mechanics

- **Max Value:** 100
- **Gain:** 1 Divine Energy per enemy kill
- **Bonus Gain:** +5 Divine Energy for Elite kills, +20 for Boss kills
- **Visual:** Bar below health bar, fills from left to right, glows when full
- **Activation:** Press Spacebar (or Controller Y/Triangle)
- **Cooldown:** 30 seconds after ultimate ends before can use again

### 5.2 Ultimate Activation Flow

```
Player presses Ultimate Key
    ↓
Check Divine Energy >= 100
    ↓ Yes
Consume 100 Divine Energy
    ↓
Trigger Ultimate Effect
    ↓
Start 30s Cooldown
    ↓
Ultimate Effect Ends
```

---

## Part 6: Meta-Progression System

### 6.1 Worship (Mastery) System

**Mastery Levels:** 1-50 per God

**XP per Run:**

- Base: 100 Worship XP
- Per Minute Survived: +10 Worship XP
- Per Era Reached: +50 Worship XP
- Boss Defeated: +100 Worship XP
- Final Boss Defeated: +200 Worship XP

**Mastery Rewards:**

| Level Range | Reward |
|-------------|--------|
| 1-10 | +2 Max HP per level |
| 11-20 | +1% Damage per level |
| 21-30 | +0.5% Movement Speed per level |
| 31-40 | +1% XP Gain per level |
| 41-50 | +2% Ultimate Charge per level |

### 6.2 Equipment System

**Slots:**

1. Head - Defensive stats (Armor, Max HP)
2. Body - Utility stats (Movement Speed, Pickup Range)
3. Weapon Accessory - Offensive stats (Damage, Attack Speed, Cooldown Reduction)
4. Relic - Special effects (Lifesteal, Crit Chance, Projectile Count)

**Rarity Tiers:**

| Rarity | Color | Drop Chance | Stat Range |
|--------|-------|-------------|------------|
| Common | Grey | 60% | 5-10% |
| Uncommon | Green | 25% | 10-20% |
| Rare | Blue | 10% | 20-35% |
| Epic | Purple | 4% | 35-50% |
| Divine | Gold | 1% | 50-75% |

**Inventory:**

- Max Slots: 50
- Can sell items for Gold (currency for future features)
- Items are God-specific or Global (50/50 split)

---

## Part 7: UI/UX Specifications

### 7.1 HUD Layout

```
┌─────────────────────────────────────────────────────────────┐
│  [Level: 5]              [Time: 03:45]              [Score] │
│                                                             │
│                                                             │
│                                                             │
│                                                             │
│                                                             │
│                    [Game View Area]                         │
│                                                             │
│                                                             │
│                                                             │
│                                                             │
│                                                             │
│  [Health: 180/200]    [XP: 45/100]    [Divine: 75/100]     │
│                                                             │
│  [Ability 1: ⚡] [Ability 2: ⚡] [Ability 3: ⚡] [Ult: ⚡]   │
└─────────────────────────────────────────────────────────────┘
```

### 7.2 Level-up Selection UI

- **Format:** 3 cards displayed horizontally
- **Card Content:**
  - Ability Name
  - Icon
  - Current Level / Max Level
  - Stat Changes (green for positive)
  - Description
- **Selection:** Click card or press 1/2/3

### 7.3 Character Select UI

- **Format:** Large portraits of each God
- **Information Panel:**
  - God Name
  - Archetype
  - Base Stats (HP, Speed, Damage)
  - Passive Ability (name + description)
  - Starting Weapon (name + description)
  - Mastery Level
- **Selection:** Click portrait or use arrow keys

---

## Part 8: Save System Specification

### 8.1 Save Data Structure

```json
{
  "version": "1.0",
  "lastSaveTime": "2026-01-19T05:00:00Z",
  "gods": {
    "zeus": {
      "masteryLevel": 15,
      "worshipXP": 2500,
      "inventory": [
        {"id": "item_001", "rarity": "Rare", "equipped": false, "slot": "Head"},
        {"id": "item_002", "rarity": "Common", "equipped": true, "slot": "Body"}
      ],
      "unlockedAchievements": ["zeus_first_kill", "zeus_era2"]
    },
    "odin": {
      "masteryLevel": 8,
      "worshipXP": 1200,
      "inventory": [],
      "unlockedAchievements": []
    },
    "ra": {
      "masteryLevel": 3,
      "worshipXP": 400,
      "inventory": [],
      "unlockedAchievements": []
    }
  },
  "settings": {
    "graphics": {
      "quality": "High",
      "vsync": true,
      "fullscreen": false
    },
    "audio": {
      "masterVolume": 0.8,
      "musicVolume": 0.7,
      "sfxVolume": 0.9
    },
    "controls": {
      "moveUp": "W",
      "moveDown": "S",
      "moveLeft": "A",
      "moveRight": "D",
      "ultimate": "Space"
    }
  },
  "globalStats": {
    "totalRuns": 25,
    "totalKills": 15420,
    "totalTime": 12500,
    "highestLevel": 45,
    "bossesDefeated": 18
  }
}
```

### 8.2 Save Frequency

- **Auto-save:** After every run completion (death or victory)
- **Manual save:** Available from main menu
- **Save Slots:** 3 slots (Auto, Manual 1, Manual 2)

---

## Part 9: Difficulty System

### 9.1 Difficulty Modes

| Mode | Enemy HP | Enemy Damage | Spawn Rate | XP Gain | Unlock Condition |
|------|----------|--------------|------------|---------|------------------|
| Easy | 0.7x | 0.7x | 0.8x | 1.2x | Available from start |
| Normal | 1.0x | 1.0x | 1.0x | 1.0x | Available from start |
| Hard | 1.3x | 1.3x | 1.2x | 0.9x | Reach Mastery 10 with any God |
| Nightmare | 1.6x | 1.6x | 1.5x | 0.8x | Defeat Final Boss on Hard |

### 9.2 God Mode (Bonus Round) Modifiers

- **Damage:** +500%
- **Cooldown Reduction:** -80%
- **Duration:** 2 minutes (fixed)
- **XP Gain:** +20 levels instantly from boss explosion
- **Music:** Epic orchestral/metal mix

---

## Part 10: Technical Specifications

### 10.1 Performance Targets

| Target | Value |
|--------|-------|
| Target FPS | 60 |
| Minimum Acceptable FPS | 30 |
| Max Enemies on Screen | 200 |
| Max Projectiles on Screen | 100 |
| Target Load Time | < 3 seconds |

### 10.2 Platform Requirements

**PC (Minimum):**

- OS: Windows 10/11
- CPU: Intel i3-8100 / AMD Ryzen 3 1200
- RAM: 8 GB
- GPU: NVIDIA GTX 960 / AMD RX 570
- Storage: 2 GB available space

**PC (Recommended):**

- OS: Windows 10/11
- CPU: Intel i5-8400 / AMD Ryzen 5 2600
- RAM: 16 GB
- GPU: NVIDIA GTX 1060 / AMD RX 580
- Storage: 2 GB SSD

### 10.3 Godot Version

- **Target:** Godot 4.3+
- **Required Addons:**
  - godot-jolt (physics)
  - kaykit_characters (assets)
  - kaykit_dungeon_remastered (assets)
  - kaykit_skeleton_pack (assets)

---

## Part 11: Asset Specifications

### 11.1 Model Specs

| Asset Type | Poly Count | Texture Resolution |
|------------|------------|-------------------|
| Player (Gods) | 2000-3000 | 1024x1024 |
| Enemies | 1000-2000 | 512x512 |
| Bosses | 5000-8000 | 2048x2048 |
| Projectiles | 100-500 | 256x256 |
| Environment | 500-1000 per prop | 512x512 |

### 11.2 VFX Guidelines

- **Max Particles:** 500 per system
- **Particle Lifetime:** 0.5-3 seconds
- **Visual Clarity:** Enemies must remain visible through VFX
- **Color Coding:** Each God has distinct color scheme (Zeus: Blue/Yellow, Odin: Purple/Green, Ra: Orange/Red)

---

## Part 12: Accessibility Features

### 12.1 Colorblind Modes

- **Protanopia Support:** Red-Green colorblind adjustment
- **Deuteranopia Support:** Red-Green colorblind adjustment
- **Tritanopia Support:** Blue-Yellow colorblind adjustment
- **High Contrast Mode:** Increased contrast for all UI elements

### 12.2 Visual Aids

- **Damage Numbers:** Toggle on/off, adjustable size
- **Enemy Health Bars:** Toggle on/off for elites and bosses
- **Hit Indicators:** Screen flash on player damage
- **Projectile Highlights:** Enhanced visibility for enemy projectiles

### 12.3 Control Options

- **Full Remapping:** All keys/buttons can be remapped
- **Controller Presets:** Xbox, PlayStation, Switch layouts
- **Input Sensitivity:** Adjustable for analog sticks

---

## Part 13: Achievement System

### 13.1 Achievement List

**General Achievements:**

- First Blood - Kill your first enemy
- Survivor - Survive for 5 minutes
- Century - Reach Level 100
- God Slayer - Defeat The Singularity

**God-Specific Achievements:**

**Zeus:**

- Thunderstruck - Kill 100 enemies with Chain Lightning
- Storm Master - Reach Level 8 with Storm Cloud
- Wrath of Olympus - Use Olympus Wrath 10 times

**Odin:**

- All-Seeing - Collect 1000 XP orbs
- Raven's Feast - Kill 500 enemies with Raven Scouts
- Wild Hunt - Defeat 5 bosses using Wild Hunt

**Ra:**

- Solar Flare - Blind 50 enemies with Solar Flare
- Desert King - Survive the Future Era with Ra
- Supernova - Kill 100 enemies during a single Supernova

**Challenge Achievements:**

- Untouchable - Complete a run without taking damage
- Speed Demon - Defeat The Singularity in under 15 minutes
- Nightmare - Defeat The Singularity on Nightmare difficulty
- God Mode - Defeat the Possessed Titan

---

*Document Version: 1.0*
*Last Updated: 2026-01-19*
