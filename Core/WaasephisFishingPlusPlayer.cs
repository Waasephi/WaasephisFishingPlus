using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.ID;
using WaasephisFishingPlus.Content.Tiles.Crates;
using WaasephisFishingPlus.Content.NPCs.Hostile;
using WaasephisFishingPlus.Content.Items.Fish.QuestFish;
using WaasephisFishingPlus.Content.Items.Fish;
using WaasephisFishingPlus.Content.Items.FishingRods;
using WaasephisFishingPlus.Content.Items.Pets;
using WaasephisFishingPlus.Content.Items.Weapons.Melee;
using WaasephisFishingPlus.Content.Items.Weapons.Ranged;

namespace WaasephisFishingPlus.Core
{
	public class WaasephisFishingPlusPlayer : ModPlayer
	{
        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
		{
            #region Bools
            bool inWater = !attempt.inLava && !attempt.inHoney;
            bool inEvil = Player.ZoneCorrupt || Player.ZoneCrimson;
            bool underground = Player.ZoneNormalUnderground || Player.ZoneNormalCaverns;
            bool undergroundJungle = (Player.ZoneDirtLayerHeight || Player.ZoneRockLayerHeight) && Player.ZoneJungle;
			bool underBeach = Player.ZoneBeach && Player.ZoneDirtLayerHeight;
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

			#region Hallowed Dredger

			#region PreHM Crates
			if (inWater && !Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.common && Main.rand.NextBool(3))
			{
				itemDrop = ItemID.WoodenCrate;
				return;
			}

			if (inWater && !Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ItemID.IronCrate;
				return;
			}

			if (inWater && !Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.rare && Main.rand.NextBool(7))
			{
				itemDrop = ItemID.GoldenCrate;
				return;
			}

			if (inWater && Player.ZoneCorrupt && !Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ItemID.CorruptFishingCrate;
				return;
			}

			if (inWater && Player.ZoneCrimson && !Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ItemID.CrimsonFishingCrate;
				return;
			}

			if (inWater && Player.ZoneJungle && !Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.rare && Main.rand.NextBool(5))
			{
				itemDrop = ItemID.JungleFishingCrate;
				return;
			}

			if (inWater && Player.ZoneSnow && !Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ItemID.FrozenCrate;
				return;
			}

			if (inWater && Player.ZoneHallow && !Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ItemID.HallowedFishingCrate;
				return;
			}

			if (inWater && Player.ZoneDesert || Player.ZoneUndergroundDesert && !Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.rare && Main.rand.NextBool(5))
			{
				itemDrop = ItemID.OasisCrate;
				return;
			}

			if (inWater && Player.ZoneNormalSpace && !Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ItemID.FloatingIslandFishingCrate;
				return;
			}

			if (attempt.inLava && !Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ItemID.LavaCrate;
				return;
			}

			if (inWater && Player.ZoneBeach && !Main.hardMode && attempt.crate && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ItemID.OceanCrate;
				return;
			}

			if (inWater && Player.ZoneDungeon && !Main.hardMode && attempt.crate && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ItemID.OceanCrate;
				return;
			}

			#endregion

			#region HM Crates
			if (inWater && Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.common && Main.rand.NextBool(3))
			{
				itemDrop = ItemID.WoodenCrateHard;
				return;
			}

			if (inWater && Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ItemID.IronCrateHard;
				return;
			}

			if (inWater && Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.rare && Main.rand.NextBool(7))
			{
				itemDrop = ItemID.GoldenCrateHard;
				return;
			}

			if (inWater && Player.ZoneCorrupt && Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ItemID.CorruptFishingCrateHard;
				return;
			}

			if (inWater && Player.ZoneCrimson && Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ItemID.CrimsonFishingCrateHard;
				return;
			}

			if (inWater && Player.ZoneJungle && Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ItemID.JungleFishingCrateHard;
				return;
			}

			if (inWater && Player.ZoneSnow && Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ItemID.FrozenCrateHard;
				return;
			}

			if (inWater && Player.ZoneHallow && Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ItemID.HallowedFishingCrateHard;
				return;
			}

			if (inWater && Player.ZoneDesert || Player.ZoneUndergroundDesert && Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ItemID.OasisCrateHard;
				return;
			}

			if (inWater && Player.ZoneNormalSpace && Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ItemID.FloatingIslandFishingCrateHard;
				return;
			}

			if (attempt.inLava && Main.hardMode && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ItemID.LavaCrateHard;
				return;
			}

			if (inWater && Player.ZoneBeach && Main.hardMode && attempt.crate && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ItemID.OceanCrateHard;
				return;
			}

			#endregion

			#region Modded Crates
			if (inWater && Main.hardMode && NPC.downedPlantBoss && Player.ZoneLihzhardTemple && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.rare && Main.rand.NextBool(7))
			{
				itemDrop = ModContent.ItemType<LihzahrdCrate>();
				return;
			}

			if (inWater && Main.hardMode && NPC.downedPlantBoss && Player.ZoneDungeon && ItemGlobal.ActiveItem(Player).type == ModContent.ItemType<HallowedDredger>() && attempt.rare && Main.rand.NextBool(7))
			{
				itemDrop = ModContent.ItemType<LihzahrdCrate>();
				return;
			}

			#endregion

			#endregion

			#region Fish

			if (inWater && Player.ZoneSandstorm && Player.ZoneDesert && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ModContent.ItemType<AncientSquid>();
			}

			if (inWater && Player.ZoneMeteor && attempt.uncommon && Main.rand.NextBool(3))
			{
				itemDrop = ModContent.ItemType<Asterovy>();
			}

			if (inWater && Player.ZoneCorrupt && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ModContent.ItemType<Ebonthodian>();
			}

			if (inWater && Player.ZoneGraveyard && attempt.uncommon && Player.fishingSkill >= 30 && Main.rand.NextBool(3))
			{
				itemDrop = ModContent.ItemType<Ectolione>();
			}

			if (inWater && Player.ZoneOldOneArmy && NPC.downedGolemBoss && attempt.rare && Player.fishingSkill >= 40 && Main.rand.NextBool(3))
			{
				itemDrop = ModContent.ItemType<EtherianSeadragon>();
			}

			if (attempt.inHoney && attempt.uncommon && Main.rand.NextBool(3))
			{
				itemDrop = ModContent.ItemType<Gobee>();
			}

			if (inWater && underground && attempt.rare && Player.fishingSkill >= 20 && Main.rand.NextBool(5))
            {
                itemDrop = ModContent.ItemType<Heartang>();
            }

			if (inWater && attempt.veryrare && Player.ZoneNormalSpace && NPC.downedTowerNebula && Main.rand.NextBool(8))
			{
				itemDrop = ModContent.ItemType<Nebulagazer>();
			}

			if (inWater && attempt.veryrare && Player.ZoneNormalSpace && NPC.downedTowerSolar && Main.rand.NextBool(8))
			{
				itemDrop = ModContent.ItemType<Solamola>();
			}

			if (inWater && undergroundJungle && attempt.uncommon && Main.rand.NextBool(3))
			{
				itemDrop = ModContent.ItemType<SporeSnapper>();
			}

			if (inWater && Player.ZoneBeach && attempt.rare && Main.rand.NextBool(5))
			{
				itemDrop = ModContent.ItemType<Squid>();
			}

			if (inWater && attempt.veryrare && Player.ZoneNormalSpace && NPC.downedTowerStardust && Main.rand.NextBool(8))
			{
				itemDrop = ModContent.ItemType<Stardustfish>();
			}

			if (inWater && attempt.rare && Player.ZoneNormalSpace && Player.fishingSkill >= 30 && Main.rand.NextBool(5))
			{
				itemDrop = ModContent.ItemType<SunRay>();
			}

			if (inWater && attempt.veryrare && Player.ZoneNormalSpace && NPC.downedTowerVortex && Main.rand.NextBool(8))
            {
                itemDrop = ModContent.ItemType<Vortexeye>();
            }

			if (inWater && Player.ZoneForest && attempt.common && Main.rand.NextBool(8))
			{
				itemDrop = ModContent.ItemType<Woodskip>();
			}

			#endregion

			#region Legendary Fish

			if (inWater && attempt.legendary && underBeach && Main.rand.NextBool(10))
			{
				itemDrop = ModContent.ItemType<Oarfish>();
			}

			if (inWater && NPC.downedMoonlord && attempt.legendary && Player.ZoneSkyHeight && Main.rand.NextBool(20))
			{
				itemDrop = ModContent.ItemType<RegalMoonsquid>();
			}

			if (attempt.inLava && attempt.CanFishInLava && attempt.legendary && Main.rand.NextBool(15))
			{
				itemDrop = ModContent.ItemType<Searobin>();
			}

			#endregion

			#endregion

			#region Crates

			if (inWater && Main.hardMode && NPC.downedPlantBoss && Player.ZoneLihzhardTemple && attempt.crate && attempt.rare)
			{
				itemDrop = ModContent.ItemType<LihzahrdCrate>();
            }

            if (inWater && Player.ZoneDungeon && Main.hardMode && NPC.downedPlantBoss && attempt.crate && attempt.legendary)
            {
                itemDrop = ModContent.ItemType<CryptCoffin>();
            }
			#endregion

			#region Weapons

			if (inWater && Player.ZoneBeach && attempt.veryrare && Main.rand.NextBool(15))
			{
				itemDrop = ModContent.ItemType<SeaUrchin>();
			}

			if (inWater && Player.ZoneCrimson && attempt.rare && Main.rand.NextBool(20))
			{
				itemDrop = ModContent.ItemType<FleshySpewer>();
			}
			#endregion

			#region Quest Fish

			int mecherel = ModContent.ItemType<Mecherel>();
			int garnite = ModContent.ItemType<Garnite>();
			int marbeel = ModContent.ItemType<Marbeel>();
			int santaray = ModContent.ItemType<SantaRay>();
			int aetherianAngler = ModContent.ItemType<AetherianAngler>();
			int hellstoneSnail = ModContent.ItemType<HellstoneSnail>();

			if (Main.hardMode && NPC.downedMechBossAny && attempt.questFish == mecherel)
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

			if (NPC.downedBoss2 && Player.ZoneShimmer && inWater && attempt.questFish == aetherianAngler)
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

			if (Main.hardMode && Player.ZoneSnow && attempt.questFish == santaray)
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

			if (attempt.inLava && Player.ZoneUnderworldHeight && attempt.CanFishInLava && attempt.uncommon && attempt.fishingLevel >= 30 && Main.rand.NextBool(5))
			{
				npcSpawn = ModContent.NPCType<LavaShark>();
				return;
			}

			if (inWater && Player.ZoneBeach && attempt.uncommon && attempt.fishingLevel >= 20 && Main.rand.NextBool(8))
			{
				npcSpawn = ModContent.NPCType<Clam>();
				return;
			}

			if (inWater && Player.ZoneBeach && attempt.rare && attempt.fishingLevel >= 20 && Main.rand.NextBool(4))
			{
				npcSpawn = ModContent.NPCType<ClamPearl>();
				return;
			}

			if (inWater && Player.ZoneBeach && attempt.veryrare && attempt.fishingLevel >= 20 && Main.rand.NextBool(3))
			{
				npcSpawn = ModContent.NPCType<ClamEnderPearl>();
				return;
			}

			#endregion
		}
	}
}