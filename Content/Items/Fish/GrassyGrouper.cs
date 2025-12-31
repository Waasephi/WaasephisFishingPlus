using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Content.Items.Fish
{
    public class GrassyGrouper : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice(silver: 25);
            Item.rare = ItemRarityID.Blue;
            Item.useTurn = true;
            Item.maxStack = 9999;
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.SwiftnessPotion, 2);
            recipe.AddIngredient(ItemID.BottledWater, 2);
            recipe.AddIngredient(ModContent.ItemType<GrassyGrouper>());
            recipe.AddIngredient(ItemID.Daybloom, 2);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();

            Recipe recipe2 = Recipe.Create(ItemID.SeafoodDinner);
            recipe2.AddIngredient(ModContent.ItemType<GrassyGrouper>());
            recipe2.AddTile(TileID.CookingPots);
            recipe2.Register();
        }
    }
}