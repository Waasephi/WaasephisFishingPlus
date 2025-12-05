using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Items.Blocks;

namespace WaasephisFishingPlus.Content.Tiles.Decor.Furniture.Shellstone
{
	public class ShellstonePlatformItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 200;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<ShellstonePlatform>());
			Item.width = 16;
			Item.height = 16;
		}

		public override void AddRecipes()
		{
			CreateRecipe(2)
				.AddIngredient<ShellstoneBrickItem>()
				.AddTile(ModContent.TileType<Shellforge>())
				.Register();
		}
	}
}