using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Items.Accessories;
using WaasephisFishingPlus.Items.FishingRods;
using WaasephisFishingPlus.Items.Pets.LightPets;

namespace WaasephisFishingPlus.Core
{
    public class WaasephisFishingPlusGlobalNPC : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
			if (npc.type == NPCID.DukeFishron)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RegalScepter>(), 3));

			if (npc.type == NPCID.AnglerFish)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AnglerLantern>(), 15));

			if (npc.type == NPCID.AngryNimbus)
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HappyNimbus>(), 10));
		}
    }
}