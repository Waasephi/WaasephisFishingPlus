using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Items.Materials;
using WaasephisFishingPlus.Content.Projectiles.Weapons.Magic;
using WaasephisFishingPlus.Content.Tiles.Decor;

namespace WaasephisFishingPlus.Content.Items.Weapons.Magic
{
	public class ClamClapper : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 26;
			Item.DamageType = DamageClass.Magic;
			Item.noMelee = true;
			Item.autoReuse = false;
			Item.noUseGraphic = true;
			Item.channel = true;
			Item.width = 34;
			Item.height = 22;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.mana = 10;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 75);
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<ClamClapperProj>();
			Item.shootSpeed = 0f;
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[ModContent.ProjectileType<ClamClapperProj>()] < 1;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Projectile.NewProjectile(source, position.X, position.Y, 0, 0, ModContent.ProjectileType<ClamClapperProj>(), damage, knockback, player.whoAmI, 0f, 0f);

			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<ClamShell>(), 12)
			.AddIngredient(ItemID.WhitePearl, 1)
			.AddTile(ModContent.TileType<Shellforge>())
			.Register();
		}
	}
}