using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Creative;

namespace WaasephisFishingPlus.Tiles.Crates
{
	internal class FrigidCrateTile : ModTile
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
            AddMapEntry(new Color(107, 86, 71));
            DustType = DustID.BorealWood;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
	}

	internal class FrigidCrate : ModItem
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
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.buyPrice(silver: 85);
            Item.createTile = ModContent.TileType<FrigidCrateTile>();
        }
        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {

            //drop vanilla bars
            IItemDropRule[] oreBars =
            [
                ItemDropRule.Common(ItemID.CobaltBar, 1, 2, 10),
                ItemDropRule.Common(ItemID.PalladiumBar, 1, 2, 10),
                ItemDropRule.Common(ItemID.MythrilBar, 1, 2, 10),
                ItemDropRule.Common(ItemID.OrichalcumBar, 1, 2, 10),
                ItemDropRule.Common(ItemID.AdamantiteBar, 1, 2, 5),
                ItemDropRule.Common(ItemID.TitaniumBar, 1, 2, 5),
            ];
            itemLoot.Add(new OneFromRulesRule(2, oreBars));

            //drop some potions
            IItemDropRule[] combatPotions =
            [
                ItemDropRule.Common(ItemID.RegenerationPotion, 3, 1, 3),
                ItemDropRule.Common(ItemID.IronskinPotion, 3, 1, 3),
                ItemDropRule.Common(ItemID.SwiftnessPotion, 3, 1, 3),
                ItemDropRule.Common(ItemID.WarmthPotion, 2, 1, 2),
        ];
            itemLoot.Add(new OneFromRulesRule(2, combatPotions));

            //healing and mana potions
            IItemDropRule[] resourcePotions =
            [
                ItemDropRule.Common(ItemID.GreaterHealingPotion, 2, 3, 8),
                ItemDropRule.Common(ItemID.GreaterManaPotion, 2, 5, 10),
            ];

            itemLoot.Add(new OneFromRulesRule(2, resourcePotions));

            //fishing bait
            IItemDropRule[] highendBait =
            [
                ItemDropRule.Common(ItemID.JourneymanBait, 1, 2, 6),
                ItemDropRule.Common(ItemID.MasterBait, 1, 2, 5),
            ];
            itemLoot.Add(new OneFromRulesRule(1, highendBait));

            //coins
            itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 1, 1, 3));

            //extra
            IItemDropRule[] rareItem =
            [
                ItemDropRule.Common(ItemID.FrozenTurtleShell, 5),
                ItemDropRule.Common(ItemID.IceSickle, 3),
                ItemDropRule.Common(ItemID.FrostStaff, 3),
                ItemDropRule.Common(ItemID.FrostCore, 3),
                ItemDropRule.Common(ItemID.ScalyTruffle, 5),
                ItemDropRule.Common(ItemID.WolfMountItem, 7),
                ItemDropRule.Common(ItemID.Amarok, 3),
                ItemDropRule.Common(ItemID.IceFeather, 7),
            ];
            itemLoot.Add(new OneFromRulesRule(2, rareItem));
        }
    }
}