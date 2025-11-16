using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Core;

namespace WaasephisFishingPlus.Content.Items.Fish
{
    public class Searobin : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 30;
            Item.value = Item.sellPrice(gold: 50);
			Item.rare = ModContent.RarityType<SearobinRarity>();
			Item.useTurn = true;
            Item.maxStack = 1;
        }
    }
}