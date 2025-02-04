using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Items.FishingRods;

namespace WaasephisFishingPlus.Core
{
    public class WaasephisFishingPlusGlobalNPC : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.DukeFishron)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RegalScepter>(), 3));
        }
    }
}