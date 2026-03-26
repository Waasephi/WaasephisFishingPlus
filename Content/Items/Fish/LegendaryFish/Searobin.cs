using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Achievements;
using WaasephisFishingPlus.Core;

namespace WaasephisFishingPlus.Content.Items.Fish.LegendaryFish
{
    public class Searobin : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 44;
            Item.height = 44;
            Item.value = Item.sellPrice(gold: 50);
			Item.rare = ModContent.RarityType<SearobinRarity>();
			Item.useTurn = true;
            Item.maxStack = 1;
        }
	}
}