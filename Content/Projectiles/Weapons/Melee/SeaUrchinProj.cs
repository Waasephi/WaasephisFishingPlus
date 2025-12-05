using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Content.Projectiles.Weapons.Melee
{
	public class SeaUrchinProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			// The following sets are only applicable to yoyo that use aiStyle 99.
			// YoyosLifeTimeMultiplier is how long in seconds the yoyo will stay out before automatically returning to the player.
			// Vanilla values range from 3f(Wood) to 16f(Chik), and defaults to -1f. Leaving as -1 will make the time infinite.
			ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 8f;
			// YoyosMaximumRange is the maximum distance the yoyo sleep away from the player.
			// Vanilla values range from 130f(Wood) to 400f(Terrarian), and defaults to 200f
			ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 250f;
			// YoyosTopSpeed is top speed of the yoyo projectile.
			// Vanilla values range from 9f(Wood) to 17.5f(Terrarian), and defaults to 10f
			ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 10f;
		}

		public override void SetDefaults()
		{
			Projectile.extraUpdates = 0;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = ProjAIStyleID.Yoyo;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.scale = 1f;
		}

		// notes for aiStyle 99:
		// localAI[0] is used for timing up to YoyosLifeTimeMultiplier
		// localAI[1] can be used freely by specific types
		// ai[0] and ai[1] usually point towards the x and y world coordinate hover point
		// ai[0] is -1f once YoyosLifeTimeMultiplier is reached, when the player is stoned/frozen, when the yoyo is too far away, or the player is no longer clicking the shoot button.
		// ai[0] being negative makes the yoyo move back towards the player
		// Any AI method can be used for dust, spawning projectiles, etc specific to your yoyo.
		public override void AI()
		{
			Projectile.rotation -= 12f;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.Venom, 15);
			SoundEngine.PlaySound(SoundID.Item54, Projectile.position);
			SoundEngine.PlaySound(SoundID.Item95, Projectile.Center);
			for (int i = 0; i < 1; i++)
			{
				Projectile.NewProjectile(Terraria.Entity.InheritSource(Projectile), Projectile.Center, new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-5, 5)),
				ModContent.ProjectileType<UrchinSpike>(), (int)(Projectile.damage * 0.5), Projectile.knockBack, Projectile.owner);
			}
			for (int num623 = 0; num623 < 50; num623++)
			{
				int num624 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Venom, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num624].noGravity = true;
				Main.dust[num624].velocity *= 1.4f;
			}
		}

		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Water);
				dust.noGravity = false;
				dust.scale = 1.2f;
			}
		}
	}
}