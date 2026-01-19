# GDD Analysis: Gods vs Mortals

## Executive Summary

This document analyzes the Game Design Document (GAME_DESIGN.md) for "Gods vs Mortals" and identifies areas requiring improvement. The analysis is divided into two categories: **Low Integrity Parts** (sections that are vague, incomplete, or inconsistent) and **Missing Gaps** (essential information that should be included but isn't).

---

## Part 1: Low Integrity Parts

### 1.1 Section 2: The Gods (Playable Characters)

**Issues Identified:**

| Area | Problem | Impact |
|------|---------|--------|
| **Ability Mechanics** | No quantitative values for damage, cooldowns, range, AoE size, duration | Cannot balance or implement properly |
| **Passive Effects** | "Static Charge" - unclear how charge builds, what max charge is, visual feedback | Ambiguous gameplay mechanic |
| **Ultimates** | No mana/rage cost, no cooldown, no duration specifics | Critical gameplay mechanic undefined |
| **Starting Weapon Stats** | Base damage, fire rate, projectile speed all undefined | Cannot implement starting loadouts |

**Specific Examples:**

- *Thunderbolt*: "Horizontal projectile that pierces enemies" - How many enemies? What's the damage? Fire rate?
- *Static Charge*: "Moving builds up charge" - How much charge per unit distance? How fast does it decay?
- *Olympus Wrath*: "Massive lightning strikes screen-wide for 5 seconds" - Damage per strike? Number of strikes? Cooldown?

### 1.2 Section 3: Generic Arsenal (Shared Skills)

**Issues Identified:**

| Skill | Missing Information |
|-------|---------------------|
| **Aegis Shield** | Rotation speed, block damage threshold, damage on contact value |
| **Titanic Stomp** | Damage value, knockback distance, cooldown, activation radius |
| **Divine Arrow** | Damage, projectile speed, seeking range, cooldown |
| **Plague of Locusts** | DoT amount per tick, duration, number of insects, movement speed |
| **Meteor Shower** | Damage per meteor, meteor size, cooldown, impact AoE |
| **Cyclone Blade** | Damage, orbit radius, rotation speed, number of blades |
| **Frost Orb** | Damage, projectile speed, slow percentage, slow duration, field size |
| **Chain Whip** | Damage, range, cooldown, attack speed |
| **Ricochet Chakram** | Damage, bounce count, bounce range, cooldown |

### 1.3 Section 4: Passive Support Skills & Evolution

**Issues Identified:**

| Area | Problem | Details |
|------|---------|---------|
| **Stat Boost Values** | No quantitative values for any passive | "+Movement Speed" - how much? "+HP Recovery" - how much per second? |
| **Evolution Effects** | Named but not described | What does "Solar Ray of Death" actually do differently from Sun Beam? |
| **Tier 3 Fusions** | Listed but not described | What are the mechanics of "Plasma Storm", "Blood Fortress", etc.? |
| **Evolution Requirements** | Unclear | Level 8 max - is this consistent across all weapons? |

**Missing Evolution Descriptions:**

| Evolution | Missing Description |
|-----------|---------------------|
| Solar Ray of Death | Damage multiplier? Beam width? Penetration? |
| Vampiric Aura | AoE radius? Lifesteal percentage? |
| Earth Shatter | Knockback radius? Damage multiplier? |
| Thunder God's Wrath | Chain count? Damage per chain? |
| Armageddon | Meteor count? Damage per meteor? |
| Holy Flood | Area size? Damage? Duration? |
| Phalanx Wall | Shield count? Block threshold? |
| Orbiting Death Stars | Damage per orb? Orbit count? |
| Artemis' Bow | Damage multiplier? Arrow count? |
| Nemesis Lash | Damage multiplier? Range increase? |
| Pestilence | DoT multiplier? Spread radius? |
| Infinity Disc | Bounce count increase? Damage increase? |

**Tier 3 Fusion Descriptions Missing:**

- Plasma Storm = Thunder God's Wrath + Solar Ray of Death
- Blood Fortress = Vampiric Aura + Phalanx Wall
- Ragnarok = Earth Shatter + Armageddon
- Pandora's Box = Pestilence + Orbiting Death Stars

### 1.4 Section 5: The Mortals (Enemy Progression)

**Issues Identified:**

| Era | Enemy Type | Missing Stats |
|-----|------------|---------------|
| **Stone Age** | Cavemen | HP, damage, movement speed, attack cooldown |
| | Throwers | HP, damage, projectile speed, throw range, throw cooldown |
| **Ancient Era** | Hoplites | HP, damage, shield HP, movement speed |
| | Chariots | HP, damage, charge speed, charge damage, charge cooldown |
| **Medieval Era** | Knights | HP, damage, armor reduction %, movement speed |
| | Archers | HP, damage, arrow speed, attack range, attack cooldown |
| | Priests | HP, heal amount, heal range, heal cooldown |
| **Modern Era** | Soldiers | HP, damage, fire rate, accuracy |
| | Tank | HP, damage, special abilities |
| **Future Era** | Cyborgs | HP, damage, shield HP, special abilities |
| | The Singularity | HP, damage, attack patterns, phases |

**Additional Issues:**

- **Era Transition**: Is it purely time-based, or also level-based? What happens during transition?
- **Spawn Rates**: How many enemies spawn per era? Does spawn rate increase over time?
- **Elite/Mini-Boss Scaling**: What makes them "tougher"?

### 1.5 Section 6: Boss System & Bonus Round

**Issues Identified:**

| Area | Problem | Details |
|------|---------|---------|
| **Mini-Bosses** | "Tougher versions" - undefined | HP multiplier? Damage multiplier? Size increase? |
| **The Singularity** | No mechanics described | Attack patterns? Phases? Weak points? |
| **God Mode Duration** | Unclear | "Fight for 2 minutes" - is this fixed or variable? |
| **Possessed Titan** | No mechanics | HP, damage, attack patterns? |
| **Ambrosia Key** | Drop chance? | Is it guaranteed from Tank? 100%? Random chance? |

### 1.6 Section 7: Meta-Progression & Loot

**Issues Identified:**

| Area | Problem | Details |
|------|---------|---------|
| **Worship System** | Vague | How much XP per run? How many mastery levels? What are the specific stat boosts per level? |
| **Equipment Slots** | Incomplete | What stats can each slot provide? Are there slot-specific restrictions? |
| **Rarity System** | No drop rates | What are the chances for each rarity? |
| **Inventory Management** | Undefined | Max inventory size? Can items be sold? |
| **Save System** | Not detailed | What data is saved? Local vs cloud? |

### 1.7 Section 8: Technical Implementation Plan

**Issues Identified:**

| Area | Problem | Details |
|------|---------|---------|
| **Section Numbering** | Incorrect | Labeled as "Section 6" but should be "Section 8" |
| **GodProfile Structure** | Undefined | What fields does it contain? |
| **Ultimate Resource** | Undecided | "Mana or Rage bar" - which one? What's the max value? How does it fill? |
| **Save System** | Not in implementation plan | When will this be implemented? |
| **UI Implementation** | Missing | When will HUD, inventory, character select be implemented? |
| **Audio Implementation** | Missing | When will music and SFX be integrated? |

---

## Part 2: Missing Gaps

### 2.1 Game Balance & Progression System

**Missing Information:**

| System | Missing Details |
|--------|-----------------|
| **Level-up Curve** | XP required per level formula, max level cap |
| **Stat Scaling** | How do base stats scale per level? |
| **Power Curve** | Expected player power at each era/time marker |
| **Difficulty Scaling** | Does enemy difficulty scale with player level, time, or both? |
| **XP Sources** | How much XP per enemy type? Bonus XP for elites/bosses? |

### 2.2 Difficulty System

**Missing Information:**

| Area | Missing Details |
|-------|-----------------|
| **Difficulty Modes** | Easy, Normal, Hard, Nightmare? |
| **Difficulty Modifiers** | What changes between difficulties? (HP, damage, spawn rates, XP gain) |
| **Unlock System** | Are higher difficulties locked until certain conditions are met? |

### 2.3 Input Controls

**Missing Information:**

| Control | Missing Details |
|---------|-----------------|
| **Keyboard** | Full key binding list (movement, abilities, ultimate, pause, inventory) |
| **Controller** | Button mapping for Xbox/PS/Switch controllers |
| **Remapping** | Can players remap controls? |

### 2.4 UI/UX Design

**Missing Information:**

| UI Element | Missing Details |
|------------|-----------------|
| **HUD Layout** | Where is health bar? XP bar? Ultimate meter? Minimap? Cooldowns? |
| **Level-up Selection** | How are choices presented? 3 cards? Grid? What info is shown? |
| **Inventory Screen** | How do players equip items? Compare stats? Sort/filter? |
| **Character Select** | How are Gods presented? What info is shown before selection? |
| **Pause Menu** | Options available? Resume, restart, quit, settings? |
| **Settings Menu** | Graphics, audio, controls, accessibility options? |

### 2.5 Audio Design

**Missing Information:**

| Audio Category | Missing Details |
|----------------|-----------------|
| **Music Tracks** | How many tracks? Era-specific music? Boss music? God Mode music? |
| **Sound Effects** | Categories needed (weapons, enemies, UI, ambience, footsteps) |
| **Voice Acting** | Do Gods have voice lines? Taunts? Death sounds? |
| **Audio Mixing** | Volume controls for music, SFX, voice |

### 2.6 Performance Targets

**Missing Information:**

| Target | Missing Details |
|--------|-----------------|
| **Frame Rate** | Target FPS (30, 60, 120)? Minimum acceptable FPS? |
| **Enemy Count** | Max enemies on screen? How does this vary by platform? |
| **Platform Targets** | PC specs (minimum/recommended)? Console plans? Mobile? |
| **Loading Times** | Target load times for scene transitions? |

### 2.7 Save System

**Missing Information:**

| Aspect | Missing Details |
|--------|-----------------|
| **Save Data** | What exactly is saved? (Mastery levels, inventory, settings, achievements?) |
| **Save Frequency** | Auto-save interval? Manual save? |
| **Save Slots** | How many save slots? Per God or global? |
| **Cloud Saves** | Steam Cloud support? Cross-platform sync? |
| **Save Format** | JSON, binary, custom format? |

### 2.8 Accessibility Features

**Missing Information:**

| Feature | Missing Details |
|---------|-----------------|
| **Colorblind Modes** | Which types supported? (Protanopia, Deuteranopia, Tritanopia) |
| **Subtitles** | For voice lines? For sound cues? |
| **Control Remapping** | Full remapping or presets? |
| **Visual Aids** | Hit indicators, damage numbers, enemy outlines? |
| **Difficulty Options** | Assist mode? Reduced damage? Increased XP? |

### 2.9 Monetization Strategy

**Missing Information:**

| Aspect | Missing Details |
|--------|-----------------|
| **Business Model** | Free-to-play? Paid? Premium? |
| **DLC Plans** | New Gods? New Eras? Cosmetic packs? |
| **Microtransactions** | If F2P, what's purchasable? |

### 2.10 Multiplayer

**Missing Information:**

| Aspect | Missing Details |
|--------|-----------------|
| **Multiplayer Mode** | Single-player only? Local co-op? Online co-op? PvP? |
| **Sync Issues** | How to handle lag in co-op? |
| **Progression** | Shared or individual progression? |

### 2.11 Platform Strategy

**Missing Information:**

| Platform | Missing Details |
|----------|-----------------|
| **PC** | Steam? Epic? GOG? DRM-free? |
| **Consoles** | PlayStation? Xbox? Switch? |
| **Mobile** | iOS? Android? Touch controls adaptation? |
| **Release Strategy** | Simultaneous release? Staggered? Early Access? |

### 2.12 Technical Constraints

**Missing Information:**

| Constraint | Missing Details |
|------------|-----------------|
| **Godot Version** | Which version? 4.2? 4.3? |
| **Minimum Specs** | CPU, RAM, GPU requirements |
| **Storage** | Game size estimate |
| **Dependencies** | Required plugins/addons |

### 2.13 Visual Style & Art Direction

**Missing Information:**

| Area | Missing Details |
|------|-----------------|
| **Color Palette** | Primary colors for each God? Era-specific color schemes? |
| **Model Specs** | Poly count targets? Texture resolution? |
| **VFX Guidelines** | Particle count limits? Visual clarity priorities? |
| **Animation Style** | Exaggerated? Realistic? Mix? |

### 2.14 Game Loop Flow

**Missing Information:**

| Phase | Missing Details |
|-------|-----------------|
| **Main Menu** | What options available? (Play, Settings, Credits, Exit) |
| **Character Select** | Flow details - can players see stats before choosing? |
| **Arena Entry** | Is there a briefing? Loadout confirmation? |
| **Run Completion** | What happens on death? Victory screen? Results summary? |
| **Return to Menu** | What stats are shown? How to start new run? |

### 2.15 Achievement System

**Missing Information:**

| Area | Missing Details |
|------|-----------------|
| **Achievement Types** | Completionist? Challenge? Progression? |
| **Platform Integration** | Steam Achievements? Xbox Achievements? PlayStation Trophies? |
| **Rewards** | Do achievements unlock anything? (Cosmetics, bonuses) |

---

## Part 3: Inconsistencies & Conflicts

### 3.1 Code vs GDD Mismatches

| GDD Statement | Code Reality | Issue |
|----------------|--------------|-------|
| "Era System" with time-based progression | Simple random spawn system in `EnemyManager` | Era system not implemented |
| Three Gods (Zeus, Odin, Ra) | Single generic `Player` class | God system not implemented |
| "Mana or Rage bar" for ultimates | No ultimate resource in code | Ultimate system not implemented |
| Era-specific enemies (Cavemen, Hoplites, etc.) | Only generic skeleton enemies (Minion, Warrior, Archer, Mage, Boss) | Enemy types don't match GDD |

### 3.2 Internal GDD Inconsistencies

| Section | Inconsistency |
|---------|---------------|
| Section numbering | Section 6 appears twice (Boss System and Technical Implementation) |
| Era transitions | Section 5 says time-based, but also mentions "based on player level" |
| God Mode | Section 6 says "XP Piñata" gives +20 levels, but no max level is defined |

---

## Part 4: Priority Recommendations

### High Priority (Critical for Implementation)

1. **Define all ability stats** - damage, cooldowns, ranges, durations
2. **Define enemy stats** - HP, damage, movement speed per enemy type
3. **Clarify evolution mechanics** - what exactly changes when weapons evolve
4. **Define the Era system** - how it works, how it integrates with existing spawn system
5. **Define God profiles** - structure and contents for each God

### Medium Priority (Important for Polish)

1. **Define UI/UX** - mockups and flow for all screens
2. **Define save system** - what data, when, how
3. **Define difficulty system** - modes and modifiers
4. **Define mastery system** - specific stat boosts per level
5. **Define equipment system** - slot restrictions, stat ranges per rarity

### Low Priority (Nice to Have)

1. **Accessibility features** - specific implementations
2. **Achievement system** - list and rewards
3. **Audio design** - track list and SFX categories
4. **Platform strategy** - specific platforms and release timeline

---

## Part 5: Suggested Additions to GDD

### New Sections to Add

1. **Section 8.5: Ability Stat Reference Tables** - Complete stat tables for all abilities
2. **Section 9: Enemy Stat Reference** - Complete stat tables for all enemy types
3. **Section 10: UI/UX Design** - Mockups and flow descriptions
4. **Section 11: Save System Specification** - Data structures and save logic
5. **Section 12: Difficulty & Balance** - Difficulty modes and balance targets
6. **Section 13: Accessibility Options** - Specific accessibility features
7. **Section 14: Technical Specifications** - Performance targets and constraints
8. **Section 15: Asset Specifications** - Art, audio, and VFX guidelines

---

## Conclusion

The GDD provides a strong high-level vision for "Gods vs Mortals" with an interesting theme and core mechanics. However, significant work is needed to fill in the quantitative details required for actual implementation. The most critical gaps are in ability statistics, enemy statistics, and the evolution system mechanics.

The current codebase is a basic survivor game starter kit that does not yet reflect the GDD's vision. Bridging this gap will require substantial development work, particularly in implementing the Era system, God character system, and weapon evolution mechanics.

---

*Document Version: 1.0*
*Last Updated: 2026-01-19*
