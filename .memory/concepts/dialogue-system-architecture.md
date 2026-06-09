---
title: Dialogue System Architecture
tags:
  - concept
  - theory
  - documentation

status: Draft

license: GPLv3

---


Dialogue systems provide scripted narrative with branching paths, localization support, and player choice integration for games and interactive applications.

## Core Components

### 1. Dialogue Tree
- **Structure**: Node-based branching narrative
- **Location**: `1_Presentation/Extension/Language.Dialogue/`
- **Features**: Branching choices, conditions, variables

### 2. Localization Support
- **Pattern**: Key-value translation system
- **Features**: Multi-language support, runtime switching

### 3. Player Choices
- **Pattern**: Decision points affecting narrative flow
- **Features**: Conditional branches, reputation tracking

## Implementation Example

### Dialogue Node

```csharp
public class DialogueNode
{
    public string Id { get; }
    public string Text { get; }
    public List<DialogueChoice> Choices { get; }
    public Dictionary<string, object> Variables { get; }
    
    public DialogueNode(string id, string text)
    {
        Id = id;
        Text = text;
        Choices = new List<DialogueChoice>();
        Variables = new Dictionary<string, object>();
    }
    
    public void AddChoice(string text, string nextNodeId, Condition? condition = null)
    {
        Choices.Add(new DialogueChoice(text, nextNodeId, condition));
    }
}

public class DialogueChoice
{
    public string Text { get; }
    public string NextNodeId { get; }
    public Condition? Condition { get; }
    
    public DialogueChoice(string text, string nextNodeId, Condition? condition)
    {
        Text = text;
        NextNodeId = nextNodeId;
        Condition = condition;
    }
}

public class Condition
{
    public string VariableName { get; }
    public string Operator { get; } // ">", "<", "==", "!=", "contains"
    public object Value { get; }
    
    public bool IsSatisfied(Dictionary<string, object> variables)
    {
        if (!variables.TryGetValue(VariableName, out var currentValue))
            return false;
        
        return Operator switch
        {
            ">" => Compare(currentValue, Value) > 0,
            "<" => Compare(currentValue, Value) < 0,
            "==" => currentValue.Equals(Value),
            "!=" => !currentValue.Equals(Value),
            "contains" => currentValue.ToString().Contains(Value.ToString()),
            _ => false
        };
    }
}
```

### Dialogue System

```csharp
public class DialogueSystem
{
    private Dictionary<string, DialogueNode> _nodes = new();
    private Dictionary<string, Dictionary<string, string>> _translations = new();
    private string _currentLanguage = "en";
    
    public void AddNode(DialogueNode node)
    {
        _nodes[node.Id] = node;
    }
    
    public void Translate(string nodeId, string language, string translatedText)
    {
        if (!_translations.ContainsKey(nodeId))
            _translations[nodeId] = new Dictionary<string, string>();
        
        _translations[nodeId][language] = translatedText;
    }
    
    public DialogueNode GetNode(string nodeId)
    {
        var node = _nodes[nodeId];
        
        // Apply translation if available
        if (_translations.TryGetValue(nodeId, out var langDict) &&
            langDict.TryGetValue(_currentLanguage, out var translated))
        {
            node = new DialogueNode(node.Id, translated);
            // Copy choices
            foreach (var choice in node.Choices)
                node.AddChoice(choice.Text, choice.NextNodeId, choice.Condition);
        }
        
        return node;
    }
    
    public void SetLanguage(string language)
    {
        _currentLanguage = language;
    }
}
```

## Usage Pattern

```csharp
// Create dialogue tree
var dialogue = new DialogueSystem();

var startNode = new DialogueNode("start", "Welcome, traveler. How can I help you?");

startNode.AddChoice("I need information", "info_request");
startNode.AddChoice("I want to buy something", "shop_offer");
startNode.AddChoice("Goodbye", "end");

dialogue.AddNode(startNode);

var infoNode = new DialogueNode("info_request", "What kind of information do you need?");
infoNode.AddChoice("Map", "show_map", new Condition("hasMap", "==", false));
infoNode.AddChoice("Quests", "show_quests");
infoNode.AddChoice("Back", "start");

dialogue.AddNode(infoNode);

// Translate to Spanish
dialogue.Translate("start", "es", "Bienvenido, viajero. ¿Cómo puedo ayudarte?");
dialogue.Translate("info_request", "es", "¿Qué tipo de información necesitas?");

// Set language
dialogue.SetLanguage("es");

// Process dialogue
var currentNode = startNode;
while (currentNode.Id != "end")
{
    Console.WriteLine(currentNode.Text);
    
    foreach (var choice in currentNode.Choices)
    {
        if (choice.Condition?.IsSatisfied(new Dictionary<string, object>()) == true)
            Console.WriteLine($"  > {choice.Text}");
    }
    
    // Player choice logic...
    currentNode = dialogue.GetNode(nextNodeId);
}
```

## Benefits

| Benefit | Description |
|---------|-------------|
| **Branching Narrative** | Multiple story paths based on choices |
| **Localization** | Easy multi-language support |
| **Variable Tracking** | Stateful dialogue with conditions |
| **Replayability** | Different outcomes each playthrough |

## Performance Considerations

| Metric | Value |
|--------|-------|
| Dialogue node lookup | O(1) hash table |
| Translation lookup | O(1) per language |
| Memory per dialogue | ~2KB per 100 nodes |
| Loading time (1000 nodes) | <10ms |

## When to Use Dialogue System

### Suitable For
- RPG games
- Visual novels
- Interactive fiction
- Customer service bots

### Not Suitable For
- Linear tutorials
- Simple UI messages
- Non-narrative applications

## See Also
- [`.memory/concepts/dialogue-system-architecture.md`] - Dialogue System Architecture
