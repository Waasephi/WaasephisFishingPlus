using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Filleting
{
	public class GalacticFilletKnife : ModItem
	{
		public override void SetStaticDefaults() 
		{
		}

		public override void SetDefaults() 
		{
			Item.width = 24;
			Item.height = 26;
			Item.value = Item.sellPrice(silver: 50);
			Item.rare = ItemRarityID.Red;
			Item.useTurn = true;
			Item.maxStack = 1;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LunarBar, 6);
            recipe.AddIngredient(ItemID.MartianConduitPlating, 8);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
	}
}