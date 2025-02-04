using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using WaasephisFishingPlus.Tiles.Crates;
using WaasephisFishingPlus.Items.Fish.QuestFish;
using System.Collections.Generic;
using WaasephisFishingPlus.Items.Weapons.Summoner;
using WaasephisFishingPlus.Items.Fish;
using Terraria.ID;
using WaasephisFishingPlus.Items.FishingRods;
using Microsoft.CodeAnalysis;
using System.Security.Policy;
using WaasephisFishingPlus.Items.Pets;
using WaasephisFishingPlus.Core;

namespace WaasephisFishingPlus.Core
{
	public class WaasephisFishingPlusPlayer : ModPlayer
	{

        // Pets	
        public bool possessedCandle;

        public override void ResetEffects()
        {
            // Pets
            possessedCandle = false;
        }

        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
		{
            #region Bools
            bool inWater = !attempt.inLava && !attempt.inHoney;
			bool inJungle = Player.ZoneJungle;
			bool inTundra = Player.ZoneSnow;
            bool inCorruption = Player.ZoneCorrupt;
            bool inEvil = Player.ZoneCorrupt || Player.ZoneCrimson;
            bool inSky = Player.ZoneNormalSpace;
            bool inMeteor = Player.ZoneMeteor;
			bool hardmode = Main.hardMode;
			bool restlessJungle = NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3;
            bool underground = Player.ZoneNormalUnderground || Player.ZoneNormalCaverns;
            bool undergroundJungle = (Player.ZoneDirtLayerHeight || Player.ZoneRockLayerHeight) && Player.ZoneJungle;
            #endregion

            #region Custom Catches

            #region Interstellar Caster
            if (inWater && underground && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<InterstellarCaster>())
            {
                int[] Tier1Ores = { ItemID.CopperOre, ItemID.TinOre, ItemID.IronOre, ItemID.LeadOre,
                ItemID.SilverOre, ItemID.TungstenOre, ItemID.GoldOre, ItemID.PlatinumOre };

                itemDrop = Main.rand.Next(Tier1Ores);
                return;
            }

            if (inWater && inEvil && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<InterstellarCaster>())
            {
                int[] EvilOres = { ItemID.DemoniteOre, ItemID.CrimtaneOre };
                itemDrop = Main.rand.Next(EvilOres);
                return;
            }

            if (inWater && Player.ZoneMeteor && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<InterstellarCaster>())
            {
                itemDrop = ItemID.Meteorite;
                return;
            }

            if (attempt.inLava && Player.ZoneUnderworldHeight && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<InterstellarCaster>())
            {
                int[] HellOres = { ItemID.Obsidian, ItemID.Hellstone, ItemID.Hellstone, ItemID.Hellstone };
                itemDrop = Main.rand.Next(HellOres);
                return;
            }
            #endregion

            #endregion

            #region Fish

            if (inWater && underground && attempt.veryrare && Player.fishingSkill >= 40 && Main.rand.NextBool(5))
            {
                itemDrop = ModContent.ItemType<Heartang>();
            }

            if (inWater && inCorruption && attempt.uncommon && Main.rand.NextBool(5))
            {
                itemDrop = ModContent.ItemType<Ebonthodian>();
            }

            if (inWater && inMeteor && attempt.uncommon && Main.rand.NextBool(3))
            {
                itemDrop = ModContent.ItemType<Asterovy>();
            }

            if (inWater && undergroundJungle && attempt.uncommon && Main.rand.NextBool(3))
            {
                itemDrop = ModContent.ItemType<SporeSnapper>();
            }

            if (attempt.inHoney && attempt.uncommon && Main.rand.NextBool(3))
            {
                itemDrop = ModContent.ItemType<Gobee>();
            }

            if (inWater && attempt.veryrare && NPC.downedTowerSolar && Main.rand.NextBool(8))
            {
                itemDrop = ModContent.ItemType<Solamola>();
            }

            if (inWater && attempt.veryrare && NPC.downedTowerStardust && Main.rand.NextBool(8))
            {
                itemDrop = ModContent.ItemType<Stardustfish>();
            }

            if (inWater && attempt.veryrare && NPC.downedTowerNebula && Main.rand.NextBool(8))
            {
                itemDrop = ModContent.ItemType<Nebulagazer>();
            }

            if (inWater && attempt.veryrare && NPC.downedTowerVortex && Main.rand.NextBool(8))
            {
                itemDrop = ModContent.ItemType<Vortexeye>();
            }
            #endregion

            #region Crates

            if (inWater && inJungle && hardmode && restlessJungle && attempt.crate && attempt.uncommon)
			{
				itemDrop = ModContent.ItemType<OvergrownCrate>();
            }

            if (inWater && inTundra && hardmode && attempt.crate && attempt.uncommon)
            {
                itemDrop = ModContent.ItemType<FrigidCrate>();
            }

            if (inWater && Player.ZoneDungeon && hardmode && NPC.downedPlantBoss && attempt.crate && attempt.uncommon)
            {
                itemDrop = ModContent.ItemType<CryptCoffin>();
            }
            #endregion

            #region Weapons

            if (NPC.downedMartians && inSky && attempt.legendary)
            {
                itemDrop = ModContent.ItemType<Scutleel>();
            }
            #endregion

            #region Quest Fish

            int mecherel = ModContent.ItemType<Mecherel>();
            int garnite = ModContent.ItemType<Garnite>();

            if (attempt.questFish == mecherel)
            {
                if (attempt.uncommon)
                {
                    itemDrop = mecherel;
                    return;
                }
            }

            if (Player.ZoneGranite && attempt.questFish == garnite)
            {
                if (attempt.uncommon)
                {
                    itemDrop = garnite;
                    return;
                }
            }
            #endregion

            #region Other

            if (inWater && hardmode && attempt.legendary && Player.fishingSkill >= 75 && Main.rand.NextBool(10))
            {
                itemDrop = ModContent.ItemType<KeyShard>();
                return;
            }

            if (inWater && Player.ZoneBeach && attempt.veryrare && Player.fishingSkill >= 30 && Main.rand.NextBool(5))
            {
                itemDrop = ModContent.ItemType<SeaCarrot>();
                return;
            }

            if (inWater && Player.ZoneDungeon && attempt.rare && Player.fishingSkill >= 20 && Main.rand.NextBool(10))
            {
                itemDrop = ItemID.BoneWelder;
                return;
            }

            if (attempt.inLava && attempt.rare && Main.rand.NextBool(5))
            {
                itemDrop = ItemID.ObsidianRose;
                return;
            }

            #endregion

        }

    }
}