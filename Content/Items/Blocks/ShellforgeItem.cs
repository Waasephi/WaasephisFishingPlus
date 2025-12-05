using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Items.Materials;
using WaasephisFishingPlus.Content.Tiles.Decor;

namespace WaasephisFishingPlus.Content.Items.Blocks
{

	internal class ShellforgeItem : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Furnace);
			Item.rare = ItemRarityID.White;
			Item.value = Item.sellPrice(silver: 25);
			Item.createTile = ModContent.TileType<Shellforge>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ClamShell>(), 10);
			recipe.AddIngredient(ItemID.WhitePearl, 5);
			recipe.AddIngredient(ItemID.Furnace);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}