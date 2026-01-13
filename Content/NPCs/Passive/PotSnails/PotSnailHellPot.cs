using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Content.NPCs.Passive.PotSnails
{
    public class PotSnailHellPot : ModProjectile
    {

        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.DamageType = DamageClass.Ranged;

            Projectile.height = 24;
            Projectile.width = 20;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 300;
            Projectile.aiStyle = ProjAIStyleID.ThrownProjectile;
        }
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.Kill();
			return false;
		}
		public void SpawnItem(int Type, int Amount)
		{
			int newItem = Item.NewItem(Projectile.GetSource_Death(), Projectile.Hitbox, Type, Amount);
			NetMessage.SendData(MessageID.SyncItem, -1, -1, null, newItem, 1f);
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Shatter, Projectile.position);
			for (int i = 0; i < 5; i++)
			{
				int d = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Pot);
				Main.dust[d].scale = 1f;
			}
			if (Projectile.owner == Main.myPlayer)
			{
				int item = 0;

				SpawnItem(ItemID.DemonTorch, Main.rand.Next(1, 8));
				SpawnItem(ItemID.HealingPotion, Main.rand.Next(1, 3));

				if (Main.rand.NextBool(5))
				{
					SpawnItem(ItemID.Bomb, Main.rand.Next(1, 5));
				}

				if (Main.rand.NextBool(5))
				{
					SpawnItem(ItemID.Rope, Main.rand.Next(1, 15));
				}

				SpawnItem(ItemID.CopperCoin, Main.rand.Next(1, 90));
				SpawnItem(ItemID.SilverCoin, Main.rand.Next(1, 30));

				if (Main.rand.NextBool(5))
				{
					SpawnItem(ItemID.GoldCoin, 1);
				}
				if (Main.rand.NextBool(36))
				{
					Projectile.NewProjectile(Terraria.Entity.InheritSource(Projectile),
					Projectile.position, Vector2.Zero, ProjectileID.CoinPortal, 0, 0, Projectile.owner);
				}
				//drop some potions
				if (Main.rand.NextBool(5))
				{
					int[] BuffPotions = new int[] { ItemID.SpelunkerPotion, ItemID.FeatherfallPotion, ItemID.ManaRegenerationPotion, ItemID.ObsidianSkinPotion,
					ItemID.MagicPowerPotion, ItemID.InvisibilityPotion, ItemID.HunterPotion, ItemID.GravitationPotion, ItemID.ThornsPotion, ItemID. WaterWalkingPotion,
					ItemID.BattlePotion, ItemID.HeartreachPotion, ItemID.TitanPotion};

					SpawnItem(Main.rand.Next(BuffPotions), 1);
				}
				if (Main.rand.NextBool(4))
				{
					SpawnItem(ItemID.PotionOfReturn, 1);
				}
				if (Main.rand.NextBool(3))
				{
					int[] TeleportPotions = new int[] { ItemID.RecallPotion, ItemID.RecallPotion, ItemID.RecallPotion, ItemID.WormholePotion };

					SpawnItem(Main.rand.Next(TeleportPotions), 1);
				}

				if (Main.rand.NextBool(5))
				{
					SpawnItem(ItemID.Heart, Main.rand.Next(1, 2));
				}

				// Sync the drop for multiplayer
				// Note the usage of Terraria.ID.MessageID, please use this!
				if (Main.netMode == NetmodeID.MultiplayerClient && item >= 0)
				{
					NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item, 1f);
				}
			}
		}

		public override bool PreAI()
		{
			return true;
		}
	}
}