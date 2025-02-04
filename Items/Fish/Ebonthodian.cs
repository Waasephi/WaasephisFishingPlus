using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Fish
{
    public class Ebonthodian : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice(silver: 15);
            Item.rare = ItemRarityID.Blue;
            Item.useTurn = true;
            Item.maxStack = 9999;
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.RagePotion);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Ebonthodian>());
            recipe.AddIngredient(ItemID.Deathweed);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();

            Recipe recipe2 = Recipe.Create(ItemID.SeafoodDinner);
            recipe2.AddIngredient(ModContent.ItemType<Ebonthodian>());
            recipe2.AddTile(TileID.CookingPots);
            recipe2.Register();
        }
    }
}