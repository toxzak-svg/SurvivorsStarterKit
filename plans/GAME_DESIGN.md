# Game Design Document: Gods vs Mortals

## 1. High Concept

**Title:** Gods vs Mortals
**Genre:** Rogue-lite Survivor (Vampire Survivors style)
**Theme:** Mythological Gods fighting against the relentless march of humanity.
**Visual Style:** Cool, vibrant, cel-shaded "Cartoon" aesthetic. Low-poly 3D with punchy VFX.

**Core Loop:**
Select a God (Zeus/Odin/Ra) -> Enter the Arena -> Survive waves of Humans that technologically evolve over time -> Upgrade Abilities -> Unleash Divine Ultimates -> Repeat.

## 2. The Gods (Playable Characters)

Each God has unique base stats, a passive trait, and a starting weapon/ability. As they level up, they can acquire abilities from their specific pool (or generic ones).

### A. Zeus (Greek Pantheon) - The Thunder King

*Archetype: High Burst Damage, Chain Attacks.*

- **Passive:** *Static Charge* - Moving builds up charge. At max charge, next attack deals 200% damage.
- **Starting Weapon:** *Thunderbolt* - Horizontal projectile that pierces enemies.
- **Unique Abilities:**
  - *Chain Lightning:* Arcs between nearby enemies.
  - *Thunderclap:* AOE stun around the player.
  - *Storm Cloud:* Drifts randomly, raining lightning on enemies below.
- **Ultimate:** *Olympus Wrath* - Massive lightning strikes screen-wide for 5 seconds.

### B. Odin (Norse Pantheon) - The All-Father

*Archetype: Summoner, Wisdom (XP gain), Ranged Utility.*

- **Passive:** *All-Seeing Eye* - Experience pickup range +50%, XP Gain +10%.
- **Starting Weapon:** *Gungnir* - Thrown spear that always returns to Odin, damaging enemies on the way back.
- **Unique Abilities:**
  - *Raven Scouts (Huginn & Muninn):* Two birds circle Odin, pecking enemies.
  - *Rune Trap:* Places traps on the ground that explode when stepped on.
  - *Wolves of War:* Summons two wolves that chase down enemies.
- **Ultimate:** *Wild Hunt* - Ghostly riders sweep across the screen, trampling everything.

### C. Ra (Egyptian Pantheon) - The Sun God

*Archetype: Area Consistency, DoT (Damage over Time), Defensive.*

- **Passive:** *Solar Radiance* - Enemies within a small radius take constant burn damage.
- **Starting Weapon:** *Sun Beam* - Continuous laser beam in facing direction.
- **Unique Abilities:**
  - *Solar Flare:* Periodic radial pulse that blinds/slows enemies.
  - *Obelisk:* Summons a turret that shoots solar bolts.
  - *Desert Heat:* Increases burn damage and duration.
- **Ultimate:** *Supernova* - Ra becomes a miniature sun, becoming invulnerable and melting everything nearby for 5 seconds.

## 3. Generic Arsenal (Shared Skills)

In addition to the 4 starter kit spells (Shooting, Lifesteal, Floating Sphere, Spirit Water), the following new skills are available to **all Gods**:

1. **Aegis Shield**: A rotating shield that blocks projectiles and damages enemies on contact.
2. **Titanic Stomp**: Periodically damages and knocks back all nearby enemies.
3. **Divine Arrow**: Fires a slow-moving, piercing arrow that seeks enemies.
4. **Plague of Locusts**: A cloud of insects that moves to enemies, dealing low DoT.
5. **Meteor Shower**: Calls down 3 small meteors at random locations on the screen.
6. **Cyclone Blade**: Spawns spinning blades that orbit the player at a distance.
7. **Frost Orb**: Shoots an orb that creates a slowing ice field on impact.
8. **Chain Whip**: Strikes enemies in a horizontal line in front of the player.
9. **Ricochet Chakram**: Thrown disc that bounces between enemies.

## 4. Passive Support Skills & Evolution

In addition to active weapons, players can select **Passive Blessings**. These stats boost the player and **enable Weapon Evolutions**.

| Passive Name | Effect | Evolves With... |
| :--- | :--- | :--- |
| **Hermes' Sandals** | +Movement Speed | Sun Beam -> **Solar Ray of Death** |
| **Ambrosia** | +HP Recovery / Max HP | Lifesteal -> **Vampiric Aura** |
| **Hercules' Gauntlet** | +Damage (Might) | Titanic Stomp -> **Earth Shatter** |
| **Chronos' Hourglass** | -Cooldowns | Lightning Bolt -> **Thunder God's Wrath** |
| **Apollo's Lens** | +Area of Effect | Meteor Shower -> **Armageddon** |
| **Midas' Touch** | +Gold/XP Gain | Spirit Water -> **Holy Flood** |
| **Aegis Fragment** | +Armor | Aegis Shield -> **Phalanx Wall** |
| **Magnet Stone** | +Pickup Range | Floating Sphere -> **Orbiting Death Stars** |
| **Oracle's Eye** | +Crit Chance | Divine Arrow -> **Artemis' Bow** |
| **Berserker's Blood** | +Attack Speed | Chain Whip -> **Nemesis Lash** |
| **Alchemist's Flask** | +Duration | Plague of Locusts -> **Pestilence** |
| **Gemini Twin** | +Amount (Projectiles) | Ricochet Chakram -> **Infinity Disc** |

### Divine Evolution (Skill Merging)

**Mechanic:**

1. Level an **Active Weapon** to Max Level (8).
2. Have the matching **Passive Blessing** (Level 1+).
3. Open a **Tribute Chest** (dropped by Bosses/Elites).
4. **Result:** The weapon evolves into its "Superpowered" form (Tier 2).

### Tier 3: Divine Fusion (Artifacts)

**Mechanic:** Two specific **Evolved Weapons** (Tier 2) can be merged in a chest to create a **Godly Artifact** (Tier 3).

- **Benefits:** Frees up a weapon slot and provides game-breaking power.
- **Recipes:**
  - **Plasma Storm** = *Thunder God's Wrath* + *Solar Ray of Death*
  - **Blood Fortress** = *Vampiric Aura* + *Phalanx Wall*
  - **Ragnarok** = *Earth Shatter* + *Armageddon*
  - **Pandora's Box** = *Pestilence* + *Orbiting Death Stars*

## 5. The Mortals (Enemy Progression - "Eras")

Instead of just random mobs, the enemies evolve through "Eras" as the match time progresses (or based on player level).

**Match Duration Goal:** 20 Minutes.

| Era | Time | Enemy Types | Behavior |
| :--- | :--- | :--- | :--- |
| **I. Stone Age** | 0:00 - 4:00 | **Cavemen**: Slow, high HP, melee clubs.<br>**Throwers**: Throw rocks (short range). | Swarm tactics, slow movement. |
| **II. Ancient Era** | 4:00 - 8:00 | **Hoplites**: Shielded (block first hit), spears.<br>**Chariots**: Fast charge attacks. | Formation movement, higher durability. |
| **III. Medieval Era** | 8:00 - 12:00 | **Knights**: Heavy armor (reduce phys damage).<br>**Archers**: Long range volley fire.<br>**Priests**: Heal other humans. | Balanced mix of range and melee. |
| **IV. Modern Era** | 12:00 - 16:00 | **Soldiers**: Auto-rifles.<br>**Tank (Mini-Boss @ 15:00)**: Drops "Divine Key". | Ranged dominance. |
| **V. Future Era** | 16:00 - 20:00 | **Cyborgs**: Shields.<br>**The Singularity (FINAL BOSS @ 20:00)**: Giant AI Core. | Bullet hell. |

## 6. Boss System & Bonus Round

**Mini-Bosses (Elites):**
Spawn at fixed timestamps (4:00, 8:00, 12:00). Tougher versions of Mob types. Drop **Tribute Chests** (Evolution/Loot).

**The Final Boss:**
Spawns at 20:00. Clears screen of all other mobs. Must be defeated to "Win".

### "God Mode" (Bonus Round)

**Unlock Condition:** Defeat the Era IV Mini-Boss (Tank) to loot the **"Ambrosia Key"**.

**Mechanic:**

1. Defeat the Final Boss (The Singularity).
2. If holding the Key, the Boss does not die—it gets **Possessed** by Chaos.
3. **XP Piñata:** The Boss explodes, dropping massive amounts of XP (instant +20 Levels).
4. **GOD MODE ON:** Player cooldowns reduced by 80%, Damage +500%. Music shifts to heavy metal/epic orchestral.
5. **Titan Fight:** Fight the "Possessed Titan" for 2 minutes. Defeating it grants a **Guaranteed Divine Artifact** (Tier 3 Fusion drop) for the next run.

## 7. Meta-Progression & Loot

**Divine Mastery (XP):**
Playing as a God earns "Worship" (XP). Higher Mastery levels unlock permanent base stat boosts.

**Loot System (Equipment):**
Bosses and special "Tribute Chests" (random spawns) drop **Divine Relics** (Equipment).

- **Slots:** Head, Body, Weapon Accessory, Relic.
- **Rarity:** Common (Grey) -> Divine (Gold).
- **Stats:** Relics provide stats like "Cooldown Reduction", "+1 Projectile", "Movement Speed".
- **Inventory:** Manage loot in the Main Menu (Character Select).

**Implementation Logic:**

- **Save System:** Track Inventory list and Equipped items per God (or global).
- **Drop Logic:** Boss death triggers RNG loot roll.
- **Modifier:** Apply Equipment stats on top of Base/Mastery stats.

## 6. Technical Implementation Plan

This plan utilizes the `SurvivorsStarterKit` (Godot 4/C#).

### Phase 1: Foundation & Cleanup

1. **Project Review**: Analyze `GameManager`, `EnemySpawner`, and `Player` classes.
2. **Tagging**: Establish Tag/Layer system for `Player`, `Enemy`, `Projectile`.
3. **Input**: Ensure WASD/Controller support is smooth.

### Phase 2: The Era System (New Logic)

*The default spawner likely uses a simple list. We need to replace this.*

1. **EraManager Class**: A new script to track `GameTime` and state `CurrentEra`.
2. **Spawn Pools**: Create cleaner `Resource` based spawn pools for each Era.
    - `StoneAgePool`, `AncientAgePool`, etc.
3. **Spawner Update**: Modify `EnemySpawner` to subscribe to `EraManager`. When Era changes, switch the active Spawn Pool.

### Phase 3: Character System (The Gods)

1. **GodBase Class**: Inherit from the kit's `Player` class? Or refactor `Player` to accept a `GodProfile` resource.
    - *Recommendation*: Use a `GodProfile` Resource (ScriptableObject equivalent) that holds: BaseStats, StartingWeaponPrefab, PassiveEffectScript.
2. **Character Select Screen**: Simple UI to pick a God before loading the main scene.
3. **Asset Integration**: Replace the default capsule player with temporary "God" placeholders (different colors/shapes) until art is ready.

### Phase 4: Ability Creation

1. **Weapon System**: The kit has 4 spells. We need to implement the 9+ unique ones + 3 ultimates.
    - Use Inheritance: `WeaponBase` -> `ProjectileWeapon` (Zeus Bolt), `MeleeWeapon` (Ra Aura), `SummonWeapon` (Odin Wolves).
2. **Ultimate Mechanic**: Add a "Mana" or "Rage" bar that fills on kills. Press Space to unleash Ultimate.

### Phase 5: Art & Juice (The "Cartoon" Feel)

1. **Shader**: Implement a "Toon Shader" for all 3D models.
    - *Details*: Cel shading, Outline effect.
2. **VFX**: Particle effects are crucial.
    - Lightning sparks, Feathers, Sun glow.
3. **Animation**: Squash and stretch on hit, exaggerated death animations for humans.

## 5. Directory Structure

```
res://
  ├── _Game/
  │   ├── Characters/
  │   │   ├── Gods/
  │   │   │   ├── Zeus/
  │   │   │   ├── Odin/
  │   │   │   └── Ra/
  │   │   └── Enemies/
  │   │       ├── StoneAge/
  │   │       ├── Ancient/
  │   │       └── ...
  │   ├── Systems/
  │   │   ├── Spawning/
  │   │   │   ├── EraManager.cs
  │   │   │   └── EraDefinition.tres
  │   │   └── Abilities/
  │   ├── UI/
  │   └── Maps/
  └── _Assets/
      ├── Models/
      ├── Shaders/
      └── Audio/
```

## 6. Next Steps for Copilot

1. Create the `EraManager.cs`.
2. Define the `EraDefinition` resource type.
3. Refactor `EnemySpawner` to use Eras.
4. Create the `GodProfile` resource and update `Player` to use it.
