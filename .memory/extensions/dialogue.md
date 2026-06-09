---
Extension: Language.Dialogue
tags:
  - extension
  - plugin
  - dialogue
  - documentation

status: draft
---



## Overview

| Property | Value |
|----------|-------|
| **Namespace** | `Alis.Extension.Language.Dialogue` |
| **Version** | 1.0.0 |
| **License** | GPLv3 |
| **Author** | Pablo Perdomo Falcón |
| **Layer** | 4_Operation |
| **Dependencies** | Alis.Core, Language.Translator |

## Purpose

The Dialogue extension provides a scripting system for in-game dialogues and conversations. It supports branching dialogue trees, character portraits, and conditional logic.

## Core Components

### DialogManager

```csharp
public class DialogManager
```

Manages dialogue playback and state.

**Responsibilities:**
- Parse dialogue scripts
- Track current dialogue state
- Handle player choices
- Trigger events on dialogue nodes

**Key Methods:**
- `LoadDialogue(string path)` — Parses dialogue script file
- `StartDialogue(string dialogueId)` — Begins playback of specified dialogue
- `Advance()` — Moves to next dialogue node
- `SelectChoice(int choiceIndex)` — Player selects a choice
- `GetCurrentNode()` — Returns current dialogue node
- `OnNodeEntered` — Event fired when entering a new node
- `OnDialogueEnded` — Event fired when dialogue completes

### DialogNode

```csharp
public class DialogNode
{
    public string Id { get; init; }
    public string Speaker { get; init; }
    public string Text { get; init; }
    public string Portrait { get; init; }
    public List<DialogChoice> Choices { get; init; }
    public Dictionary<string, string> Conditions { get; init; }
    public List<DialogAction> Actions { get; init; }
}
```

Represents a single node in a dialogue tree.

### DialogChoice

```csharp
public class DialogChoice
{
    public string Text { get; init; }
    public string TargetNodeId { get; init; }
    public string Condition { get; init; }
    public bool IsAvailable { get; set; }
}
```

Represents a player choice in dialogue.

### DialogAction

```csharp
public class DialogAction
{
    public string Type { get; init; } // "setVariable", "triggerEvent", "playSound"
    public string Target { get; init; }
    public string Value { get; init; }
}
```

Actions triggered when entering a dialogue node.

## Dialogue Script Format

```json
{
  "id": "tutorial_intro",
  "nodes": [
    {
      "id": "start",
      "speaker": "Guide",
      "text": "Welcome to the game!",
      "portrait": "guide_happy",
      "choices": [
        {
          "text": "Tell me more",
          "target": "explain"
        },
        {
          "text": "Skip tutorial",
          "target": "skip",
          "condition": "hasPlayedBefore"
        }
      ]
    },
    {
      "id": "explain",
      "speaker": "Guide",
      "text": "Let me explain the controls...",
      "actions": [
        {
          "type": "triggerEvent",
          "target": "showControls"
        }
      ]
    }
  ]
}
```

## Branching Logic

```
┌─────────────┐
│    Start    │
└──────┬──────┘
       │
       ▼
┌─────────────┐
│  Welcome!   │
└──────┬──────┘
       │
       ├─────────────────┐
       ▼                 ▼
┌─────────────┐    ┌─────────────┐
│ Tell me more│    │Skip tutorial│
└──────┬──────┘    └──────┬──────┘
       │                  │
       ▼                  ▼
┌─────────────┐    ┌─────────────┐
│  Explain    │    │  Skip to    │
│  Controls   │    │  Gameplay   │
└─────────────┘    └─────────────┘
```

## Integration with Translator

```csharp
// Dialogue text can use translation keys
{
  "id": "npc_conversation",
  "speaker": "NPC",
  "text": "dialog.villager.greeting",
  "useTranslation": true
}

// DialogManager automatically resolves via TranslationManager
```

## Variables and Conditions

```csharp
// Set variables during dialogue
dialogManager.SetVariable("hasMetGuard", true);

// Conditional choices
{
  "text": "Ask about the quest",
  "target": "quest_dialog",
  "condition": "hasMetGuard == true"
}
```

## Event System

```csharp
dialogManager.OnNodeEntered += (sender, node) =>
{
    if (node.Portrait != null)
    {
        portraitDisplay.SetPortrait(node.Portrait);
    }
    
    foreach (var action in node.Actions)
    {
        EventSystem.Trigger(action.Type, action.Target, action.Value);
    }
};

dialogManager.OnDialogueEnded += (sender, args) =>
{
    gameState.CurrentDialogId = null;
    uiManager.HideDialogueUI();
};
```

## Related

- [[extensions/translator|Translator Extension]]
- [[extensions/index|Extensions Index]]
- [[system/indexes/events-index|Events Index]]
