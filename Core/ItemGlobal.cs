using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Items.FishingRods;
using WaasephisFishingPlus.Content.Items.LockBoxes;
using WaasephisFishingPlus.Content.Tiles.Decor.Paintings;

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

		public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
		{
			if (item.type == ItemID.FishronBossBag)
			{
				itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<RegalScepter>(), 3));
			}
			#region Crate Adjustments
			if (item.type == ItemID.WoodenCrate)
			{
				int[] baxterPainting = new int[] { ModContent.ItemType<BaxterByThePondItem>() };

				itemLoot.Add(ItemDropRule.OneFromOptions(20, baxterPainting));
			}
			if (item.type == ItemID.WoodenCrateHard)
			{
				int[] baxterPainting = new int[] { ModContent.ItemType<BaxterByThePondItem>() };

				itemLoot.Add(ItemDropRule.OneFromOptions(10, baxterPainting));
			}
			if (item.type == ItemID.FrozenCrateHard)
			{
				int[] hardmodeItem =
				[
				ItemID.IceSickle,
				ItemID.FrostStaff,
				ItemID.FrozenTurtleShell,
				];
				itemLoot.Add(ItemDropRule.OneFromOptions(4, hardmodeItem));

				itemLoot.Add(ItemDropRule.Common(ItemID.FrozenKey, 50));
			}
			if (item.type == ItemID.JungleFishingCrateHard)
			{
				itemLoot.Add(ItemDropRule.Common(ItemID.JungleKey, 50));
			}
			if (item.type == ItemID.CorruptFishingCrateHard)
			{
				itemLoot.Add(ItemDropRule.Common(ItemID.CorruptionKey, 50));
			}
			if (item.type == ItemID.CrimsonFishingCrateHard)
			{
				itemLoot.Add(ItemDropRule.Common(ItemID.CrimsonKey, 50));
			}
			if (item.type == ItemID.HallowedFishingCrateHard)
			{
				itemLoot.Add(ItemDropRule.Common(ItemID.HallowedKey, 50));
			}
			if (item.type == ItemID.OasisCrateHard)
			{
				itemLoot.Add(ItemDropRule.Common(ItemID.DungeonDesertKey, 50));
			}
			#endregion
		}
	}
}