---
title: RPG
tags:
  - sample
  - game
  - example

status: draft
---


## Overview

| Property | Value |
|----------|-------|
| **Genre** | RPG |
| **Platforms** | Desktop, Web |
| **Features** | Inventory, dialogues, quests |

## Description

Top-down RPG featuring turn-based combat, inventory management, dialogue system, and quest tracking. Demonstrates complex game state and data management.

## Gameplay

- Explore tile-based world
- Talk to NPCs for quests and information
- Fight enemies in turn-based combat
- Collect and equip items
- Complete quests to progress story

## Architecture

```
Rpg/
├── Program.cs
├── RpgGame.cs
├── States/
│   ├── MenuState.cs
│   ├── PlayState.cs
│   ├── CombatState.cs
│   ├── InventoryState.cs
│   └── DialogueState.cs
├── Entities/
│   ├── Player.cs
│   ├── NPC.cs
│   ├── Enemy.cs
│   └── Item.cs
├── Systems/
│   ├── MovementSystem.cs
│   ├── DialogueSystem.cs
│   ├── CombatSystem.cs
│   ├── InventorySystem.cs
│   └── QuestSystem.cs
├── Data/
│   ├── Items.json
│   ├── Enemies.json
│   ├── Dialogues.json
│   └── Quests.json
└── Content/
    ├── Tilesets/
    ├── Sprites/
    └── Audio/
```

## Key Components

### Player Component

```csharp
public struct PlayerComponent
{
    public string Name;
    public int Level;
    public int Experience;
    public int Health;
    public int MaxHealth;
    public int Mana;
    public int MaxMana;
    public int Attack;
    public int Defense;
    public int Gold;
}
```

### NPC Component

```csharp
public struct NPCComponent
{
    public string Name;
    public string DialogueId;
    public bool HasQuest;
    public string QuestId;
    public bool QuestCompleted;
}
```

### Enemy Component

```csharp
public struct EnemyComponent
{
    public string Name;
    public int Level;
    public int Health;
    public int MaxHealth;
    public int Attack;
    public int Defense;
    public int ExperienceReward;
    public int GoldReward;
    public EnemyType Type;
}
```

### Inventory Component

```csharp
public struct InventoryComponent
{
    public List<ItemStack> Items;
    public int MaxSlots;
    public EquipmentSlot[] Equipment;
}

public struct ItemStack
{
    public Item Item;
    public int Quantity;
}

public enum EquipmentSlot
{
    Head,
    Chest,
    Legs,
    Feet,
    Weapon,
    Shield,
    Accessory
}
```

## Dialogue System

```csharp
public class DialogueSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        if (!dialogueActive) return;
        
        var currentNode = dialogueTree.GetCurrentNode();
        
        // Display dialogue
        DrawDialogueBox(currentNode.Speaker, currentNode.Text, currentNode.Choices);
        
        // Handle input
        if (Input.IsKeyPressed(Keys.Enter) || Input.IsMouseButtonPressed(MouseButton.Left))
        {
            if (currentNode.Choices.Length == 0)
            {
                // No choices, advance
                if (!dialogueTree.Advance())
                {
                    EndDialogue(world);
                }
            }
        }
        
        // Handle choices
        for (int i = 0; i < currentNode.Choices.Length; i++)
        {
            if (Input.IsKeyPressed(Keys.D1 + i))
            {
                dialogueTree.SelectChoice(i);
                ExecuteChoiceEffects(world, currentNode.Choices[i]);
            }
        }
    }
    
    private void ExecuteChoiceEffects(IWorld world, DialogueChoice choice)
    {
        foreach (var effect in choice.Effects)
        {
            switch (effect.Type)
            {
                case "GiveItem":
                    var inventory = world.GetSingleton<InventoryComponent>();
                    inventory.Items.Add(new ItemStack
                    {
                        Item = ItemDatabase.Get(effect.Value),
                        Quantity = effect.Amount
                    });
                    break;
                    
                case "StartQuest":
                    QuestSystem.StartQuest(world, effect.Value);
                    break;
                    
                case "GiveGold":
                    var player = world.GetSingleton<PlayerComponent>();
                    player.Gold += effect.Amount;
                    break;
            }
        }
    }
}
```

## Combat System

```csharp
public class CombatSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        if (combatState == null) return;
        
        // Handle combat input
        if (combatState.IsPlayerTurn)
        {
            DrawCombatMenu();
            
            if (Input.IsKeyPressed(Keys.D1)) // Attack
            {
                ExecutePlayerAttack(world);
            }
            else if (Input.IsKeyPressed(Keys.D2)) // Magic
            {
                DrawMagicMenu();
            }
            else if (Input.IsKeyPressed(Keys.D3)) // Item
            {
                DrawItemMenu();
            }
            else if (Input.IsKeyPressed(Keys.D4)) // Flee
            {
                TryFlee();
            }
        }
        else
        {
            // Enemy turn
            ExecuteEnemyTurn(world);
        }
        
        // Check for combat end
        if (combatState.Enemy.Health <= 0)
        {
            Victory(world);
        }
        else if (combatState.Player.Health <= 0)
        {
            Defeat(world);
        }
    }
    
    private void ExecutePlayerAttack(IWorld world)
    {
        var player = world.GetSingleton<PlayerComponent>();
        var enemy = combatState.Enemy;
        
        int damage = CalculateDamage(player.Attack, enemy.Defense);
        enemy.Health -= damage;
        
        ShowDamageNumber(damage, isCritical: false);
        
        combatState.IsPlayerTurn = false;
    }
    
    private int CalculateDamage(int attack, int defense)
    {
        int baseDamage = attack - defense;
        float randomFactor = 0.9f + Random.NextFloat(0, 0.2f);
        return Math.Max(1, (int)(baseDamage * randomFactor));
    }
}
```

## Inventory System

```csharp
public class InventorySystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        if (!inventoryOpen) return;
        
        var inventory = world.GetSingleton<InventoryComponent>();
        
        // Draw inventory UI
        DrawInventoryUI(inventory);
        
        // Handle input
        if (Input.IsKeyPressed(Keys.E))
        {
            inventoryOpen = false;
        }
        
        // Item selection
        for (int i = 0; i < inventory.Items.Count; i++)
        {
            if (Input.IsKeyPressed(Keys.D1 + i))
            {
                selectedItem = i;
            }
        }
        
        // Use item
        if (Input.IsKeyPressed(Keys.Enter) && selectedItem >= 0)
        {
            UseItem(world, inventory.Items[selectedItem]);
        }
        
        // Equip item
        if (Input.IsKeyPressed(Keys.F) && selectedItem >= 0)
        {
            EquipItem(world, inventory.Items[selectedItem]);
        }
    }
    
    private void UseItem(IWorld world, ItemStack stack)
    {
        var player = world.GetSingleton<PlayerComponent>();
        
        switch (stack.Item.Type)
        {
            case ItemType.Consumable:
                player.Health = Math.Min(player.MaxHealth, 
                    player.Health + stack.Item.HealAmount);
                stack.Quantity--;
                break;
                
            case ItemType.Key:
                // Handle key items
                break;
        }
    }
    
    private void EquipItem(IWorld world, ItemStack stack)
    {
        var inventory = world.GetSingleton<InventoryComponent>();
        var player = world.GetSingleton<PlayerComponent>();
        
        if (stack.Item.Type == ItemType.Equipment)
        {
            // Unequip current item in slot
            var currentEquipped = inventory.Equipment[(int)stack.Item.EquipSlot];
            if (currentEquipped != null)
            {
                // Add to inventory
                inventory.Items.Add(new ItemStack { Item = currentEquipped, Quantity = 1 });
                
                // Remove stat bonuses
                player.Attack -= currentEquipped.AttackBonus;
                player.Defense -= currentEquipped.DefenseBonus;
            }
            
            // Equip new item
            inventory.Equipment[(int)stack.Item.EquipSlot] = stack.Item;
            stack.Quantity--;
            
            // Apply stat bonuses
            player.Attack += stack.Item.AttackBonus;
            player.Defense += stack.Item.DefenseBonus;
        }
    }
}
```

## Quest System

```csharp
public class QuestSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        var quests = world.GetSingleton<QuestComponent>();
        
        // Update active quests
        foreach (var quest in quests.ActiveQuests)
        {
            if (!quest.IsComplete)
            {
                CheckQuestProgress(world, quest);
            }
        }
        
        // Check for quest turn-ins
        foreach (var quest in quests.ActiveQuests)
        {
            if (quest.IsComplete && !quest.TurnedIn)
            {
                // Check if player is near quest giver
                var player = world.GetSingleton<PlayerComponent>();
                var npc = FindNPC(quest.QuestGiverId);
                
                if (npc != null && IsNearPlayer(npc))
                {
                    // Show turn-in prompt
                    DrawQuestTurnInPrompt(quest);
                    
                    if (Input.IsKeyPressed(Keys.Enter))
                    {
                        TurnInQuest(world, quest);
                    }
                }
            }
        }
    }
    
    private void CheckQuestProgress(IWorld world, Quest quest)
    {
        foreach (var objective in quest.Objectives)
        {
            if (objective.IsComplete) continue;
            
            switch (objective.Type)
            {
                case ObjectiveType.Kill:
                    // Check kill count
                    break;
                    
                case ObjectiveType.Collect:
                    // Check inventory
                    break;
                    
                case ObjectiveType.Talk:
                    // Check if talked to NPC
                    break;
                    
                case ObjectiveType.Explore:
                    // Check location
                    break;
            }
        }
    }
}
```

## Items

| Type | Examples | Effects |
|------|----------|---------|
| Consumable | Potion, Ether | Restore HP/MP |
| Equipment | Sword, Shield | Stat bonuses |
| Key | Gate Key, Quest Item | Unlock areas/quests |
| Material | Herb, Ore | Crafting ingredients |

## Stats

| Stat | Description |
|------|-------------|
| HP | Health points |
| MP | Mana points |
| ATK | Physical attack power |
| DEF | Physical defense |
| MAT | Magic attack |
| MDF | Magic defense |
| SPD | Speed (turn order) |

## Controls

| Input | Action |
|-------|--------|
| WASD/Arrows | Move |
| Enter | Interact |
| I | Inventory |
| Q | Quest log |
| C | Character stats |
| Escape | Menu/Cancel |

## Related

- [[samples/index|Samples Index]]
- [[samples/platformer|Platformer Sample]]
- [[extensions/dialogue|Dialogue Extension]]
- [[extensions/translator|Translator Extension]]
