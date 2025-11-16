using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace WaasephisFishingPlus.Content.Items.LockBoxes
{
	internal class JungleLockBox : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
            Item.consumable = true;
            Item.width = 32;
            Item.height = 22;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(gold: 10);
        }
        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {

			itemLoot.Add(ItemDropRule.Common(ItemID.PiranhaGun));
			itemLoot.Add(ItemDropRule.Common(ItemID.JungleChest));

		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<LockBoxMold>());
			recipe.AddIngredient(ItemID.JungleKey);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}