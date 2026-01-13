using Terraria.GameContent.Bestiary;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Items.Consumables.PotSnails;

namespace WaasephisFishingPlus.Content.NPCs.Passive.PotSnails
{
	public class PotSnailDesert : ModNPC
	{
		public override void SetStaticDefaults()
		{
            Main.npcCatchable[NPC.type] = true;
            Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.width = 42;
			NPC.height = 30;
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
            NPC.catchItem = (short)ModContent.ItemType<PotSnailDesertItem>();
        }

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.Player.ZoneUndergroundDesert && !spawnInfo.Player.ZoneDungeon ? 0.5f : 0f;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
			   BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert,
				new FlavorTextBestiaryInfoElement("Mods.WaasephisFishingPlus.Bestiary.PotSnail")
			});
		}

        public override void HitEffect(NPC.HitInfo hit)
        {
			int amount = NPC.life <= 0 ? 10 : 2;
            if (NPC.life <= 0)
            {
                Projectile.NewProjectile(NPC.GetSource_Death(), NPC.Center.X, NPC.Center.Y, Main.rand.Next(-2, 2), -3,
                ModContent.ProjectileType<PotSnailDesertPot>(), NPC.damage, 0, NPC.target, 0, 0);
            }
            for (int i = 0; i < amount; i++)
			{
				Dust dust = Dust.NewDustDirect(NPC.position, NPC.width + 4, NPC.height + 4, DustID.Sand, Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f));
				dust.velocity *= 0.8f;
			}
		}
	}
}