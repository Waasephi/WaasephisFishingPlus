using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Tiles;

namespace WaasephisFishingPlus.Content.Items.Blocks
{

	internal class WaterBombDispenserItem : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.WorkBench);
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 50);
			Item.createTile = ModContent.TileType<WaterBombDispenser>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.WaterBucket, 5);
			recipe.AddIngredient(ItemID.SilverBar, 15);
			recipe.AddTile(TileID.HeavyWorkBench);
			recipe.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.WaterBucket, 5);
			recipe2.AddIngredient(ItemID.TungstenBar, 15);
			recipe2.AddTile(TileID.HeavyWorkBench);
			recipe2.Register();
		}
	}
}