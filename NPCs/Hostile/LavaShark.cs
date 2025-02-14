using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Tiles.Banners;

namespace WaasephisFishingPlus.NPCs.Hostile
{
	public class LavaShark : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.width = 120;
			NPC.height = 42;
			NPC.damage = 60;
			NPC.lifeMax = 600;
			NPC.life = 600;
			NPC.defense = 5;
			NPC.lavaImmune = true;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = 100f;
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = 16;
			NPC.noGravity = true;
			AIType = NPCID.Shark;
			AnimationType = NPCID.Shark;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<LavaSharkBanner>();
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ItemID.ObsidianRose, 20));
			npcLoot.Add(ItemDropRule.Common(ItemID.SuperheatedBlood, 10));
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
			   BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,
				new FlavorTextBestiaryInfoElement("A shark that evolved to have scales as tough as obsidian, these scales are incredibly heatproof, giving immunity to lava.")
			});
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			int amount = NPC.life <= 0 ? 10 : 2;

			for (int i = 0; i < amount; i++)
			{
				Dust dust = Dust.NewDustDirect(NPC.position, NPC.width + 4, NPC.height + 4, DustID.Obsidian, Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f));
				dust.velocity *= 0.8f;
			}
		}
	}
}