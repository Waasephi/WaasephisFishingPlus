using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using WaasephisFishingPlus.Tiles.Crates;
using WaasephisFishingPlus.Items.Fish.QuestFish;
using WaasephisFishingPlus.Items.Weapons.Summoner;
using WaasephisFishingPlus.Items.Fish;
using Terraria.ID;
using WaasephisFishingPlus.Items.FishingRods;
using WaasephisFishingPlus.Items.Pets;
using WaasephisFishingPlus.Items.Weapons.Melee;
using WaasephisFishingPlus.NPCs.Hostile;

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
			bool temple = Main.hardMode && NPC.downedPlantBoss && Player.ZoneLihzhardTemple;
			bool aether = Player.ZoneShimmer;
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

            if (inWater && underground && attempt.rare && Player.fishingSkill >= 20 && Main.rand.NextBool(5))
            {
                itemDrop = ModContent.ItemType<Heartang>();
            }

			if (inWater && inCorruption && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ModContent.ItemType<Ebonthodian>();
			}

			if (inWater && Player.ZoneGraveyard && attempt.uncommon && Player.fishingSkill >= 30 && Main.rand.NextBool(3))
			{
				itemDrop = ModContent.ItemType<Ectolione>();
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

            if (inWater && attempt.veryrare && inSky && NPC.downedTowerSolar && Main.rand.NextBool(8))
            {
                itemDrop = ModContent.ItemType<Solamola>();
            }

            if (inWater && attempt.veryrare && inSky && NPC.downedTowerStardust && Main.rand.NextBool(8))
            {
                itemDrop = ModContent.ItemType<Stardustfish>();
            }

            if (inWater && attempt.veryrare && inSky && NPC.downedTowerNebula && Main.rand.NextBool(8))
            {
                itemDrop = ModContent.ItemType<Nebulagazer>();
            }

            if (inWater && attempt.veryrare && inSky && NPC.downedTowerVortex && Main.rand.NextBool(8))
            {
                itemDrop = ModContent.ItemType<Vortexeye>();
            }
            #endregion

            #region Crates

            if (inWater && temple && attempt.crate && attempt.uncommon)
			{
				itemDrop = ModContent.ItemType<LihzahrdCrate>();
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

			if (inWater && Player.ZoneBeach && attempt.veryrare && Main.rand.NextBool(4))
			{
				itemDrop = ModContent.ItemType<SeaUrchin>();
			}
			#endregion

			#region Quest Fish

			int mecherel = ModContent.ItemType<Mecherel>();
			int garnite = ModContent.ItemType<Garnite>();
			int marbeel = ModContent.ItemType<Marbeel>();
			int santaray = ModContent.ItemType<SantaRay>();
			int aetherianAngler = ModContent.ItemType<AetherianAngler>();
			int hellstoneSnail = ModContent.ItemType<HellstoneSnail>();

			if (hardmode && NPC.downedMechBossAny && attempt.questFish == mecherel)
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

			if (Player.ZoneMarble && attempt.questFish == marbeel)
			{
				if (attempt.uncommon)
				{
					itemDrop = marbeel;
					return;
				}
			}

			if (NPC.downedBoss2 && aether && inWater && attempt.questFish == aetherianAngler)
			{
				if (attempt.uncommon)
				{
					itemDrop = aetherianAngler;
					return;
				}
			}

			if (NPC.downedBoss2 && attempt.CanFishInLava && Player.ZoneUnderworldHeight && attempt.inLava && attempt.questFish == hellstoneSnail)
			{
				if (attempt.uncommon)
				{
					itemDrop = hellstoneSnail;
					return;
				}
			}

			if (Player.ZoneSnow && hardmode && attempt.questFish == santaray)
			{
				if (attempt.uncommon)
				{
					itemDrop = santaray;
					return;
				}
			}
			#endregion

			#region Other

            if (inWater && Player.ZoneBeach && attempt.veryrare && Player.fishingSkill >= 30 && Main.rand.NextBool(8))
            {
                itemDrop = ModContent.ItemType<SeaCarrot>();
                return;
            }

            if (inWater && Player.ZoneDungeon && attempt.rare && Player.fishingSkill >= 20 && Main.rand.NextBool(20))
            {
                itemDrop = ItemID.BoneWelder;
                return;
            }

			#endregion

			#region NPC Catches

			if (attempt.inLava && Player.ZoneUnderworldHeight && attempt.uncommon && attempt.fishingLevel >= 30 && Main.rand.NextBool(5))
			{
				npcSpawn = ModContent.NPCType<LavaShark>();
				return;
			}

			#endregion
		}
	}
}