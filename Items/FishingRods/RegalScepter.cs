using WaasephisFishingPlus.Projectiles.Fishing;
using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.FishingRods
{
    public class RegalScepter : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.CanFishInLava[Item.type] = false; // Allows the pole to fish in lava
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 34;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 8;
            Item.useTime = 8;
            Item.UseSound = SoundID.Item1;
			Item.value = Item.buyPrice(gold: 50);
			Item.value = Item.sellPrice(gold: 25);
			Item.rare = ItemRarityID.Yellow;
            Item.fishingPole = 80; // Sets the poles fishing power
            Item.shootSpeed = 18f; // Sets the speed in which the bobbers are launched. Wooden Fishing Pole is 9f and Golden Fishing Rod is 17f.
            Item.shoot = ModContent.ProjectileType<RegalBobber>(); // The bobber projectile. Note that this will be overridden by Fishing Bobber accessories if present, so don't assume the bobber spawned is the specified projectile. https://terraria.wiki.gg/wiki/Fishing_Bobbers
        }

        // Grants the High Test Fishing Line bool if holding the item.
        // NOTE: Only triggers through the hotbar, not if you hold the item by hand outside of the inventory.

        // Overrides the default shooting method to fire multiple bobbers.
        // NOTE: This will allow the fishing rod to summon multiple Duke Fishrons with multiple Truffle Worms in the inventory.
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int bobberAmount = 4;
            float spreadAmount = 60f; // how much the different bobbers are spread out.

            for (int index = 0; index < bobberAmount; ++index)
            {
                Vector2 bobberSpeed = velocity + new Vector2(Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f, Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f);

                // Generate new bobbers
                Projectile.NewProjectile(source, position, bobberSpeed, type, 0, 0f, player.whoAmI);
            }
            return false;
        }

        public override void ModifyFishingLine(Projectile bobber, ref Vector2 lineOriginOffset, ref Color lineColor)
        {
            // Change these two values in order to change the origin of where the line is being drawn.
            // This will make it draw 43 pixels right and 30 pixels up from the player's center, while they are looking right and in normal gravity.
            lineOriginOffset = new Vector2(44, -26);

            // Sets the fishing line's color. Note that this will be overridden by the colored string accessories.
            if (bobber.ModProjectile is RegalBobber regalBobber)
            {
                // ExampleBobber has custom code to decide on a line color.
                lineColor = regalBobber.FishingLineColor;
            }
            else
            {
                lineColor = Color.Blue;
            }
        }
    }
}