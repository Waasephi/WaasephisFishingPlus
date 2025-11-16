using Terraria;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Core
{
    public class ItemGlobal : GlobalItem
    {
        public static Item ActiveItem(Player player) => Main.mouseItem.IsAir ? player.HeldItem : Main.mouseItem;
    }
}