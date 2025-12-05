using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Tiles.Banners;
using WaasephisFishingPlus.Content.Items.Materials;

namespace WaasephisFishingPlus.Content.NPCs.Hostile
{
	public class ClamPearl : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.width = 30;
			NPC.height = 24;
			NPC.damage = 25;
			NPC.lifeMax = 50;
			NPC.life = 50;
			NPC.defense = 10;
			NPC.lavaImmune = false;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = 200f;
			NPC.knockBackResist = 1f;
			NPC.aiStyle = NPCAIStyleID.Herpling;
			NPC.noGravity = false;
			AIType = NPCID.Herpling;
			AnimationType = NPCID.Derpling;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<ClamBanner>();
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ClamShell>(), 1, 1, 6));
			npcLoot.Add(ItemDropRule.Common(ItemID.WhitePearl, 4, 1, 2));
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
			   BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
				new FlavorTextBestiaryInfoElement("Mods.WaasephisFishingPlus.Bestiary.Clam"),
			});
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			int amount = NPC.life <= 0 ? 10 : 2;

			for (int i = 0; i < amount; i++)
			{
				Dust dust = Dust.NewDustDirect(NPC.position, NPC.width + 4, NPC.height + 4, DustID.Water, Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f));
				dust.velocity *= 0.8f;
			}
		}
	}
}