using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Items.Materials;
using WaasephisFishingPlus.Content.Projectiles.Weapons.Summon.Minions;
using WaasephisFishingPlus.Content.Tiles.Decor;

namespace WaasephisFishingPlus.Content.Items.Weapons.Summon
{
    public class ClamTotem : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.DamageType = DamageClass.Summon;
            Item.mana = 10;
            Item.width = 32;
            Item.height = 38;
            Item.useTime = 36;
            Item.useAnimation = 36;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.noMelee = true;
            Item.knockBack = 3;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item44;
            Item.buffType = ModContent.BuffType<ClamMinionBuff>();
            Item.shoot = ModContent.ProjectileType<ClamMinionProj>();
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            // Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position
            position = Main.MouseWorld;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
            player.AddBuff(Item.buffType, 2);

            // Minions have to be spawned manually, then have originalDamage assigned to the damage of the summon item
            var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
            projectile.originalDamage = Item.damage;

            // Since we spawned the projectile manually already, we do not need the game to spawn it for ourselves anymore, so return false
            return false;
        }

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<ClamShell>(), 12)
			.AddIngredient(ItemID.WhitePearl, 2)
			.AddTile(ModContent.TileType<Shellforge>())
			.Register();
		}
	}
}