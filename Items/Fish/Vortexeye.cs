using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Fish
{
    public class Vortexeye : ModItem
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
            Recipe recipe = Recipe.Create(ItemID.ArcheryPotion, 3);
            recipe.AddIngredient(ItemID.BottledWater, 3);
            recipe.AddIngredient(ModContent.ItemType<Vortexeye>());
            recipe.AddIngredient(ItemID.Daybloom);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();

            Recipe recipe2 = Recipe.Create(ItemID.AmmoReservationPotion, 3);
            recipe2.AddIngredient(ItemID.BottledWater, 3);
            recipe2.AddIngredient(ModContent.ItemType<Vortexeye>());
            recipe2.AddIngredient(ItemID.Blinkroot);
            recipe2.AddTile(TileID.Bottles);
            recipe2.Register();

            Recipe recipe3 = Recipe.Create(ItemID.SeafoodDinner);
            recipe3.AddIngredient(ModContent.ItemType<Vortexeye>());
            recipe3.AddTile(TileID.CookingPots);
            recipe3.Register();
        }
    }
}