using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Content.Items.Fish
{
    public class FrigidLoach : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 36;
            Item.value = Item.sellPrice(silver: 75);
            Item.rare = ItemRarityID.Orange;
            Item.useTurn = true;
            Item.maxStack = 9999;
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.WarmthPotion, 3);
            recipe.AddIngredient(ItemID.BottledWater, 3);
            recipe.AddIngredient(ModContent.ItemType<FrigidLoach>());
            recipe.AddIngredient(ItemID.Fireblossom, 2);
            recipe.AddIngredient(ItemID.Shiverthorn);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();

            Recipe recipe2 = Recipe.Create(ItemID.SeafoodDinner);
            recipe2.AddIngredient(ModContent.ItemType<FrigidLoach>());
            recipe2.AddTile(TileID.CookingPots);
            recipe2.Register();
        }
    }
}