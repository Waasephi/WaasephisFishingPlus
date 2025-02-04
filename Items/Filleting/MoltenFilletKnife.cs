using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Filleting
{
	public class MoltenFilletKnife : ModItem
	{
		public override void SetStaticDefaults() 
		{
		}

		public override void SetDefaults() 
		{
			Item.width = 24;
			Item.height = 26;
			Item.value = Item.sellPrice(silver: 5);
			Item.rare = ItemRarityID.Orange;
			Item.useTurn = true;
			Item.maxStack = 1;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HellstoneBar, 6);
			recipe.AddIngredient(ItemID.Obsidian, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}