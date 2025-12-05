using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Tiles;

namespace WaasephisFishingPlus.Content.Items.Blocks
{

	internal class BaitBoxItem : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.SharpeningStation);
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 50);
			Item.createTile = ModContent.TileType<BaitBox>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ApprenticeBait, 10);
			recipe.AddIngredient(ItemID.JourneymanBait, 5);
			recipe.AddIngredient(ItemID.MasterBait, 3);
			recipe.AddRecipeGroup(nameof(ItemID.SilverBar), 12);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}