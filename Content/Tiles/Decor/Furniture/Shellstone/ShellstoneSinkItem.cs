using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Items.Blocks;

namespace WaasephisFishingPlus.Content.Tiles.Decor.Furniture.Shellstone
{
	public class ShellstoneSinkItem : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<ShellstoneSink>());
			Item.width = 16;
			Item.height = 16;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<ShellstoneBrickItem>(), 6)
			.AddIngredient(ItemID.WaterBucket)
			.AddTile(ModContent.TileType<Shellforge>())
			.Register();
		}
	}
}