using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Filleting
{
	public class ChlorophyteFilletKnife : ModItem
	{
		public override void SetStaticDefaults() 
		{
		}

		public override void SetDefaults() 
		{
			Item.width = 24;
			Item.height = 26;
			Item.value = Item.sellPrice(silver: 75);
			Item.rare = ItemRarityID.Lime;
			Item.useTurn = true;
			Item.maxStack = 1;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RefinedFilletKnife>());
			recipe.AddIngredient(ItemID.ChlorophyteBar, 6);
            recipe.AddIngredient(ItemID.RichMahogany, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
	}
}