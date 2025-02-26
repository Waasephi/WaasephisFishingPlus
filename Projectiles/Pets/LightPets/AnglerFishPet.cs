using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Buffs.Pets.LightPets;

namespace WaasephisFishingPlus.Projectiles.Pets.LightPets
{
	public class AnglerFishPet : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 8;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.LightPet[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.SharkPup);
			AIType = ProjectileID.SharkPup;
		}

		public override void PostAI()
		{
		}
		public override void AI()
		{
			Player owner = Main.player[Projectile.owner];

			if (!CheckActive(owner))
			{
				return;
			}

			if (!Main.dedServ)
			{
				// Create some light based on the color of the line.
				Lighting.AddLight(Projectile.Center, Color.Yellow.ToVector3());
			}
		}

		private bool CheckActive(Player owner)
		{
			if (owner.dead || !owner.active)
			{
				owner.ClearBuff(ModContent.BuffType<AnglerFishBuff>());

				return false;
			}

			if (owner.HasBuff(ModContent.BuffType<AnglerFishBuff>()))
			{
				Projectile.timeLeft = 2;
			}

			return true;
		}
	}
}