using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Creative;
using WaasephisFishingPlus.Content.Items.LockBoxes;

namespace WaasephisFishingPlus.Content.Tiles.Crates
{
	internal class CryptCoffinTile : ModTile
	{
		public override void SetStaticDefaults()
		{
            Main.tileFrameImportant[Type] = true;
            Main.tileSolidTop[Type] = false;
            Main.tileTable[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(87, 117, 161));
            DustType = DustID.DungeonBlue;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
	}

	internal class CryptCoffin : ModItem
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
            Item.createTile = ModContent.TileType<CryptCoffinTile>();
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
			IItemDropRule[] rareAccessory =
            [
            itemLoot.Add(ItemDropRule.Common(ItemID.BlackBelt, 10)),
            itemLoot.Add(ItemDropRule.Common(ItemID.Tabi, 10)),
            itemLoot.Add(ItemDropRule.Common(ItemID.WispinaBottle, 15)),
            itemLoot.Add(ItemDropRule.Common(ItemID.PaladinsShield, 12)),
            itemLoot.Add(ItemDropRule.Common(ItemID.RifleScope, 10)),
            ];
            itemLoot.Add(new OneFromRulesRule(5, rareAccessory));

            IItemDropRule[] rareWeapon =
            [
            itemLoot.Add(ItemDropRule.Common(ItemID.Keybrand, 15)),
            itemLoot.Add(ItemDropRule.Common(ItemID.PaladinsHammer, 12)),
            itemLoot.Add(ItemDropRule.Common(ItemID.PaladinsShield, 12)),
            itemLoot.Add(ItemDropRule.Common(ItemID.ShadowbeamStaff, 10)),
            itemLoot.Add(ItemDropRule.Common(ItemID.SpectreStaff, 15)),
            itemLoot.Add(ItemDropRule.Common(ItemID.InfernoFork, 13)),
            itemLoot.Add(ItemDropRule.Common(ItemID.RocketLauncher, 12)),
            itemLoot.Add(ItemDropRule.Common(ItemID.SniperRifle, 15)),
            itemLoot.Add(ItemDropRule.Common(ItemID.TacticalShotgun, 10)),
            itemLoot.Add(ItemDropRule.Common(ItemID.Kraken, 10)),
            itemLoot.Add(ItemDropRule.Common(ItemID.MaceWhip, 15)),
            itemLoot.Add(ItemDropRule.Common(ItemID.ShadowJoustingLance, 10)),
            ];
            itemLoot.Add(new OneFromRulesRule(12, rareWeapon));
        }
    }
}