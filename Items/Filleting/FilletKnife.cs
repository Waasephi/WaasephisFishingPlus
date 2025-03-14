using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Filleting
{
	public class FilletKnife : ModItem
	{
		public override void SetStaticDefaults() 
		{
		}

		public override void SetDefaults() 
		{
			Item.width = 24;
			Item.height = 26;
			Item.value = Item.sellPrice(silver: 5);
			Item.rare = ItemRarityID.Blue;
			Item.useTurn = true;
			Item.maxStack = 1;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup(RecipeGroupID.IronBar, 6);
			recipe.AddIngredient(ItemID.PalmWood, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}