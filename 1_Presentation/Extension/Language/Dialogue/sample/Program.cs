

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

            Logger.Info("[EXAMPLE 1] Basic Dialog Management");
            DemonstrateBasicDialogs();

            Logger.Info("\n========================================\n");

            Logger.Info("[EXAMPLE 2] Advanced State Machine & Events");
            DemonstrateAdvancedStateManagement();

            Logger.Info("\n========================================\n");

            Logger.Info("[EXAMPLE 3] Conditional Options");
            DemonstrateConditionalOptions();

            Logger.Info("\n========================================\n");

            Logger.Info("[EXAMPLE 4] Context Variables & Actions");
            DemonstrateContextAndActions();

            Logger.Info("\n========================================\n");

            Logger.Info("[EXAMPLE 5] Event Observation Pattern");
            DemonstrateEventObservation();

            Logger.Info("\n========================================\n");

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

            DialogOption basicOption = new DialogOption(
                "Show me basic items",
                () => Logger.Info("   ✓ Here are my basic items: Sword, Shield, Potion")
            );
            shopDialog.AddOption(basicOption);

            DialogOption expensiveOption = new DialogOption(
                "Show me rare items (requires 500+ gold)",
                () => Logger.Info("   ✓ Here are my rare items: Dragon Sword, Mithril Armor, Phoenix Feather")
            );
            expensiveOption.AddCondition(new LambdaDialogCondition(ctx =>
            {
                int gold = ctx.GetVariable<int>("gold");
                return gold >= 500;
            }));
            shopDialog.AddOption(expensiveOption);

            DialogOption questOption = new DialogOption(
                "Show me legend items (requires 'Dragon Quest' completed)",
                () => Logger.Info("   ✓ Here are legendary items: Excalibur, Holy Grail, Dragon Stone")
            );
            questOption.AddCondition(new LambdaDialogCondition(ctx =>
                ctx.GetVariable<bool>("completedDragonQuest")
            ));
            shopDialog.AddOption(questOption);

            manager.AddDialog(shopDialog);

            Logger.Info("   Scenario 1: New player (100 gold, no quest)");
            manager.StartDialog("shop");
            manager.SetContextVariable("gold", 100);
            manager.SetContextVariable("completedDragonQuest", false);

            List<DialogOption> availableOptions = manager.GetAvailableOptions();
            Logger.Info($"   Available options: {availableOptions.Count}");
            foreach (DialogOption option in availableOptions)
            {
                Logger.Info($"     • {option.Text}");
            }

            manager.EndDialog();

            Logger.Info("\n   Scenario 2: Rich player (600 gold, quest completed)");
            manager.StartDialog("shop");
            manager.SetContextVariable("gold", 600);
            manager.SetContextVariable("completedDragonQuest", true);

            availableOptions = manager.GetAvailableOptions();
            Logger.Info($"   Available options: {availableOptions.Count}");
            foreach (DialogOption option in availableOptions)
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

            DialogOption swordOption = new DialogOption("Train Sword Combat", () =>
                Logger.Info("   ✓ You spend 2 hours training sword techniques!")
            );
            swordOption.AddDialogAction(new CallbackDialogAction("increaseSwordSkill", () => { Logger.Info("   [Action] Sword skill +5"); }));
            trainingDialog.AddOption(swordOption);

            DialogOption magicOption = new DialogOption("Study Magic", () =>
                Logger.Info("   ✓ You study ancient spell books!")
            );
            magicOption.AddDialogAction(new CallbackDialogAction("increaseMagicSkill", () => { Logger.Info("   [Action] Magic skill +5"); }));
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

            DialogEventObserver observer = new DialogEventObserver();
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
            Logger.Info("   Event types tracked:");
            foreach (DialogEventType eventType in observer.EventTypes)
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

            Dialog questGiver = new Dialog("questGiver",
                "Hail, hero! I have a task for you.");

            DialogOption acceptOption = new DialogOption("I accept the quest", () =>
                Logger.Info("   ✓ Quest accepted: Defeat the Shadow Beast"))
            {
                DialogActions = new List<IDialogAction>
                {
                    new CallbackDialogAction("setQuestActive", () =>
                        Logger.Info("   [Event] Quest 'Shadow Beast' activated"))
                }
            };

            DialogOption refuseOption = new DialogOption("I'm not interested", () =>
                Logger.Info("   ✓ Quest giver looks disappointed"));

            DialogOption infoOption = new DialogOption("Tell me more about this quest",
                () => Logger.Info("   ✓ The Shadow Beast terrorizes the northern villages..."));

            questGiver.AddOption(acceptOption);
            questGiver.AddOption(refuseOption);
            questGiver.AddOption(infoOption);

            Dialog questComplete = new Dialog("questComplete",
                "You have completed my quest! Take this reward.");

            questComplete.AddOption(new DialogOption("Thank you!",
                () => Logger.Info("   ✓ You received: 500 gold, Experience, Magic Amulet")));

            questGiver.AddBranch("completed", questComplete);

            manager.AddDialog(questGiver);
            manager.AddDialog(questComplete);

            Logger.Info("   Complex Dialogue Tree Simulation:\n");
            Logger.Info("   Visiting quest giver...");
            manager.StartDialog("questGiver");

            Logger.Info("\n   Available options:");
            List<DialogOption> options = manager.GetAvailableOptions();
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
            /// <summary>
            ///     Gets or sets the value of the event count
            /// </summary>
            public int EventCount { get; private set; }

            /// <summary>
            ///     Gets the value of the event types
            /// </summary>
            public List<DialogEventType> EventTypes { get; } = new List<DialogEventType>();

            /// <summary>
            ///     Ons the dialog event using the specified dialog event
            /// </summary>
            /// <param name="dialogEvent">The dialog event</param>
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