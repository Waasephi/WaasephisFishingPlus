using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Fish
{
    public class Woodskip : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 40;
            Item.value = Item.sellPrice(silver: 5);
            Item.rare = ItemRarityID.Blue;
            Item.useTurn = true;
            Item.maxStack = 9999;
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.BuilderPotion, 2);
            recipe.AddIngredient(ItemID.BottledWater, 2);
            recipe.AddIngredient(ModContent.ItemType<Woodskip>());
            recipe.AddIngredient(ItemID.Daybloom, 2);
            recipe.AddIngredient(ItemID.Waterleaf);
            recipe.AddIngredient(ItemID.StoneBlock, 5);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();

            Recipe recipe2 = Recipe.Create(ItemID.SeafoodDinner);
            recipe2.AddIngredient(ModContent.ItemType<Woodskip>());
            recipe2.AddTile(TileID.CookingPots);
            recipe2.Register();
        }
    }
}