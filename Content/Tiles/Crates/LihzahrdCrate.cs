using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.GameContent.ItemDropRules;

namespace WaasephisFishingPlus.Content.Tiles.Crates
{
	internal class LihzahrdCrate : ModTile
	{
		public override void SetStaticDefaults()
		{
            Main.tileFrameImportant[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileTable[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(161, 79, 18));
            DustType = DustID.Lihzahrd;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
	}

	internal class LihzahrdCrateItem : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Lime;
            Item.value = Item.buyPrice(gold: 1);
            Item.createTile = ModContent.TileType<LihzahrdCrate>();
        }
        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {

			//<drop vanilla ores>
				itemLoot.Add(ItemDropRule.Common(ItemID.ChlorophyteOre, 1, 6, 12));

			//drop vanilla bars
				itemLoot.Add(ItemDropRule.Common(ItemID.ChlorophyteBar, 1, 3, 6));

            //drop some potions
            IItemDropRule[] combatPotions = new IItemDropRule[]
            {
                ItemDropRule.Common(ItemID.RegenerationPotion, 3, 1, 3),
                ItemDropRule.Common(ItemID.IronskinPotion, 3, 1, 3),
                ItemDropRule.Common(ItemID.SwiftnessPotion, 3, 1, 3),
                ItemDropRule.Common(ItemID.SummoningPotion, 2, 1, 2),
                ItemDropRule.Common(ItemID.AmmoReservationPotion, 2, 1, 2),
			};
            itemLoot.Add(new OneFromRulesRule(2, combatPotions));

            //healing and mana potions
            IItemDropRule[] resourcePotions = new IItemDropRule[]
            {
                ItemDropRule.Common(ItemID.GreaterHealingPotion, 2, 3, 8),
                ItemDropRule.Common(ItemID.GreaterManaPotion, 2, 5, 10),
            };

            itemLoot.Add(new OneFromRulesRule(2, resourcePotions));

            //fishing bait
            IItemDropRule[] highendBait = new IItemDropRule[]
            {
                ItemDropRule.Common(ItemID.JourneymanBait, 1, 2, 6),
                ItemDropRule.Common(ItemID.MasterBait, 1, 2, 7),
            };
            itemLoot.Add(new OneFromRulesRule(1, highendBait));

            //coins
            itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 1, 2, 5));

			//extra
			itemLoot.Add(ItemDropRule.Common(ItemID.LifeFruit, 3));

			//extra
			IItemDropRule[] templeItem =
			[
			itemLoot.Add(ItemDropRule.Common(ItemID.LunarTabletFragment, 3, 1, 4)),
			itemLoot.Add(ItemDropRule.Common(ItemID.SolarTablet, 5)),
			itemLoot.Add(ItemDropRule.Common(ItemID.LihzahrdPowerCell, 10)),
			];
			itemLoot.Add(new OneFromRulesRule(3, templeItem));

			itemLoot.Add(ItemDropRule.Common(ItemID.JungleKey, 25));
		}
    }
}