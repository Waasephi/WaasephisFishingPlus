using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace WaasephisFishingPlus.Content.Projectiles.Weapons.Generic
{
	public class WhitePearlProj : ModProjectile
	{

		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.DripplerFlailExtraBall);
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			AIType = ProjectileID.DripplerFlailExtraBall;
			Projectile.DamageType = DamageClass.Generic;
		}

		public override void Kill(int timeLeft)
		{
			{
				SoundEngine.PlaySound(SoundID.Item50, Projectile.position);
				Vector2 usePos = Projectile.position;
				Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);

				Projectile.spriteDirection = Projectile.direction = (Projectile.velocity.X > 0).ToDirectionInt();

				for (int num623 = 0; num623 < 50; num623++)
				{
					int num624 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.TreasureSparkle, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num624].noGravity = true;
					Main.dust[num624].velocity *= 1.5f;
				}
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.Kill();
			return false;
		}

		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int height = texture.Height;
			int y = height * Projectile.frame;
			Rectangle rect = new(0, y, texture.Width, height);
			Vector2 origin = new(texture.Width, Projectile.height);
			for (int k = 0; k < Projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + origin + new Vector2(0f, Projectile.gfxOffY);
				Color color = Projectile.GetAlpha(Color.White) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
				Main.EntitySpriteDraw(texture, drawPos, new Rectangle?(rect), color, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0);
			}
			return true;
		}
	}
}