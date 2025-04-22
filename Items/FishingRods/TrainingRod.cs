using WaasephisFishingPlus.Projectiles.Fishing;
using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.FishingRods
{
    public class TrainingRod : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.CanFishInLava[Item.type] = false; // Allows the pole to fish in lava
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 32;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 8;
            Item.useTime = 8;
            Item.UseSound = SoundID.Item1;
			Item.value = Item.buyPrice(silver: 50);
			Item.value = Item.sellPrice(silver: 10);
			Item.rare = ItemRarityID.Orange;
            Item.fishingPole = 5; // Sets the poles fishing power
            Item.shootSpeed = 8f; // Sets the speed in which the bobbers are launched. Wooden Fishing Pole is 9f and Golden Fishing Rod is 17f.
            Item.shoot = ModContent.ProjectileType<TrainingBobber>(); // The bobber projectile. Note that this will be overridden by Fishing Bobber accessories if present, so don't assume the bobber spawned is the specified projectile. https://terraria.wiki.gg/wiki/Fishing_Bobbers
        }

        // Grants the High Test Fishing Line bool if holding the item.
        // NOTE: Only triggers through the hotbar, not if you hold the item by hand outside of the inventory.
        public override void HoldItem(Player player)
        {
            player.accFishingLine = true;
        }

        public override void ModifyFishingLine(Projectile bobber, ref Vector2 lineOriginOffset, ref Color lineColor)
        {
            // Change these two values in order to change the origin of where the line is being drawn.
            // This will make it draw 43 pixels right and 30 pixels up from the player's center, while they are looking right and in normal gravity.
            lineOriginOffset = new Vector2(46, -26);

            // Sets the fishing line's color. Note that this will be overridden by the colored string accessories.
            if (bobber.ModProjectile is TrainingBobber trainingBobber)
            {
                // ExampleBobber has custom code to decide on a line color.
                lineColor = trainingBobber.FishingLineColor;
            }
            else
            {
                lineColor = Color.White;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CopperBar, 12);
            recipe.AddIngredient(ItemID.Cobweb, 25);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}