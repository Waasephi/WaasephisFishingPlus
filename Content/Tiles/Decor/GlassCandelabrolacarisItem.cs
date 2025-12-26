using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Items.Fish.QuestFish;

namespace WaasephisFishingPlus.Content.Tiles.Decor
{
	public class GlassCandelabrolacarisItem : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<GlassCandelabrolacaris>());
			Item.width = 16;
			Item.height = 18;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<GlassAnomalocaris>())
			.AddIngredient(ItemID.Torch, 3)
			.AddTile(TileID.GlassKiln)
			.Register();
		}
	}
}