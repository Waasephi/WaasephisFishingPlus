using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Items.Materials;
using WaasephisFishingPlus.Content.Projectiles.Weapons.Generic;
using WaasephisFishingPlus.Content.Tiles.Decor;

namespace WaasephisFishingPlus.Content.Items.Weapons.Ranged
{
	public class PearlMortar : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.damage = 48;
			Item.crit = 18;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 84;
			Item.height = 34;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.holdStyle = ItemHoldStyleID.HoldHeavy;
			Item.noMelee = true;
			Item.knockBack = 10;
			Item.value = Item.sellPrice(gold: 1, silver: 50);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item61;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<WhitePearlProj>();
			Item.shootSpeed = 12f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-20f, 0f);
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (Main.rand.NextBool(3))
			{
				velocity *= 0.8f;
				type = ModContent.ProjectileType<ClamBubbleProj>();
				SoundEngine.PlaySound(SoundID.Item111);
			}

			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 60f;

			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ClamShell>(), 10);
			recipe.AddIngredient(ItemID.WhitePearl, 2);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddTile(ModContent.TileType<Shellforge>());
			recipe.Register();
		}
	}
}