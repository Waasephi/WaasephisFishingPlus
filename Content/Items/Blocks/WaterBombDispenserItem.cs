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
			recipe.AddRecipeGroup(nameof(ItemID.SilverBar), 15);
			recipe.AddTile(TileID.HeavyWorkBench);
			recipe.Register();
		}
	}
}