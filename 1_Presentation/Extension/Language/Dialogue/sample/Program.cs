// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Logging;
using Alis.Extension.Language.Dialogue.Core;

namespace Alis.Extension.Language.Dialogue.Sample
{
    /// <summary>
    ///     Comprehensive sample demonstrating all DialogManager functionality
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main entry point
        /// </summary>
        /// <param name="args">Command line arguments</param>
        public static void Main(string[] args)
        {
            Logger.Info("========================================");
            Logger.Info("   DIALOG MANAGER - COMPREHENSIVE SAMPLE");
            Logger.Info("========================================\n");

            // Example 1: Basic Functionality
            Logger.Info("[EXAMPLE 1] Basic Dialog Management");
            DemonstrateBasicDialogs();
            
            Logger.Info("\n========================================\n");

            // Example 2: Advanced Features with State Management
            Logger.Info("[EXAMPLE 2] Advanced State Machine & Events");
            DemonstrateAdvancedStateManagement();
            
            Logger.Info("\n========================================\n");

            // Example 3: Conditions and Available Options
            Logger.Info("[EXAMPLE 3] Conditional Options");
            DemonstrateConditionalOptions();
            
            Logger.Info("\n========================================\n");

            // Example 4: Context Variables and Actions
            Logger.Info("[EXAMPLE 4] Context Variables & Actions");
            DemonstrateContextAndActions();
            
            Logger.Info("\n========================================\n");

            // Example 5: Event Observation
            Logger.Info("[EXAMPLE 5] Event Observation Pattern");
            DemonstrateEventObservation();
            
            Logger.Info("\n========================================\n");

            // Example 6: Complex Game Dialogue Tree
            Logger.Info("[EXAMPLE 6] Complex Game Dialogue Tree");
            DemonstrateComplexDialogueTree();

            Logger.Info("\n========================================");
            Logger.Info("Sample completed successfully!");
            Logger.Info("========================================");
        }

        /// <summary>
        ///     Demonstrates basic dialog management
        /// </summary>
        private static void DemonstrateBasicDialogs()
        {
            DialogManager manager = new DialogManager();

            // Create first character dialog
            Dialog char1Dialog = new Dialog("char1Greeting", "Hello, adventurer! What brings you to these lands?");
            char1Dialog.AddOption(new DialogOption(
                "I'm here to explore.",
                () => Logger.Info("   ✓ Ah, the spirit of adventure! Be careful, these lands are full of dangers.")
            ));
            char1Dialog.AddOption(new DialogOption(
                "I'm searching for the ancient treasure.",
                () => Logger.Info("   ✓ The ancient treasure, you say? Many have searched for it, but none have returned. Good luck!")
            ));
            manager.AddDialog(char1Dialog);

            // Create second character dialog
            Dialog char2Dialog = new Dialog("char2Greeting", "Did you see any monsters on your way here?");
            char2Dialog.AddOption(new DialogOption(
                "Yes, I fought a few.",
                () => Logger.Info("   ✓ You're brave! I hope you didn't get hurt.")
            ));
            char2Dialog.AddOption(new DialogOption(
                "No, it was surprisingly peaceful.",
                () => Logger.Info("   ✓ That's unusual. Be on your guard, they might be planning something.")
            ));
            manager.AddDialog(char2Dialog);

            Logger.Info("   Showing basic dialogs with options...");
            Logger.Info("   You encounter a mysterious traveler.");
            manager.ShowDialog("char1Greeting");

            Logger.Info("\n   You meet a local villager.");
            manager.ShowDialog("char2Greeting");
        }

        /// <summary>
        ///     Demonstrates state management and transitions
        /// </summary>
        private static void DemonstrateAdvancedStateManagement()
        {
            DialogManager manager = new DialogManager();

            Dialog questDialog = new Dialog("questStart",
                "Greetings! I have a quest for you. Will you help me?");
            questDialog.AddOption(new DialogOption("Yes, I'm ready!", () =>
                Logger.Info("   ✓ Great! Go to the eastern mountains and find my lost artifact.")));
            questDialog.AddOption(new DialogOption("Tell me more first.", () =>
                Logger.Info("   ✓ It's a powerful amulet. Last seen 5 days ago in the mountains.")));

            manager.AddDialog(questDialog);

            Logger.Info("   Dialog States: Idle → Running → Paused → Running → Completed\n");
            Logger.Info($"   Initial state: {manager.CurrentState}");

            manager.StartDialog("questStart");
            Logger.Info($"   After StartDialog: {manager.CurrentState} ✓");

            manager.PauseDialog();
            Logger.Info($"   After PauseDialog: {manager.CurrentState} ✓");

            manager.ResumeDialog();
            Logger.Info($"   After ResumeDialog: {manager.CurrentState} ✓");

            manager.SelectOption(0);
            Logger.Info("   Option selected: 'Yes, I'm ready!' ✓");

            manager.EndDialog();
            Logger.Info($"   After EndDialog: {manager.CurrentState} ✓");
        }

        /// <summary>
        ///     Demonstrates conditional options based on game state
        /// </summary>
        private static void DemonstrateConditionalOptions()
        {
            DialogManager manager = new DialogManager();

            Dialog shopDialog = new Dialog("shop", "Welcome to my shop! What would you like?");

            // Option 1: Always available
            var basicOption = new DialogOption(
                "Show me basic items",
                () => Logger.Info("   ✓ Here are my basic items: Sword, Shield, Potion")
            );
            shopDialog.AddOption(basicOption);

            // Option 2: Only available if player has enough gold
            var expensiveOption = new DialogOption(
                "Show me rare items (requires 500+ gold)",
                () => Logger.Info("   ✓ Here are my rare items: Dragon Sword, Mithril Armor, Phoenix Feather")
            );
            expensiveOption.AddCondition(new LambdaDialogCondition(ctx =>
            {
                int gold = ctx.GetVariable<int>("gold");
                return gold >= 500;
            }));
            shopDialog.AddOption(expensiveOption);

            // Option 3: Only available if player completed prerequisite quest
            var questOption = new DialogOption(
                "Show me legend items (requires 'Dragon Quest' completed)",
                () => Logger.Info("   ✓ Here are legendary items: Excalibur, Holy Grail, Dragon Stone")
            );
            questOption.AddCondition(new LambdaDialogCondition(ctx =>
                ctx.GetVariable<bool>("completedDragonQuest")
            ));
            shopDialog.AddOption(questOption);

            manager.AddDialog(shopDialog);

            // Scenario 1: New player with low gold
            Logger.Info("   Scenario 1: New player (100 gold, no quest)");
            manager.StartDialog("shop");
            manager.SetContextVariable("gold", 100);
            manager.SetContextVariable("completedDragonQuest", false);

            var availableOptions = manager.GetAvailableOptions();
            Logger.Info($"   Available options: {availableOptions.Count}");
            foreach (var option in availableOptions)
            {
                Logger.Info($"     • {option.Text}");
            }
            manager.EndDialog();

            // Scenario 2: Rich player with completed quest
            Logger.Info("\n   Scenario 2: Rich player (600 gold, quest completed)");
            manager.StartDialog("shop");
            manager.SetContextVariable("gold", 600);
            manager.SetContextVariable("completedDragonQuest", true);

            availableOptions = manager.GetAvailableOptions();
            Logger.Info($"   Available options: {availableOptions.Count}");
            foreach (var option in availableOptions)
            {
                Logger.Info($"     • {option.Text}");
            }
            manager.EndDialog();
        }

        /// <summary>
        ///     Demonstrates context variables and dialog actions
        /// </summary>
        private static void DemonstrateContextAndActions()
        {
            DialogManager manager = new DialogManager();

            Dialog trainingDialog = new Dialog("training",
                "Welcome to combat training! Choose your style:");

            // Create options with actions that modify context
            var swordOption = new DialogOption("Train Sword Combat", () =>
                Logger.Info("   ✓ You spend 2 hours training sword techniques!")
            );
            swordOption.AddDialogAction(new CallbackDialogAction("increaseSwordSkill", () =>
            {
                Logger.Info("   [Action] Sword skill +5");
            }));
            trainingDialog.AddOption(swordOption);

            var magicOption = new DialogOption("Study Magic", () =>
                Logger.Info("   ✓ You study ancient spell books!")
            );
            magicOption.AddDialogAction(new CallbackDialogAction("increaseMagicSkill", () =>
            {
                Logger.Info("   [Action] Magic skill +5");
            }));
            trainingDialog.AddOption(magicOption);

            manager.AddDialog(trainingDialog);

            Logger.Info("   Character Statistics:");
            manager.StartDialog("training");
            manager.SetContextVariable("swordSkill", 0);
            manager.SetContextVariable("magicSkill", 0);
            Logger.Info($"   • Sword Skill: {manager.GetContextVariable("swordSkill")}");
            Logger.Info($"   • Magic Skill: {manager.GetContextVariable("magicSkill")}");

            Logger.Info("\n   Player selects: 'Train Sword Combat'");
            manager.SelectOption(0);

            Logger.Info("\n   Player selects: 'Study Magic'");
            manager.SelectOption(1);

            manager.EndDialog();
        }

        /// <summary>
        ///     Demonstrates event observation pattern
        /// </summary>
        private static void DemonstrateEventObservation()
        {
            DialogManager manager = new DialogManager();

            // Create a custom observer
            var observer = new DialogEventObserver();
            manager.RegisterObserver(observer);

            Dialog npcDialog = new Dialog("npc",
                "Nice to meet you, traveler!");
            npcDialog.AddOption(new DialogOption("It's nice to meet you too!", () =>
                Logger.Info("   ✓ NPC smiles warmly")
            ));

            manager.AddDialog(npcDialog);

            Logger.Info("   Starting dialog with event observer...\n");
            manager.StartDialog("npc");
            manager.SelectOption(0);
            manager.EndDialog();

            Logger.Info($"\n   Total events received: {observer.EventCount}");
            Logger.Info($"   Event types tracked:");
            foreach (var eventType in observer.EventTypes)
            {
                Logger.Info($"     • {eventType}");
            }
        }

        /// <summary>
        ///     Demonstrates a complex dialogue tree with branches
        /// </summary>
        private static void DemonstrateComplexDialogueTree()
        {
            DialogManager manager = new DialogManager();

            // Main quest giver dialog
            Dialog questGiver = new Dialog("questGiver",
                "Hail, hero! I have a task for you.");

            var acceptOption = new DialogOption("I accept the quest", () =>
                Logger.Info("   ✓ Quest accepted: Defeat the Shadow Beast"))
            {
                DialogActions = new List<IDialogAction>
                {
                    new CallbackDialogAction("setQuestActive", () =>
                        Logger.Info("   [Event] Quest 'Shadow Beast' activated"))
                }
            };

            var refuseOption = new DialogOption("I'm not interested", () =>
                Logger.Info("   ✓ Quest giver looks disappointed"));

            var infoOption = new DialogOption("Tell me more about this quest",
                () => Logger.Info("   ✓ The Shadow Beast terrorizes the northern villages..."));

            questGiver.AddOption(acceptOption);
            questGiver.AddOption(refuseOption);
            questGiver.AddOption(infoOption);

            // Dialogue after quest completion
            Dialog questComplete = new Dialog("questComplete",
                "You have completed my quest! Take this reward.");

            questComplete.AddOption(new DialogOption("Thank you!",
                () => Logger.Info("   ✓ You received: 500 gold, Experience, Magic Amulet")));

            // Add branch for quest completion
            questGiver.AddBranch("completed", questComplete);

            manager.AddDialog(questGiver);
            manager.AddDialog(questComplete);

            Logger.Info("   Complex Dialogue Tree Simulation:\n");
            Logger.Info("   Visiting quest giver...");
            manager.StartDialog("questGiver");

            Logger.Info("\n   Available options:");
            var options = manager.GetAvailableOptions();
            for (int i = 0; i < options.Count; i++)
            {
                Logger.Info($"     [{i + 1}] {options[i].Text}");
            }

            Logger.Info("\n   Player selects option [1] 'I accept the quest'");
            manager.SelectOption(0);

            Logger.Info("\n   === Quest Progression ===");
            Logger.Info("   [Player completes quest by defeating Shadow Beast]");
            Logger.Info("   [Returning to quest giver...]");

            manager.EndDialog();

            Logger.Info("\n   Visiting quest giver after completion...");
            manager.StartDialog("questComplete");

            Logger.Info("\n   Available options:");
            options = manager.GetAvailableOptions();
            for (int i = 0; i < options.Count; i++)
            {
                Logger.Info($"     [{i + 1}] {options[i].Text}");
            }

            Logger.Info("\n   Player selects option [1] 'Thank you!'");
            manager.SelectOption(0);

            manager.EndDialog();

            Logger.Info("\n   [Quest complete! Rewards granted!]");
        }

        /// <summary>
        ///     Custom dialog event observer
        /// </summary>
        private class DialogEventObserver : IDialogEventObserver
        {
            public int EventCount { get; private set; }
            public List<DialogEventType> EventTypes { get; } = new List<DialogEventType>();

            public void OnDialogEvent(DialogEvent dialogEvent)
            {
                EventCount++;
                if (!EventTypes.Contains(dialogEvent.EventType))
                {
                    EventTypes.Add(dialogEvent.EventType);
                }

                string eventDescription = dialogEvent.EventType switch
                {
                    DialogEventType.OnDialogStart => "Dialog started",
                    DialogEventType.OnDialogEnd => "Dialog ended",
                    DialogEventType.OnOptionSelected => "Option selected",
                    DialogEventType.OnStateChanged => "State changed",
                    _ => "Unknown event"
                };

                Logger.Info($"   [Event] {eventDescription}");
            }
        }
    }
}