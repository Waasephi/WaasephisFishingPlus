using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Items.FishingRods;

namespace WaasephisFishingPlus.Core
{
    public class ItemGlobal : GlobalItem
    {
        public static Item ActiveItem(Player player) => Main.mouseItem.IsAir ? player.HeldItem : Main.mouseItem;
    }
}