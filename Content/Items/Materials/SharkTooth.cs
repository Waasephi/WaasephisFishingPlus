using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Content.Items.Materials
{
	public class SharkTooth : ModItem
	{
		public override void SetStaticDefaults() 
		{
		}

		public override void SetDefaults() 
		{
			Item.width = 20;
			Item.height = 22;
			Item.value = Item.sellPrice(silver: 2);
			Item.rare = ItemRarityID.Blue;
			Item.useTurn = true;
			Item.maxStack = 9999;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ItemID.SharkToothNecklace);
			recipe.AddIngredient(this, 5);
			recipe.AddIngredient(ItemID.Shackle);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}