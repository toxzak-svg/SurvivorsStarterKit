# GDD System Diagrams: Gods vs Mortals

## Overview

This document contains visual diagrams for the complex systems in "Gods vs Mortals" using Mermaid syntax.

---

## Diagram 1: Era Progression System

```mermaid
graph TD
    A[Game Start] --> B[Stone Age Era]
    B -->|4:00| C[Ancient Era]
    C -->|8:00| D[Medieval Era]
    D -->|12:00| E[Modern Era]
    E -->|16:00| F[Future Era]
    F -->|20:00| G[The Singularity Boss]

    B --> B1[Spawn: Caveman, Thrower]
    B --> B2[Base Spawn Rate: 1.0/s]
    B --> B3[HP Multiplier: 1.0x]

    C --> C1[Spawn: Hoplite, Chariot]
    C --> C2[Base Spawn Rate: 1.5/s]
    C --> C3[HP Multiplier: 1.5x]

    D --> D1[Spawn: Knight, Archer, Priest]
    D --> D2[Base Spawn Rate: 2.0/s]
    D --> D3[HP Multiplier: 2.0x]

    E --> E1[Spawn: Soldier, Tank Mini-Boss]
    E --> E2[Base Spawn Rate: 2.5/s]
    E --> E3[HP Multiplier: 2.5x]

    F --> F1[Spawn: Cyborg]
    F --> F2[Base Spawn Rate: 3.0/s]
    F --> F3[HP Multiplier: 3.0x]

    G --> H{Boss Defeated?}
    H -->|No| I[Game Over]
    H -->|Yes| J{Have Ambrosia Key?}
    J -->|No| K[Victory Screen]
    J -->|Yes| L[God Mode Bonus Round]
    L --> M{Possessed Titan Defeated?}
    M -->|No| I
    M -->|Yes| N[Divine Artifact Reward]
    N --> K

    style B fill:#8B4513
    style C fill:#DAA520
    style D fill:#708090
    style E fill:#4169E1
    style F fill:#9400D3
    style G fill:#FF0000
    style L fill:#FFD700
```

---

## Diagram 2: Weapon Evolution System

```mermaid
graph LR
    subgraph Level1[Base Weapons]
        A1[Thunderbolt]
        A2[Gungnir]
        A3[Sun Beam]
        A4[Aegis Shield]
        A5[Titanic Stomp]
        A6[Divine Arrow]
        A7[Plague of Locusts]
        A8[Meteor Shower]
        A9[Cyclone Blade]
        A10[Frost Orb]
        A11[Chain Whip]
        A12[Ricochet Chakram]
        A13[Lifesteal]
        A14[Spirit Water]
        A15[Floating Sphere]
    end

    subgraph Passives[Passive Blessings]
        P1[Hermes Sandals]
        P2[Ambrosia]
        P3[Hercules Gauntlet]
        P4[Chronos Hourglass]
        P5[Apollo Lens]
        P6[Midas Touch]
        P7[Aegis Fragment]
        P8[Magnet Stone]
        P9[Oracle Eye]
        P10[Berserker Blood]
        P11[Alchemist Flask]
        P12[Gemini Twin]
    end

    subgraph Level2[Evolved Weapons]
        E1[Solar Ray of Death]
        E2[Vampiric Aura]
        E3[Earth Shatter]
        E4[Thunder Gods Wrath]
        E5[Armageddon]
        E6[Holy Flood]
        E7[Phalanx Wall]
        E8[Orbiting Death Stars]
        E9[Artemis Bow]
        E10[Nemesis Lash]
        E11[Pestilence]
        E12[Infinity Disc]
    end

    subgraph Level3[Divine Fusions]
        F1[Plasma Storm]
        F2[Blood Fortress]
        F3[Ragnarok]
        F4[Pandoras Box]
    end

    A3 -.->|Level 8 + P1| E1
    A13 -.->|Level 8 + P2| E2
    A5 -.->|Level 8 + P3| E3
    A1 -.->|Level 8 + P4| E4
    A8 -.->|Level 8 + P5| E5
    A14 -.->|Level 8 + P6| E6
    A4 -.->|Level 8 + P7| E7
    A15 -.->|Level 8 + P8| E8
    A6 -.->|Level 8 + P9| E9
    A11 -.->|Level 8 + P10| E10
    A7 -.->|Level 8 + P11| E11
    A12 -.->|Level 8 + P12| E12

    E4 & E1 -->|Tribute Chest| F1
    E2 & E7 -->|Tribute Chest| F2
    E3 & E5 -->|Tribute Chest| F3
    E11 & E8 -->|Tribute Chest| F4

    style Level1 fill:#E0E0E0
    style Level2 fill:#90EE90
    style Level3 fill:#FFD700
    style Passives fill:#ADD8E6
```

---

## Diagram 3: Divine Energy (Ultimate) System

```mermaid
stateDiagram-v2
    [*] --> Charging

    Charging --> Full: Divine Energy >= 100
    Full --> Ready: Ultimate Available
    Ready --> Activating: Player presses Ultimate Key
    Activating --> Active: Ultimate Effect Triggers
    Active --> Cooldown: Ultimate Ends
    Cooldown --> Charging: Cooldown Complete

    note right of Charging
        Gain 1 Energy per enemy kill
        +5 for Elites
        +20 for Bosses
    end note

    note right of Active
        Zeus: Olympus Wrath (5s)
        Odin: Wild Hunt (6s)
        Ra: Supernova (5s)
    end note

    note right of Cooldown
        30 second cooldown
        before next use
    end note
```

---

## Diagram 4: Meta-Progression (Mastery) System

```mermaid
graph TD
    A[Complete Run] --> B{Run Outcome}
    B -->|Death or Victory| C[Calculate Worship XP]

    C --> D[Base: 100 XP]
    C --> E[Per Minute: +10 XP]
    C --> F[Per Era: +50 XP]
    C --> G[Boss Kill: +100 XP]
    C --> H[Final Boss: +200 XP]

    D & E & F & G & H --> I[Total Worship XP]

    I --> J[Add to Current God's Mastery]
    J --> K{Level Up?}
    K -->|Yes| L[Grant Mastery Reward]
    K -->|No| M[Save Progress]

    L --> N[Level 1-10: +2 Max HP]
    L --> O[Level 11-20: +1% Damage]
    L --> P[Level 21-30: +0.5% Speed]
    L --> Q[Level 31-40: +1% XP Gain]
    L --> R[Level 41-50: +2% Ultimate Charge]

    N & O & P & Q & R --> M

    M --> S[Save to File]

    style C fill:#ADD8E6
    style L fill:#90EE90
    style M fill:#FFD700
```

---

## Diagram 5: Equipment & Loot System

```mermaid
graph TD
    A[Enemy/Boss Death] --> B{Is Elite or Boss?}
    B -->|No| C[Drop Chance: 5%]
    B -->|Yes| D[Drop Chance: 100%]

    C --> E[RNG Roll for Rarity]
    D --> E

    E --> F[Common: 60%]
    E --> G[Uncommon: 25%]
    E --> H[Rare: 10%]
    E --> I[Epic: 4%]
    E --> J[Divine: 1%]

    F & G & H & I & J --> K[Generate Item]
    K --> L{Slot Type}
    L --> M[Head]
    L --> N[Body]
    L --> O[Weapon Accessory]
    L --> P[Relic]

    M --> Q[Generate Stats]
    N --> Q
    O --> Q
    P --> Q

    Q --> R[Add to Inventory]
    R --> S[Display Loot Notification]

    T[Player Opens Inventory] --> U[View All Items]
    U --> V[Select Item]
    V --> W{Equip?}
    W -->|Yes| X[Apply Stats to God]
    W -->|No| Y[Keep in Inventory]
    W -->|Sell| Z[Get Gold]

    X --> AA[Save Equipped State]

    style F fill:#808080
    style G fill:#228B22
    style H fill:#4169E1
    style I fill:#9400D3
    style J fill:#FFD700
```

---

## Diagram 6: Game Loop Flow

```mermaid
graph TD
    A[Main Menu] --> B[Select Difficulty]
    B --> C[Select God]
    C --> D[View Loadout]
    D --> E[Start Run]

    E --> F[Initialize Game State]
    F --> G[Spawn Player]
    G --> H[Start Era 1]

    H --> I{Game Loop}
    I --> J[Process Input]
    I --> K[Update Player]
    I --> L[Update Abilities]
    I --> M[Spawn Enemies]
    I --> N[Update Enemies]
    I --> O[Check Collisions]
    I --> O2[Update Game Time]

    J & K & L & M & N & O & O2 --> P{Player Dead?}
    P -->|Yes| Q[Game Over Screen]
    P -->|No| R{Era Change?}
    R -->|Yes| S[Update Era]
    R -->|No| T{Level Up?}
    T -->|Yes| U[Pause Game]
    U --> V[Show Upgrade Choices]
    V --> W[Player Selects Upgrade]
    W --> X[Apply Upgrade]
    X --> Y[Resume Game]

    S --> I
    T -->|No| Z{Final Boss Time?}
    Z -->|Yes| AA[Spawn The Singularity]
    AA --> AB[Boss Fight]
    AB --> AC{Boss Defeated?}
    AC -->|No| I
    AC -->|Yes| AD{Have Key?}
    AD -->|No| AE[Victory Screen]
    AD -->|Yes| AF[God Mode]
    AF --> AG[Fight Possessed Titan]
    AG --> AH{Titan Defeated?}
    AH -->|No| Q
    AH -->|Yes| AI[Reward Divine Artifact]
    AI --> AE

    Z -->|No| I

    Q --> AJ[Calculate Worship XP]
    AE --> AJ
    AJ --> AK[Save Progress]
    AK --> A

    style E fill:#90EE90
    style Q fill:#FF6347
    style AE fill:#FFD700
    style AF fill:#FF4500
```

---

## Diagram 7: God Character System Architecture

```mermaid
classDiagram
    class Player {
        +uint MaxLifepoints
        +float Speed
        +float JumpVelocity
        +uint Lifepoints
        +float gravity
        +TakeDamages uint
        +Heal uint
    }

    class GodProfile {
        +string GodName
        +string Pantheon
        +string Archetype
        +GodStats BaseStats
        +PassiveAbility StartingPassive
        +Weapon StartingWeapon
        +List~Weapon~ UniqueAbilities
        +UltimateAbility Ultimate
    }

    class GodStats {
        +uint MaxHP
        +float MovementSpeed
        +float DamageMultiplier
        +float XPRange
        +float DamageReduction
    }

    class PassiveAbility {
        +string Name
        +string Description
        +PassiveType Type
        +float Value
    }

    class Weapon {
        +string Name
        +WeaponType Type
        +float Damage
        +float Cooldown
        +float Range
        +int PierceCount
        +int MaxLevel
    }

    class UltimateAbility {
        +string Name
        +float Duration
        +int DivineEnergyCost
        +UltimatePattern Pattern
    }

    class DivineEnergy {
        +int CurrentEnergy
        +int MaxEnergy
        +GainEnergy int
        +ConsumeEnergy int
    }

    Player --> GodProfile : uses
    GodProfile --> GodStats : contains
    GodProfile --> PassiveAbility : has
    GodProfile --> Weapon : starts with
    GodProfile --> UltimateAbility : has
    Player --> DivineEnergy : manages
```

---

## Diagram 8: Enemy Spawning System

```mermaid
graph TD
    A[EraManager] --> B[Current Era]
    B --> C[EraDefinition]

    C --> D[Enemy Pool]
    C --> E[Spawn Rate Multiplier]
    C --> F[Enemy Stats Multipliers]

    D --> G[EnemyManager]
    E --> G
    F --> G

    G --> H[Spawn Timer]
    H --> I{Spawn Timer Expired?}
    I -->|No| H
    I -->|Yes| J{Max Enemies Reached?}
    J -->|Yes| H
    J -->|No| K[Select Random Enemy from Pool]
    K --> L[Calculate Spawn Position]
    L --> M[Apply Era Multipliers to Stats]
    M --> N[Instantiate Enemy]
    N --> O[Add to Active Enemies List]
    O --> P[Reset Spawn Timer]
    P --> H

    Q[Enemy Killed] --> R[Remove from Active List]
    R --> S[Grant XP to Player]
    S --> T[Grant Divine Energy]

    style A fill:#ADD8E6
    style C fill:#90EE90
    style G fill:#FFD700
```

---

## Diagram 9: Level-Up Upgrade System

```mermaid
sequenceDiagram
    participant GM as GameManager
    participant P as Player
    participant UV as UpgradeView
    participant U as User

    GM->>GM: Enemy Killed
    GM->>GM: Add XP
    GM->>GM: XP >= MaxXP?
    alt Level Up
        GM->>GM: PlayerLevel++
        GM->>GM: Update MaxXP
        GM->>GM: Pause Game
        GM->>UV: DisplayPowerups()
        UV->>U: Show 3 Upgrade Choices
        U->>UV: Select Choice
        UV->>GM: OnChoose(Choice)
        GM->>P: Apply Powerup
        GM->>GM: Apply EnemyPowerup
        GM->>GM: Reset XP
        GM->>GM: Resume Game
    end
```

---

## Diagram 10: Save System Flow

```mermaid
graph TD
    A[Game Event Trigger] --> B{Save Event?}
    B -->|Run Complete| C[Auto-Save]
    B -->|Manual Save| D[Manual Save Request]
    B -->|Settings Change| E[Save Settings Only]

    C --> F[Collect Save Data]
    D --> F
    E --> G[Collect Settings Data]

    F --> H[Gather God Data]
    F --> I[Gather Inventory Data]
    F --> J[Gather Global Stats]

    H & I & J --> K[Serialize to JSON]
    G --> K

    K --> L[Write to Save File]
    L --> M[Update Last Save Time]

    N[Game Load] --> O[Read Save File]
    O --> P[Deserialize JSON]
    P --> Q[Apply God Data]
    P --> R[Apply Inventory Data]
    P --> S[Apply Settings]
    P --> T[Apply Global Stats]

    Q & R & S & T --> U[Game Ready]

    style C fill:#90EE90
    style D fill:#ADD8E6
    style E fill:#FFD700
```

---

*Document Version: 1.0*
*Last Updated: 2026-01-19*
