using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Content.Projectiles.Weapons.Generic
{
	class ClamBubbleProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 4;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.timeLeft = 200;
			Projectile.height = 32;
			Projectile.width = 32;
			Projectile.penetrate = 1;
			AIType = ProjectileID.Bullet;
			Projectile.extraUpdates = 1;
		}
		

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item54, Projectile.position);
			for (int i = 0; i < Main.rand.Next(2, 3); i++)
			{
				Projectile.NewProjectile(Terraria.Entity.InheritSource(Projectile), Projectile.Center, new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-2, -5)),
				ModContent.ProjectileType<WaterShotProj>(), (int)(Projectile.damage), Projectile.knockBack, Projectile.owner);
			}
			for (int num623 = 0; num623 < 50; num623++)
			{
				int num624 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Water, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num624].noGravity = true;
				Main.dust[num624].velocity *= 1.4f;
			}
		}
		public override bool PreAI()
		{
			Projectile.alpha++;
			float num = 1f - (float)Projectile.alpha / 255f;
			Projectile.rotation = 1.5f;
			Projectile.velocity *= .98f;
			num *= Projectile.scale;
			Lighting.AddLight(Projectile.Center, 0.3f * num, 0.2f * num, 0.1f * num);
			Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) * 1.5f;
			return true;
		}


		public override bool PreDraw(ref Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
			for (int k = 0; k < Projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
				Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
				Main.spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
			}
			return false;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(150, 150, 150, 80);
		}

	}
}