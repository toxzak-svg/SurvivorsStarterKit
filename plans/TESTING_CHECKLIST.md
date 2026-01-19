# Testing Checklist - Gods vs Mortals

## Comprehensive Testing Plan

---

## Phase 0: Prototype Validation Tests

### Functional Tests
- [ ] **Basic Movement**: Player character moves in all directions (WASD)
- [ ] **Enemy Spawning**: Cavemen spawn at 1.0 enemies/second rate
- [ ] **Enemy AI**: Enemies path toward player correctly
- [ ] **Projectile Attack**: Thunderbolt fires at nearest enemy
- [ ] **Damage System**: Enemies take damage, player takes damage
- [ ] **Death System**: Enemies die at 0 HP, player dies at 0 HP
- [ ] **XP System**: XP orbs drop from enemies, player collects them
- [ ] **Level Up**: Player levels up at XP threshold
- [ ] **Upgrade System**: Upgrade UI appears, selecting upgrade applies stats

### Performance Tests
- [ ] **Baseline Performance**: 60 FPS with 0 enemies
- [ ] **Enemy Scaling**: 60 FPS with 50 enemies
- [ ] **Enemy Scaling**: 60 FPS with 100 enemies
- [ ] **Enemy Scaling**: Measure FPS with 150 enemies
- [ ] **Memory Usage**: Monitor memory usage over 5-minute run
- [ ] **Load Time**: Game loads in under 3 seconds

### Core Loop Validation
- [ ] **Complete Run**: Play for 2 minutes, observe era progression
- [ ] **Death**: Player dies, game over screen appears
- [ ] **Restart**: Can restart game after death

**Acceptance Criteria**: 60 FPS with 100 enemies, all functional tests pass

---

## Phase 1: Architecture Tests

### EraManager Tests
- [ ] **Time Tracking**: GameTime increments correctly in _Process
- [ ] **Era Transitions**: Era changes at 4:00, 8:00, 12:00, 16:00
- [ ] **Enemy Pool**: Correct enemies spawn per era
- [ ] **Spawn Rate Scaling**: Spawn rate increases per era
- [ ] **Stat Scaling**: Enemy HP/damage/speed scale correctly

### SaveManager Tests
- [ ] **Save Creation**: New save file created successfully
- [ ] **Save Loading**: Save file loads correctly
- [ ] **JSON Serialization**: All data structures serialize to JSON
- [ ] **JSON Deserialization**: All data structures deserialize from JSON
- [ ] **Auto-Save**: Auto-save triggers after run completion
- [ ] **Manual Save**: Manual save creates file in correct slot
- [ ] **Save Corruption**: Corrupt save file is handled gracefully

### ResourceManager Tests
- [ ] **GodProfile Loading**: Zeus/Odin/Ra profiles load correctly
- [ ] **EraDefinition Loading**: All 5 era definitions load correctly
- [ ] **WeaponDefinition Loading**: All weapon definitions load correctly
- [ ] **Missing Resource**: Missing resource returns null/default

### AbilityManager Tests
- [ ] **Divine Energy Gain**: +1 per normal kill, +5 per elite, +20 per boss
- [ ] **Divine Energy Cap**: Energy stops at 100
- [ ] **Ultimate Activation**: Ultimate activates when Energy >= 100
- [ ] **Ultimate Cooldown**: 30s cooldown applied after activation
- [ ] **Cooldown Tracking**: Ability cooldowns decrement correctly

### UIManager Tests
- [ ] **State Management**: State changes (Playing, Paused, Upgrade, GameOver)
- [ ] **HUD References**: All HUD elements are accessible
- [ ] **UI Updates**: UI updates correctly on state changes

---

## Phase 3: Era System Tests

### Stone Age Tests
- [ ] **Caveman Spawning**: Cavemen spawn in Stone Age era
- [ ] **Caveman Stats**: HP 50, Damage 10, Speed 2.0
- [ ] **Rock Thrower Spawning**: Rock Throwers spawn in Stone Age era
- [ ] **Rock Thrower Stats**: HP 35, Damage 8, Speed 1.8
- [ ] **Projectile Attack**: Rock Throwers throw rock projectiles

### Ancient Era Tests
- [ ] **Hoplite Spawning**: Hoplites spawn in Ancient era
- [ ] **Hoplite Shield**: First hit blocked by 20 HP shield
- [ ] **Chariot Spawning**: Chariots spawn in Ancient era
- [ ] **Chariot Charge**: Chariots perform charge attacks

### Medieval Era Tests
- [ ] **Knight Spawning**: Knights spawn in Medieval era
- [ ] **Knight DR**: Knights have 25% physical damage reduction
- [ ] **Archer Spawning**: Archers spawn in Medieval era
- [ ] **Archer Ranged**: Archers fire arrows from distance
- [ ] **Priest Spawning**: Priests spawn in Medieval era
- [ ] **Priest Healing**: Priests heal nearby allies

### Modern Era Tests
- [ ] **Soldier Spawning**: Soldiers spawn in Modern era
- [ ] **Soldier Fire Rate**: Soldiers fire in 3-round bursts
- [ ] **Tank Spawning**: Tank spawns as mini-boss at 12:00
- [ ] **Tank Key Drop**: Tank drops Ambrosia Key 100%

### Future Era Tests
- [ ] **Cyborg Spawning**: Cyborgs spawn in Future era
- [ ] **Cyborg Shield**: Cyborgs have 50 HP energy shield that regenerates
- [ ] **Singularity Spawning**: Singularity spawns at 20:00

---

## Phase 4: Boss System Tests

### Elite/Mini-Boss Tests
- [ ] **Spawn Timing**: Elites spawn at 4:00, 8:00, 12:00
- [ ] **Health Multiplier**: Elites have 3x base enemy HP
- [ ] **Damage Multiplier**: Elites have 2x base enemy damage
- [ ] **Size Multiplier**: Elites are 1.5x normal size
- [ ] **Tribute Chest Drop**: Tribute Chest drops 100%

### The Singularity Tests
- [ ] **Phase 1 Trigger**: Phase 1 active at 100-70% HP
- [ ] **Phase 1 Pattern**: Rotating laser beams
- [ ] **Phase 2 Trigger**: Phase 2 active at 70-40% HP
- [ ] **Phase 2 Pattern**: Homing missiles
- [ ] **Phase 3 Trigger**: Phase 3 active at 40-0% HP
- [ ] **Phase 3 Pattern**: Bullet hell + lasers + Cyborg spawns

### God Mode Tests
- [ ] **Key Check**: God Mode triggers only if player has Ambrosia Key
- [ ] **XP Piñata**: +20 levels instantly from boss explosion
- [ ] **Damage Buff**: +500% damage applied
- [ ] **Cooldown Buff**: -80% cooldown applied
- [ ] **Titan Spawn**: Possessed Titan spawns
- [ ] **Titan Attacks**: Slam, beam, summon patterns work correctly
- [ ] **Titan Defeat**: Divine Artifact rewarded

---

## Phase 5: Divine Energy Tests

### Divine Energy Tests
- [ ] **Normal Kill**: +1 Divine Energy
- [ ] **Elite Kill**: +5 Divine Energy
- [ ] **Boss Kill**: +20 Divine Energy
- [ ] **Energy Cap**: Energy stops at 100
- [ ] **UI Display**: Divine Energy bar updates correctly

### Ultimate Tests
- [ ] **Zeus Ultimate**: Olympus Wrath activates correctly
- [ ] **Odin Ultimate**: Wild Hunt activates correctly
- [ ] **Ra Ultimate**: Supernova activates correctly
- [ ] **Cooldown**: 30s cooldown applied
- [ ] **Energy Consumption**: Energy set to 0 after activation

---

## Phase 6-9: Ability Tests (Per Ability)

### Zeus Abilities
- [ ] **Thunderbolt**: Fires at nearest enemy, deals 25 damage, pierces 3
- [ ] **Chain Lightning**: Chains 5 enemies, damage decays 20% per arc
- [ ] **Thunderclap**: Stuns enemies in 6 unit radius for 0.5s
- [ ] **Storm Cloud**: Cloud lasts 10s, strikes every 1.5s

### Odin Abilities
- [ ] **Gungnir**: Outbound pierces 2, return infinite pierce
- [ ] **Raven Scouts**: 2 ravens orbit, peck every 0.8s
- [ ] **Rune Trap**: 3 traps placed, 50 damage on trigger
- [ ] **Wolves of War**: 2 wolves chase, 25 damage per bite

### Ra Abilities
- [ ] **Sun Beam**: Continuous beam, 15 DPS at 10 ticks/sec
- [ ] **Solar Flare**: 35 damage, 50% blind, 30% slow
- [ ] **Obelisk**: Fires bolt every 0.6s, 20 damage
- [ ] **Desert Heat**: +50% burn damage/duration

### Generic Abilities
- [ ] **Aegis Shield**: Blocks projectiles, 15 contact damage
- [ ] **Titanic Stomp**: 45 damage, 5 unit knockback
- [ ] **Divine Arrow**: Homing, pierces 2 enemies
- [ ] **Plague of Locusts**: 20 locusts, 3 DPS for 6s
- [ ] **Meteor Shower**: 3 meteors, 30 damage each
- [ ] **Cyclone Blade**: 3 blades, 20 damage each
- [ ] **Frost Orb**: 25 damage, 40% slow
- [ ] **Chain Whip**: 40 damage in 8 unit line
- [ ] **Ricochet Chakram**: 5 bounces, 28 damage

---

## Phase 10: Passive Blessings Tests
- [ ] **Hermes' Sandals**: +15% movement speed per stack
- [ ] **Ambrosia**: +5 HP recovery/sec, +20 Max HP per stack
- [ ] **Hercules' Gauntlet**: +10% damage per stack
- [ ] **Chronos' Hourglass**: -10% cooldowns per stack
- [ ] **Apollo's Lens**: +15% area of effect per stack
- [ ] **Midas' Touch**: +15% Gold/XP gain per stack
- [ ] **Aegis Fragment**: +5 armor per stack
- [ ] **Magnet Stone**: +20% pickup range per stack
- [ ] **Oracle's Eye**: +5% crit chance per stack
- [ ] **Berserker's Blood**: +10% attack speed per stack
- [ ] **Alchemist's Flask**: +20% duration per stack
- [ ] **Gemini Twin**: +1 projectile per stack

---

## Phase 11-12: Evolution Tests

### Tier 2 Evolution Tests
- [ ] **Evolution Trigger**: Weapon at level 8 + passive level 1 + chest
- [ ] **Sun Beam → Solar Ray of Death**: +100% damage, penetrates
- [ ] **Lifesteal → Vampiric Aura**: Passive AoE healing
- [ ] **Titanic Stomp → Earth Shatter**: +150% damage, damage field
- [ ] **Thunderbolt → Thunder God's Wrath**: +200% damage, electrified trail
- [ ] **Meteor Shower → Armageddon**: +2 meteors, burning ground
- [ ] **Spirit Water → Holy Flood**: Wave, knockback, heal
- [ ] **Aegis Shield → Phalanx Wall**: +2 shields, formation
- [ ] **Floating Sphere → Orbiting Death Stars**: +2 spheres, explode
- [ ] **Divine Arrow → Artemis' Bow**: 3 arrows, spread
- [ ] **Chain Whip → Nemesis Lash**: 180 degree arc
- [ ] **Plague of Locusts → Pestilence**: Locusts spread
- [ ] **Ricochet Chakram → Infinity Disc**: Infinite bounces

### Tier 3 Fusion Tests
- [ ] **Fusion Trigger**: Two evolved weapons + chest
- [ ] **Plasma Storm**: Storm follows player, 50 DPS
- [ ] **Blood Fortress**: 6 shields, 20% lifesteal
- [ ] **Ragnarok**: Earthquake + meteors for 20s
- [ ] **Pandora's Box**: 5 explosive orbs, locust swarm

---

## Phase 13: Mastery System Tests
- [ ] **Worship XP Calculation**: Correct XP awarded per run
- [ ] **Mastery Level Up**: Levels 1-50 progress correctly
- [ ] **Mastery Rewards**: Correct stats applied per level range
- [ ] **Buff Application**: Mastery buffs applied at run start
- [ ] **Progress Tracking**: XP and level display correctly

---

## Phase 15: Save System Tests

### Save/Load Tests
- [ ] **Complete Save**: All data saved correctly
- [ ] **Complete Load**: All data loaded correctly
- [ ] **Incremental Save**: Updates save without corruption
- [ ] **Multiple Slots**: 3 save slots work independently
- [ ] **Auto-Save Triggers**: Auto-save after run completion
- [ ] **Manual Save**: Manual save works from menu
- [ ] **Corrupt Recovery**: Corrupt file handled gracefully

### Data Integrity Tests
- [ ] **Mastery Data**: Mastery levels and XP persist
- [ ] **Inventory Data**: Items persist correctly
- [ ] **Achievement Data**: Achievements persist correctly
- [ ] **Settings Data**: Settings persist correctly
- [ ] **Global Stats**: Run statistics persist correctly

---

## Phase 16: Character Selection Tests
- [ ] **God Profiles**: All 3 God profiles load correctly
- [ ] **God Selection**: Selecting God applies correct stats
- [ ] **Mastery Display**: Mastery level displays correctly
- [ ] **Difficulty Selection**: All difficulty modes selectable
- [ ] **Unlock Conditions**: Locked difficulties show unlock requirements

---

## Phase 17: UI/UX Tests

### HUD Tests
- [ ] **Level Display**: Level updates correctly
- [ ] **Time Display**: Game time shows correctly (MM:SS format)
- [ ] **Health Bar**: Health bar updates on damage/heal
- [ ] **XP Bar**: XP bar updates on XP gain
- [ ] **Divine Energy Bar**: Divine Energy bar updates on energy gain
- [ ] **Ability Icons**: Ability icons show correctly
- [ ] **Cooldown Indicators**: Cooldown timers display correctly

### Level-up UI Tests
- [ ] **Upgrade Display**: 3 cards display correctly
- [ ] **Selection**: Click or 1/2/3 keys select upgrade
- [ ] **Stat Changes**: Green for positive, red for negative
- [ ] **Description**: Ability descriptions display correctly

### Era Indicator Tests
- [ ] **Current Era**: Current era displays correctly
- [ ] **Progression Bar**: Visual progression through eras
- [ ] **Time Remaining**: Time until next era displays

---

## Phase 20: Performance Tests

### Stress Tests
- [ ] **200 Enemies**: 60 FPS maintained with 200 enemies
- [ ] **300 Enemies**: 60 FPS maintained with 300 enemies
- [ ] **All Abilities**: 60 FPS with all abilities active
- [ ] **Long Run**: No memory leaks after 20-minute run
- [ ] **Object Pooling**: Pool reduces instantiation overhead

### Optimization Tests
- [ ] **LOD System**: Distant enemies use simplified models
- [ ] **Batch Rendering**: Draw calls reduced by batching
- [ ] **Physics Optimization**: Physics tick rate appropriate
- [ ] **Spatial Partitioning**: Collision detection efficient

---

## Phase 24: Integration Tests

### Complete Run Tests
- [ ] **Full 20-Minute Run**: Complete run from start to finish
- [ ] **All Eras**: Progress through all 5 eras
- [ ] **All Bosses**: Defeat all bosses (elites + Singularity)
- [ ] **God Mode**: Complete God Mode bonus round
- [ ] **Victory Screen**: Victory screen displays correctly
- [ ] **Game Over**: Game Over screen displays correctly

### Save/Load Integration Tests
- [ ] **Save Mid-Run**: Save during run, reload, continue
- [ ] **Mastery Integration**: Mastery buffs apply correctly
- [ ] **Inventory Integration**: Items load correctly

### Difficulty Integration Tests
- [ ] **Easy Mode**: Easy modifiers apply correctly
- [ ] **Normal Mode**: Normal modifiers apply correctly
- [ ] **Hard Mode**: Hard modifiers apply correctly
- [ ] **Nightmare Mode**: Nightmare modifiers apply correctly

---

## Regression Tests
- [ ] **Core Loop**: Core loop still functional after major changes
- [ ] **No Performance Regressions**: FPS maintained
- [ ] **No Save Regressions**: Save/load still works
- [ ] **No Balance Regressions**: Game still balanced

---

## Platform Tests
- [ ] **Windows 10**: Runs correctly on Windows 10
- [ ] **Windows 11**: Runs correctly on Windows 11
- [ ] **Minimum Spec**: Runs on minimum spec hardware
- [ ] **Recommended Spec**: Runs smoothly on recommended hardware

---

## Accessibility Tests
- [ ] **Colorblind Modes**: All modes work correctly
- [ ] **Damage Numbers**: Toggle and size adjustment work
- [ ] **Enemy Health Bars**: Toggle works for elites/bosses
- [ ] **Hit Indicators**: Screen flash on player damage
- [ ] **Key Remapping**: All keys remappable
- [ ] **Controller Support**: Controller input works

---

## Test Execution Log

| Date | Tester | Phase | Test Type | Result | Notes |
|------|---------|-------|-----------|--------|-------|
|      |        |       |           |        |       |

---

**Document Version**: 1.0
**Last Updated**: 2026-01-19
**Next Review**: Before Phase 1 completion