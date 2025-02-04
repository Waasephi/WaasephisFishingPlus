using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Fish
{
    public class Nebulagazer : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 44;
            Item.height = 42;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Cyan;
            Item.useTurn = true;
            Item.maxStack = 9999;
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.MagicPowerPotion, 3);
            recipe.AddIngredient(ItemID.BottledWater, 3);
            recipe.AddIngredient(ModContent.ItemType<Nebulagazer>());
            recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ItemID.FallenStar);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();

            Recipe recipe2 = Recipe.Create(ItemID.ManaRegenerationPotion, 3);
            recipe2.AddIngredient(ItemID.BottledWater, 3);
            recipe2.AddIngredient(ModContent.ItemType<Nebulagazer>());
            recipe2.AddIngredient(ItemID.Deathweed);
            recipe2.AddIngredient(ItemID.FallenStar);
            recipe2.AddTile(TileID.Bottles);
            recipe2.Register();

            Recipe recipe3 = Recipe.Create(ItemID.SeafoodDinner);
            recipe3.AddIngredient(ModContent.ItemType<Nebulagazer>());
            recipe3.AddTile(TileID.CookingPots);
            recipe3.Register();
        }
    }
}