using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Content.Items.Filleting
{
	public class RefinedFilletKnife : ModItem
	{
		public override void SetStaticDefaults() 
		{
		}

		public override void SetDefaults() 
		{
			Item.width = 24;
			Item.height = 26;
			Item.value = Item.sellPrice(silver: 50);
			Item.rare = ItemRarityID.LightRed;
			Item.useTurn = true;
			Item.maxStack = 1;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<MoltenFilletKnife>());
			recipe.AddRecipeGroup(nameof(ItemID.MythrilBar), 15);
			recipe.AddIngredient(ItemID.Pearlwood, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
	}
}