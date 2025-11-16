using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Content.Items.Fish
{
    public class SunRay : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 36;
            Item.value = Item.sellPrice(silver: 25);
            Item.rare = ItemRarityID.Blue;
            Item.useTurn = true;
            Item.maxStack = 9999;
        }
        public override void AddRecipes()
        {
			Recipe recipe = Recipe.Create(ItemID.ShinePotion, 3);
			recipe.AddIngredient(ItemID.BottledWater, 3);
			recipe.AddIngredient(ModContent.ItemType<SunRay>());
			recipe.AddIngredient(ItemID.Daybloom, 2);
			recipe.AddIngredient(ItemID.Moonglow);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();

			Recipe recipe2 = Recipe.Create(ItemID.SpelunkerPotion, 3);
			recipe2.AddIngredient(ItemID.BottledWater, 3);
			recipe2.AddIngredient(ModContent.ItemType<SunRay>());
			recipe2.AddIngredient(ItemID.Moonglow, 2);
			recipe2.AddIngredient(ItemID.Blinkroot);
			recipe2.AddTile(TileID.Bottles);
			recipe2.Register();

			Recipe recipe3 = Recipe.Create(ItemID.SeafoodDinner);
            recipe3.AddIngredient(ModContent.ItemType<Woodskip>());
            recipe3.AddTile(TileID.CookingPots);
            recipe3.Register();
        }
    }
}