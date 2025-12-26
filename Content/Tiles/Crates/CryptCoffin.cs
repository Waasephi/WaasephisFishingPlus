using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using WaasephisFishingPlus.Content.Items.LockBoxes;

namespace WaasephisFishingPlus.Content.Tiles.Crates
{
	internal class CryptCoffin : ModTile
	{
		public override void SetStaticDefaults()
		{
            Main.tileFrameImportant[Type] = true;
            Main.tileSolidTop[Type] = false;
            Main.tileTable[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.StyleWrapLimit = 2;
			TileObjectData.newTile.StyleMultiplier = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
			TileObjectData.addAlternate(1);
			TileObjectData.addTile(Type);
			AddMapEntry(new Color(69, 78, 99));
            DustType = DustID.DungeonBlue;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
	}

	internal class CryptCoffinItem : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.width = 48;
            Item.height = 22;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.buyPrice(gold: 1);
            Item.createTile = ModContent.TileType<CryptCoffin>();
        }
        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {

            //<drop vanilla ores>
            IItemDropRule[] ectoplasm = new IItemDropRule[]
            {
                ItemDropRule.Common(ItemID.Ectoplasm, 1, 1, 3),
            };
            itemLoot.Add(new OneFromRulesRule(1, ectoplasm));

            //drop some potions
            IItemDropRule[] combatPotions = new IItemDropRule[]
            {
                ItemDropRule.Common(ItemID.RegenerationPotion, 3, 1, 3),
                ItemDropRule.Common(ItemID.IronskinPotion, 3, 1, 3),
                ItemDropRule.Common(ItemID.SwiftnessPotion, 3, 1, 3),
                ItemDropRule.Common(ItemID.EndurancePotion, 2, 1, 2),
                ItemDropRule.Common(ItemID.MagicPowerPotion, 2, 1, 2),
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
                ItemDropRule.Common(ItemID.MasterBait, 1, 4, 8),
            };
            itemLoot.Add(new OneFromRulesRule(1, highendBait));

			//coins
			itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 1, 5, 10));

			//Lock Box Mold
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<LockBoxMold>(), 5));

			//extra
			int[] rareAccessory =
            [
            ItemID.BlackBelt,
            ItemID.Tabi,
            ItemID.WispinaBottle,
            ItemID.PaladinsShield,
            ItemID.RifleScope,
            ];
            itemLoot.Add(ItemDropRule.OneFromOptions(7, rareAccessory));

            int[] rareWeapon =
            [
            ItemID.Keybrand,
            ItemID.PaladinsHammer,
            ItemID.PaladinsShield,
            ItemID.ShadowbeamStaff,
            ItemID.SpectreStaff,
            ItemID.InfernoFork,
            ItemID.RocketLauncher,
            ItemID.SniperRifle,
            ItemID.TacticalShotgun,
            ItemID.Kraken,
            ItemID.MaceWhip,
            ItemID.ShadowJoustingLance,
            ];
			itemLoot.Add(ItemDropRule.OneFromOptions(10, rareWeapon));
        }
    }
}