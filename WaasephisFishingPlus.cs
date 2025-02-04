using WaasephisFishingPlus.UserInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace WaasephisFishingPlus
{
    // Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
    public class WaasephisFishingPlus : Mod
    {
        public override void PostSetupContent()
        {

        }

        public override object Call(params object[] args)
        {
            if (args.Length == 0)
            {
                return base.Call(args);
            }

            string command = args[0] as string;

            if (command == "AddKnife" && args.Length == 4)
            {
                Item knifeItem = args[1] as Item;
                int modifier = Convert.ToInt32(args[2]);
                int level = Convert.ToInt32(args[3]);
                FilletingUI.AddKnife(knifeItem, modifier, level);
            }
            else if (command == "AddRecipe" && args.Length == 6)
            {
                Item inputItem = args[1] as Item;
                Item outputItem = args[2] as Item;
                int defaultAmount = Convert.ToInt32(args[3]);
                int knifeLevel = Convert.ToInt32(args[4]);
                bool ignoreKnifeModifier = Convert.ToBoolean(args[5]);
                FilletingUI.AddRecipe(inputItem, outputItem, defaultAmount, knifeLevel, ignoreKnifeModifier);
            }

            return base.Call(args);
        }
    }
}
