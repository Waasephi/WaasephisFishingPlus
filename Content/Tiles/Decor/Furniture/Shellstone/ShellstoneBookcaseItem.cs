using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Items.Blocks;

namespace WaasephisFishingPlus.Content.Tiles.Decor.Furniture.Shellstone
{
	public class ShellstoneBookcaseItem : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<ShellstoneBookcase>());
			Item.width = 16;
			Item.height = 16;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<ShellstoneBrickItem>(), 20)
			.AddIngredient(ItemID.Book, 10)
			.AddTile(ModContent.TileType<Shellforge>())
			.Register();
		}
	}
}