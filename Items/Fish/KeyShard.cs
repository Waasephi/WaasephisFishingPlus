using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Fish
{
    public class KeyShard : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice(silver: 15);
            Item.rare = ItemRarityID.Yellow;
            Item.useTurn = true;
            Item.maxStack = 9999;
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.CorruptionKey);
            recipe.AddIngredient(ModContent.ItemType<KeyShard>(), 5);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient(ItemID.DemoniteBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            Recipe recipe2 = Recipe.Create(ItemID.CrimsonKey);
            recipe2.AddIngredient(ModContent.ItemType<KeyShard>(), 5);
            recipe2.AddIngredient(ItemID.SoulofMight, 5);
            recipe2.AddIngredient(ItemID.SoulofFright, 5);
            recipe2.AddIngredient(ItemID.SoulofSight, 5);
            recipe2.AddIngredient(ItemID.CrimtaneBar, 20);
            recipe2.AddTile(TileID.MythrilAnvil);
            recipe2.Register();

            Recipe recipe3 = Recipe.Create(ItemID.FrozenKey);
            recipe3.AddIngredient(ModContent.ItemType<KeyShard>(), 5);
            recipe3.AddIngredient(ItemID.SoulofMight, 5);
            recipe3.AddIngredient(ItemID.SoulofFright, 5);
            recipe3.AddIngredient(ItemID.SoulofSight, 5);
            recipe3.AddIngredient(ItemID.FrostCore, 3);
            recipe3.AddTile(TileID.MythrilAnvil);
            recipe3.Register();

            Recipe recipe4 = Recipe.Create(ItemID.JungleKey);
            recipe4.AddIngredient(ModContent.ItemType<KeyShard>(), 5);
            recipe4.AddIngredient(ItemID.SoulofMight, 5);
            recipe4.AddIngredient(ItemID.SoulofFright, 5);
            recipe4.AddIngredient(ItemID.SoulofSight, 5);
            recipe4.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe4.AddTile(TileID.MythrilAnvil);
            recipe4.Register();

            Recipe recipe5 = Recipe.Create(ItemID.HallowedKey);
            recipe5.AddIngredient(ModContent.ItemType<KeyShard>(), 5);
            recipe5.AddIngredient(ItemID.SoulofMight, 5);
            recipe5.AddIngredient(ItemID.SoulofFright, 5);
            recipe5.AddIngredient(ItemID.SoulofSight, 5);
            recipe5.AddIngredient(ItemID.CrystalShard, 20);
            recipe5.AddTile(TileID.MythrilAnvil);
            recipe5.Register();

            Recipe recipe6 = Recipe.Create(ItemID.DungeonDesertKey);
            recipe6.AddIngredient(ModContent.ItemType<KeyShard>(), 5);
            recipe6.AddIngredient(ItemID.SoulofMight, 5);
            recipe6.AddIngredient(ItemID.SoulofFright, 5);
            recipe6.AddIngredient(ItemID.SoulofSight, 5);
            recipe6.AddIngredient(ItemID.AncientBattleArmorMaterial, 3);
            recipe6.AddTile(TileID.MythrilAnvil);
            recipe6.Register();
        }
    }
}