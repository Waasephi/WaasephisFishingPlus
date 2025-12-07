using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Core
{
    public class ItemGlobal : GlobalItem
    {
        public static Item ActiveItem(Player player) => Main.mouseItem.IsAir ? player.HeldItem : Main.mouseItem;

		public static bool ItemHasFilletRecipe(Item item)
		{
			foreach (var recipe in WaasephisFishingPlus.recipes)
			{
				if (recipe.Key.netID == item.netID)
				{
					return true;
				}
			}

			return false;
		}

		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			if (ItemHasFilletRecipe(item))
			{
				var FilletTooltipLine = new TooltipLine(Mod, "FilletTooltip", Language.GetTextValue("Mods.WaasephisFishingPlus.Items.FilletItemTooltip"));

				tooltips.Insert(Main.GameModeInfo.IsJourneyMode ? tooltips.Count - 1 : tooltips.Count, FilletTooltipLine);
			}
		}
    }
}