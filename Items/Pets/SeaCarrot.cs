using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

using WaasephisFishingPlus.Projectiles.Pets;
using WaasephisFishingPlus.Buffs.Pets;

namespace WaasephisFishingPlus.Items.Pets
{
    public class SeaCarrot : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Fish);
            Item.width = 16;
            Item.height = 16;
            Item.shoot = ModContent.ProjectileType<SeaSlug>();
            Item.buffType = ModContent.BuffType<SeaSlugBuff>();
            Item.rare = ItemRarityID.Orange;
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 2, true);
            }
        }
    }
}