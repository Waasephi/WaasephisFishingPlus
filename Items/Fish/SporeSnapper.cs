using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Fish
{
    public class SporeSnapper : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 36;
            Item.value = Item.sellPrice(silver: 11);
            Item.rare = ItemRarityID.Blue;
            Item.useTurn = true;
            Item.maxStack = 9999;
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.SummoningPotion);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<SporeSnapper>(), 2);
            recipe.AddIngredient(ItemID.Moonglow, 2);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();

            Recipe recipe2 = Recipe.Create(ItemID.SeafoodDinner);
            recipe2.AddIngredient(ModContent.ItemType<SporeSnapper>());
            recipe2.AddTile(TileID.CookingPots);
            recipe2.Register();
        }
    }
}