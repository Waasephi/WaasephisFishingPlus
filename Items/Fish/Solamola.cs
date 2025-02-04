using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Fish
{
    public class Solamola : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Cyan;
            Item.useTurn = true;
            Item.maxStack = 9999;
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.InfernoPotion, 3);
            recipe.AddIngredient(ItemID.BottledWater, 3);
            recipe.AddIngredient(ModContent.ItemType<Solamola>());
            recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ItemID.Daybloom);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();

            Recipe recipe2 = Recipe.Create(ItemID.WarmthPotion, 3);
            recipe2.AddIngredient(ItemID.BottledWater, 3);
            recipe2.AddIngredient(ModContent.ItemType<Solamola>());
            recipe2.AddIngredient(ItemID.Shiverthorn);
            recipe2.AddIngredient(ItemID.Daybloom);
            recipe2.AddTile(TileID.Bottles);
            recipe2.Register();

            Recipe recipe3 = Recipe.Create(ItemID.SeafoodDinner);
            recipe3.AddIngredient(ModContent.ItemType<Solamola>());
            recipe3.AddTile(TileID.CookingPots);
            recipe3.Register();
        }
    }
}