using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Content.Projectiles.Weapons.Generic
{
	public class WaterShotProj : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.WaterStream);
			AIType = ProjectileID.WaterStream;
			Projectile.penetrate = 1;
		}

		public override bool? CanHitNPC(NPC target)
		{
			return Projectile.ai[0] >= 20;
		}
		public override void AI()
		{
			Projectile.ai[0]++;
		}
	}
}