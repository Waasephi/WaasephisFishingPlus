using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Content.Items.FishingRods
{
    public class MoltenRod : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.CanFishInLava[Item.type] = true; // Allows the pole to fish in lava
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 38;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 8;
            Item.useTime = 8;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.Green;
			Item.value = Item.buyPrice(gold: 1);
			Item.value = Item.sellPrice(silver: 50);
			Item.fishingPole = 20; // Sets the poles fishing power
            Item.shootSpeed = 12f; // Sets the speed in which the bobbers are launched. Wooden Fishing Pole is 9f and Golden Fishing Rod is 17f.
            Item.shoot = ProjectileID.BobberHotline; // The bobber projectile. Note that this will be overridden by Fishing Bobber accessories if present, so don't assume the bobber spawned is the specified projectile. https://terraria.wiki.gg/wiki/Fishing_Bobbers
        }

        public override void ModifyFishingLine(Projectile bobber, ref Vector2 lineOriginOffset, ref Color lineColor)
        {
			lineOriginOffset = new Vector2(46, -30);
			lineColor = Color.Yellow;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HellstoneBar, 20);
            recipe.AddIngredient(ItemID.Obsidian, 15);
            recipe.AddTile(TileID.Hellforge);
            recipe.Register();
        }
    }
}