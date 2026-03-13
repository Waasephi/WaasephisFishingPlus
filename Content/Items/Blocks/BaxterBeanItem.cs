using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Items.Fish.LegendaryFish;
using WaasephisFishingPlus.Content.Tiles.Decor;
using WaasephisFishingPlus.Core;

namespace WaasephisFishingPlus.Content.Items.Blocks
{

	internal class BaxterBeanItem : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.CrystalBall);
			Item.rare = ModContent.RarityType<BaxterRarity>();
			Item.value = Item.sellPrice(gold: 1);
			Item.createTile = ModContent.TileType<BaxterBean>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<TrueCatFish>());
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}