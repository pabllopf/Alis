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

using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Language.Dialogue.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            DialogManager dialogManager = new DialogManager();

            // Create dialog for the first character
            Dialog char1Dialog = new Dialog("char1Greeting", "Hello, adventurer! What brings you to these lands?");
            char1Dialog.AddOption(new DialogOption("I'm here to explore.", () =>  Logger.Info("Ah, the spirit of adventure! Be careful, these lands are full of dangers.")));
            char1Dialog.AddOption(new DialogOption("I'm searching for the ancient treasure.", () =>  Logger.Info("The ancient treasure, you say? Many have searched for it, but none have returned. Good luck on your quest.")));
            dialogManager.AddDialog(char1Dialog);

            // Create dialog for the second character
            Dialog char2Dialog = new Dialog("char2Greeting", "Did you see any monsters on your way here?");
            char2Dialog.AddOption(new DialogOption("Yes, I fought a few.", () =>  Logger.Info("You're brave! I hope you didn't get hurt.")));
            char2Dialog.AddOption(new DialogOption("No, it was surprisingly peaceful.", () =>  Logger.Info("That's unusual. Be on your guard, they might be planning something.")));
            dialogManager.AddDialog(char2Dialog);

            // Simulate dialog flow
            Logger.Info("You encounter a mysterious traveler.");
            dialogManager.ShowDialog("char1Greeting");
            Logger.Info("\nYou meet a local villager.");
            dialogManager.ShowDialog("char2Greeting");
        }
    }
}