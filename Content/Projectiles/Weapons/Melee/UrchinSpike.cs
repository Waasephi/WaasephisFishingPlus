using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Content.Projectiles.Weapons.Melee
{
	public class UrchinSpike : ModProjectile
	{
		//public override void SetStaticDefaults() => DisplayName.SetDefault("Unicorn Spike");

		public override void SetDefaults()
		{
			Projectile.friendly = true;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.DamageType = DamageClass.Ranged;

			Projectile.height = 10;
			Projectile.width = 16;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 300;
			Projectile.aiStyle = 2;
		}
		public override bool? CanHitNPC(NPC target)
		{
			return Projectile.ai[0] >= 60;
		}
		public override void AI()
		{
			Projectile.ai[0]++;
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.Kill();
			return false;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.Venom, 120);
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
			for (int i = 0; i < 5; i++)
			{
				int d = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Venom);
				Main.dust[d].scale = 1f;
			}
		}

		public override bool PreAI()
		{
			//Projectile.rotation += 0.1f;
			return true;
		}
	}
}