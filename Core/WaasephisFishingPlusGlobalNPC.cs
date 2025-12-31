using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Buffs;
using WaasephisFishingPlus.Content.Items.Accessories;
using WaasephisFishingPlus.Content.Items.Bait;
using WaasephisFishingPlus.Content.Items.FishingRods;
using WaasephisFishingPlus.Content.Items.Pets.LightPets;
using WaasephisFishingPlus.Content.Tiles.Decor;

namespace WaasephisFishingPlus.Core
{
    public class WaasephisFishingPlusGlobalNPC : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
			if (npc.type == NPCID.DukeFishron && !Main.expertMode)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RegalScepter>(), 3));

			if (npc.type == NPCID.AngryNimbus)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HappyNimbus>(), 10));

			if (npc.type == NPCID.BloodNautilus)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DreadnautilusTrophyItem>(), 10));

			if (npc.type == NPCID.AnglerFish)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AnglerLantern>(), 15));

			#region Fish Mush

			if (npc.type == NPCID.Goldfish)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FishMush>(), 4, 1, 3));

			if (npc.type == NPCID.CorruptGoldfish)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FishMush>(), 4, 1, 3));

			if (npc.type == NPCID.CrimsonGoldfish)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FishMush>(), 4, 1, 3));

			if (npc.type == NPCID.GoldGoldfish)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FishMush>(), 1, 5, 8));

			if (npc.type == NPCID.Pupfish)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FishMush>(), 5, 1, 2));

			if (npc.type == NPCID.EyeballFlyingFish)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FishMush>(), 2, 2, 4));

			if (npc.type == NPCID.Piranha)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FishMush>(), 7, 1, 4));

			if (npc.type == NPCID.FlyingFish)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FishMush>(), 5, 2, 5));

			if (npc.type == NPCID.Shark)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FishMush>(), 5, 1, 3));

			if (npc.type == NPCID.SandShark)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FishMush>(), 4, 2, 4));

			if (npc.type == NPCID.SandsharkCorrupt)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FishMush>(), 4, 2, 4));

			if (npc.type == NPCID.SandsharkCrimson)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FishMush>(), 4, 2, 4));

			if (npc.type == NPCID.SandsharkHallow)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FishMush>(), 4, 2, 4));

			if (npc.type == NPCID.AnglerFish)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FishMush>(), 2, 2, 4));

			if (npc.type == NPCID.Arapaima)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FishMush>(), 3, 3, 6));
			#endregion
		}

		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
			if (player.HasBuff(ModContent.BuffType<TackleBoxBuff>()))
			{
				maxSpawns /= 2;
			}
		}
    }
}