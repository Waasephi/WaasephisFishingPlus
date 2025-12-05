using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Items.Blocks;

namespace WaasephisFishingPlus.Content.Tiles.Decor.Furniture.Shellstone
{
	public class ShellstoneBathtubItem : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<ShellstoneBathtub>());
			Item.width = 16;
			Item.height = 16;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<ShellstoneBrickItem>(), 14)
			.AddTile(ModContent.TileType<Shellforge>())
			.Register();
		}
	}
}