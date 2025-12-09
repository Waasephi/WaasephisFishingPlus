using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Projectiles.Weapons.Generic;
using WaasephisFishingPlus.Core;

namespace WaasephisFishingPlus.Content.Projectiles.Weapons.Magic
{
	public class ClamClapperProj : ModProjectile
	{
		int playerCenterOffset = 4;
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 2;
		}

		public override void SetDefaults()
		{
			Projectile.width = 22;
			Projectile.height = 48;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.friendly = true;
			Projectile.tileCollide = false;
			Projectile.netImportant = true;
			Projectile.timeLeft = 5;
			Projectile.penetrate = -1;
			Projectile.aiStyle = -1;
		}

		public override bool? CanDamage()
		{
			return false;
		}

		public override bool? CanCutTiles()
		{
			return false;
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];

            if (!player.active || player.dead || player.noItems || player.CCed) 
            {
                Projectile.Kill();
            }

            if (Projectile.owner == Main.myPlayer)
            {
                Vector2 ProjDirection = Main.MouseWorld - new Vector2(Projectile.Center.X, Projectile.Center.Y - playerCenterOffset);
                ProjDirection.Normalize();
                Projectile.ai[0] = ProjDirection.X;
				Projectile.ai[1] = ProjDirection.Y;
            }

            Vector2 direction = new Vector2(Projectile.ai[0], Projectile.ai[1]);

            Projectile.direction = Projectile.spriteDirection = direction.X > 0 ? 1 : -1;

            if (Projectile.direction >= 0)
            {
                Projectile.rotation = direction.ToRotation() - 1.57f * (float)Projectile.direction;
            }
            else
            {
                Projectile.rotation = direction.ToRotation() + 1.57f * (float)Projectile.direction;
            }

            player.itemRotation = Projectile.rotation;
            player.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, player.itemRotation);

            Projectile.position = new Vector2(player.MountedCenter.X - Projectile.width / 2, player.MountedCenter.Y - 5 - Projectile.height / 2);

			if (player.channel)
			{
				Projectile.timeLeft = 2;

				Projectile.localAI[0]++;

				if (Projectile.localAI[0] >= ItemGlobal.ActiveItem(player).useTime && Projectile.frame < 1)
				{
					Projectile.frame++;

					Projectile.localAI[0] = 0;
				}

				if (Projectile.localAI[0] >= ItemGlobal.ActiveItem(player).useTime / 5 && Projectile.frame >= 1)
				{

					for (int num623 = 0; num623 < 50; num623++)
					{
						int num624 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Water, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num624].noGravity = true;
						Main.dust[num624].velocity *= 1.4f;
					}

					if (Projectile.localAI[0] > 0 && player.CheckMana(ItemGlobal.ActiveItem(player), ItemGlobal.ActiveItem(player).mana, false, false))
					{
						player.statMana -= ItemGlobal.ActiveItem(player).mana;
					}

					SoundEngine.PlaySound(SoundID.Item50, Projectile.Center);

					if (Projectile.owner == Main.myPlayer)
					{
						Vector2 ShootSpeed = Main.MouseWorld - new Vector2(Projectile.Center.X, Projectile.Center.Y - playerCenterOffset);
						ShootSpeed.Normalize();
						ShootSpeed *= 10;

						Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center.X, Projectile.Center.Y - playerCenterOffset,
						ShootSpeed.X, ShootSpeed.Y, ModContent.ProjectileType<ClamBubbleProj>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
					}

					Projectile.frame = 0;
					Projectile.localAI[0] = 0;
				}

				if (direction.X > 0)
				{
					player.direction = 1;
				}
				else
				{
					player.direction = -1;
				}
			}
			else
			{
				Projectile.active = false;
			}

			player.heldProj = Projectile.whoAmI;
			player.SetDummyItemTime(2);
		}
	}
}