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
			Projectile.DamageType = DamageClass.Magic;
			Projectile.friendly = true;
			Projectile.hostile = false;
			AIType = ProjectileID.WaterStream;
			Projectile.penetrate = 1;
		}
	}
}