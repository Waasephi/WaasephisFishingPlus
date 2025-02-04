using Terraria.GameContent.Bestiary;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.NPCs.Passive
{
    public class ShrimpCritter : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcCatchable[NPC.type] = true;
            Main.npcFrameCount[NPC.type] = 6;
        }

        public override void SetDefaults()
        {
            NPC.width = 24;
            NPC.height = 30;
            NPC.damage = 0;
            NPC.lifeMax = 5;
            NPC.life = 5;
            NPC.defense = 5;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 0f;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = 118;
            NPC.noGravity = true;
            AIType = NPCID.Seahorse;
            AnimationType = NPCID.Seahorse;
            NPC.catchItem = ItemID.Shrimp;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.Water && spawnInfo.Player.ZoneBeach ? 0.7f : 0f;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {

                for (int num621 = 0; num621 < 20; num621++)
                {
                    int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood);
                    Main.dust[dust].noGravity = false;
                    Main.dust[dust].velocity *= 0.5f;
                }
            }
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(
            [
               BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
                new FlavorTextBestiaryInfoElement("Despite the similarities in name, it cannot be used to make the Shrimp Po' Boy.")
            ]);
        }
    }
}