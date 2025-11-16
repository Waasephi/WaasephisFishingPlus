using Terraria.GameContent.Bestiary;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace WaasephisFishingPlus.Content.NPCs.Passive
{
    public class BombfishCritter : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcCatchable[NPC.type] = true;
            Main.npcFrameCount[NPC.type] = 6;
        }

        public override void SetDefaults()
        {
            NPC.width = 40;
            NPC.height = 36;
            NPC.damage = 0;
            NPC.lifeMax = 5;
            NPC.life = 5;
            NPC.defense = 20;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 0f;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = NPCAIStyleID.Piranha;
            NPC.noGravity = true;
            AIType = NPCID.Piranha;
            AnimationType = NPCID.Piranha;
            NPC.catchItem = ItemID.BombFish;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.Water ? 0.1f : 0f;
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

		public override void OnKill()
		{
			Projectile.NewProjectile(Terraria.Entity.InheritSource(NPC), NPC.Center, new Vector2(),
			ProjectileID.TNTBarrel, 100, 0f, Main.myPlayer);
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(
            [
               BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new FlavorTextBestiaryInfoElement("Mods.WaasephisFishingPlus.Bestiary.BombfishCritter"),
			]);
        }
    }
}