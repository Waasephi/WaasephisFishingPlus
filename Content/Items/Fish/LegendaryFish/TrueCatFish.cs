using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Core;

namespace WaasephisFishingPlus.Content.Items.Fish.LegendaryFish
{
    public class TrueCatFish : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 44;
            Item.height = 34;
            Item.value = Item.sellPrice(gold: 3);
			Item.rare = ModContent.RarityType<BaxterRarity>();
			Item.useTurn = true;
            Item.maxStack = 1;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Catfish, 5);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}