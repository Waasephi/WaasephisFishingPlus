using WaasephisFishingPlus.Items.Filleting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WaasephisFishingPlus.UserInterfaces.FilletingUI;
using Terraria.ModLoader;
using Terraria;

namespace WaasephisFishingPlus.UserInterfaces
{
    internal class Knives
    {
        public static void setKnives()
        {

            if (knives == new List<Knife>()) return;

            Item knifeItem = new Item();

            knifeItem.SetDefaults(ModContent.ItemType<FilletKnife>());
            knives.Add(new Knife { knife = knifeItem, modifier = 0, level = 0 });
            knifeItem = new Item();

            knifeItem.SetDefaults(ModContent.ItemType<MoltenFilletKnife>());
            knives.Add(new Knife { knife = knifeItem, modifier = 2, level = 0 });
            knifeItem = new Item();

            knifeItem.SetDefaults(ModContent.ItemType<RefinedFilletKnife>());
            knives.Add(new Knife { knife = knifeItem, modifier = 0, level = 1 });
            knifeItem = new Item();

            knifeItem.SetDefaults(ModContent.ItemType<ChlorophyteFilletKnife>());
            knives.Add(new Knife { knife = knifeItem, modifier = 4, level = 1 });
            knifeItem = new Item();

            knifeItem.SetDefaults(ModContent.ItemType<LihzahrdFilletKnife>());
            knives.Add(new Knife { knife = knifeItem, modifier = 0, level = 2 });
            knifeItem = new Item();

            knifeItem.SetDefaults(ModContent.ItemType<GalacticFilletKnife>());
            knives.Add(new Knife { knife = knifeItem, modifier = 5, level = 2 });
            knifeItem = new Item();


        }
    }
}
