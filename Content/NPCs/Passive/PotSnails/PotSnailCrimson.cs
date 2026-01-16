using Terraria.GameContent.Bestiary;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace WaasephisFishingPlus.Content.NPCs.Passive.PotSnails
{
	public class PotSnailCrimson : ModNPC
	{
		public override void SetStaticDefaults()
		{
            Main.npcCatchable[NPC.type] = true;
            Main.npcFrameCount[NPC.type] = 6;
			NPCID.Sets.CountsAsCritter[Type] = true;
		}

		public override void SetDefaults()
		{
			NPC.width = 36;
			NPC.height = 22;
			NPC.damage = 0;
			NPC.lifeMax = 5;
			NPC.life = 5;
			NPC.defense = 5;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = 100f;
			NPC.knockBackResist = 0f;
			NPC.aiStyle = NPCAIStyleID.Snail;
			AIType = NPCID.Snail;
			AnimationType = NPCID.Snail;
        }

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.Player.ZoneCrimson && (spawnInfo.Player.ZoneRockLayerHeight || spawnInfo.Player.ZoneDirtLayerHeight) && !spawnInfo.Player.ZoneDungeon ? 0.5f : 0f;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
			   BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCrimson,
				new FlavorTextBestiaryInfoElement("Mods.WaasephisFishingPlus.Bestiary.PotSnailCrimson")
			});
		}

		public void SpawnItem(int Type, int Amount)
		{
			int newItem = Item.NewItem(NPC.GetSource_Death(), NPC.Hitbox, Type, Amount);
			NetMessage.SendData(MessageID.SyncItem, -1, -1, null, newItem, 1f);
		}

		public override void HitEffect(NPC.HitInfo hit)
        {
			int amount = NPC.life <= 0 ? 10 : 2;
            if (NPC.life <= 0)
            {
                    int item = 0;
				SpawnItem(ItemID.CrimsonTorch, Main.rand.Next(1, 8));
				SpawnItem(ItemID.LesserHealingPotion, Main.rand.Next(1, 3));

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
					Projectile.NewProjectile(NPC.GetSource_Death(), NPC.position, Vector2.Zero,
					ProjectileID.CoinPortal, NPC.damage, 0, NPC.target, 0, 0);
				}
				//drop some potions
				if (Main.rand.NextBool(5))
				{
					int[] BuffPotions = new int[] { ItemID.IronskinPotion, ItemID.RegenerationPotion, ItemID.SpelunkerPotion, ItemID.ShinePotion, ItemID.FeatherfallPotion,
					ItemID.NightOwlPotion, ItemID.SwiftnessPotion, ItemID.WaterWalkingPotion, ItemID.MiningPotion, ItemID.ArcheryPotion, ItemID.CalmingPotion,
					ItemID. GillsPotion, ItemID.GravitationPotion, ItemID.BuilderPotion, ItemID.HunterPotion, ItemID.InvisibilityPotion, ItemID.TrapsightPotion,
					ItemID.ThornsPotion, ItemID.HeartreachPotion, ItemID.FlipperPotion};

					SpawnItem(Main.rand.Next(BuffPotions), 1);
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
            for (int i = 0; i < amount; i++)
			{
				Dust dust = Dust.NewDustDirect(NPC.position, NPC.width + 4, NPC.height + 4, DustID.Ichor, Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f));
				dust.velocity *= 0.8f;
			}
		}
	}
}