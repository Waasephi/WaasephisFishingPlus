using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Items.Blocks;

namespace WaasephisFishingPlus.Content.Tiles.Decor.Furniture.Shellstone
{
	public class ShellstoneSofaItem : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<ShellstoneSofa>());
			Item.width = 16;
			Item.height = 16;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<ShellstoneBrickItem>(), 5)
			.AddIngredient(ItemID.Silk, 2)
			.AddTile(ModContent.TileType<Shellforge>())
			.Register();
		}
	}
}