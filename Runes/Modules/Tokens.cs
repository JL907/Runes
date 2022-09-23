using R2API;
using System;

namespace RunesPlugin.Modules
{
    internal static class Tokens
    {
        //<color=#c9aa71> tan
        //<color=#ffffff> white
        //<color=#f68835> orange
        //<color=#d62d20> red
        //<color=#AF1AAF> purple
        internal static void AddTokens()
        {
            LanguageAPI.Add("CONQUEROR_NAME", "<color=#ffa700>Conqueror</color>");
            LanguageAPI.Add("CONQUEROR_DESC", "<color=#c9aa71>Successful attacks & abilties</color> against enemies grant <color=#ffffff>1</color> stack of conqueror up to 12 stacks. Each stack of Conqueror grants <color=#f68835>0.6</color> <color=#d62d20>(+0.045 every 4 levels)</color> bonus base damage. While fully stacked you <color=#c9aa71>heal</color> for <color=#008744>6% of any damage from abilities dealt to enemies.</color>");

            LanguageAPI.Add("LETHAL_NAME", "<color=#ffa700>Lethal Tempo</color>");
            LanguageAPI.Add("LETHAL_DESC", "<color=#c9aa71>Successful attacks & abilties</color> against enemies grant <color=#ffffff>1</color> stack of lethal tempo up to 6 stacks. Gain <color=#f68835>10%</color> bonus attack speed for each stack up to <color=#f68835>60%</color> bonus attack speed at maximum stacks.");

            LanguageAPI.Add("PHASE_RUSH_NAME", "<color=#ffa700>Phase Rush</color>");
            LanguageAPI.Add("PHASE_RUSH_DESC", "<color=#c9aa71>Successful attacks & abilties</color> generate <color=#c9aa71>1</color> stack against enemies. Applying <color=#ffffff>3</color> stacks to a target within a 4 second period grants you <color=#f68835>30%</color> <color=#d62d20>(+5% every 4 levels)</color> bonus <color=#c9aa71>movement speed</color> for 3 seconds. Grants the bonus <color=#c9aa71>movement speed</color> on kill.");

            LanguageAPI.Add("ELECTROCUTE_NAME", "<color=#ffa700>Electrocute</color>");
            LanguageAPI.Add("ELECTROCUTE_DESC", "<color=#c9aa71>Successful attacks & abilties</color> generate <color=#c9aa71>1</color> stack against enemies. Applying <color=#ffffff>3</color> stacks to a target within a 3 second period causes them to be struck by lightning after a 1-second delay, dealing them <color=#f68835>600%</color> <color=#d62d20>(+75% every 4 levels)</color> damage. Electrocute has a 5 second cooldown per target.");
        }
    }
}