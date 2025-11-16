using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Buffs.Pets;

namespace WaasephisFishingPlus.Content.Projectiles.Pets
{
	public class SeaSlug : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 8;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Bunny);
			AIType = ProjectileID.Bunny;
            Projectile.width = 48;
            Projectile.height = 36;
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
		}

		private bool CheckActive(Player owner)
		{
			if (owner.dead || !owner.active)
			{
				owner.ClearBuff(ModContent.BuffType<SeaSlugBuff>());

				return false;
			}

			if (owner.HasBuff(ModContent.BuffType<SeaSlugBuff>()))
			{
				Projectile.timeLeft = 2;
			}

			return true;
		}
	}
}