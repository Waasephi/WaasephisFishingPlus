using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Fish
{
    public class Stardustfish : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 36;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Cyan;
            Item.useTurn = true;
            Item.maxStack = 9999;
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.SummoningPotion, 3);
            recipe.AddIngredient(ItemID.BottledWater, 3);
            recipe.AddIngredient(ModContent.ItemType<Stardustfish>());
            recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ItemID.Blinkroot);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();

            Recipe recipe2 = Recipe.Create(ItemID.SeafoodDinner);
            recipe2.AddIngredient(ModContent.ItemType<Stardustfish>());
            recipe2.AddTile(TileID.CookingPots);
            recipe2.Register();
        }
    }
}