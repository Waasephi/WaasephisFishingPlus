using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using WaasephisFishingPlus.Tiles.Crates;
using WaasephisFishingPlus.Items.Fish.QuestFish;
using WaasephisFishingPlus.Items.Fish;
using Terraria.ID;
using WaasephisFishingPlus.Items.FishingRods;
using WaasephisFishingPlus.Items.Pets;
using WaasephisFishingPlus.Items.Weapons.Melee;
using WaasephisFishingPlus.NPCs.Hostile;
using Terraria.GameContent.Personalities;

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

			if (inWater && Player.ZoneCorrupt && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ModContent.ItemType<Ebonthodian>();
			}

			if (inWater && Player.ZoneForest && attempt.common && Main.rand.NextBool(8))
			{
				itemDrop = ModContent.ItemType<Woodskip>();
			}

			if (inWater && Player.ZoneSandstorm &&Player.ZoneDesert && attempt.uncommon && Main.rand.NextBool(5))
			{
				itemDrop = ModContent.ItemType<AncientSquid>();
			}

			if (inWater && Player.ZoneGraveyard && attempt.uncommon && Player.fishingSkill >= 30 && Main.rand.NextBool(3))
			{
				itemDrop = ModContent.ItemType<Ectolione>();
			}

			if (inWater && Player.ZoneMeteor && attempt.uncommon && Main.rand.NextBool(3))
            {
                itemDrop = ModContent.ItemType<Asterovy>();
            }

			if (inWater && undergroundJungle && attempt.uncommon && Main.rand.NextBool(3))
			{
				itemDrop = ModContent.ItemType<SporeSnapper>();
			}

			if (inWater && Player.ZoneBeach && attempt.uncommon && Main.rand.NextBool(3))
			{
				itemDrop = ModContent.ItemType<Squid>();
			}

			if (attempt.inHoney && attempt.uncommon && Main.rand.NextBool(3))
            {
                itemDrop = ModContent.ItemType<Gobee>();
            }

            if (inWater && attempt.veryrare && Player.ZoneNormalSpace && NPC.downedTowerSolar && Main.rand.NextBool(8))
            {
                itemDrop = ModContent.ItemType<Solamola>();
            }

            if (inWater && attempt.veryrare && Player.ZoneNormalSpace && NPC.downedTowerStardust && Main.rand.NextBool(8))
            {
                itemDrop = ModContent.ItemType<Stardustfish>();
            }

            if (inWater && attempt.veryrare && Player.ZoneNormalSpace && NPC.downedTowerNebula && Main.rand.NextBool(8))
            {
                itemDrop = ModContent.ItemType<Nebulagazer>();
            }

            if (inWater && attempt.veryrare && Player.ZoneNormalSpace && NPC.downedTowerVortex && Main.rand.NextBool(8))
            {
                itemDrop = ModContent.ItemType<Vortexeye>();
            }
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

			if (inWater && Player.ZoneBeach && attempt.veryrare && Main.rand.NextBool(6))
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

			#endregion
		}
	}
}