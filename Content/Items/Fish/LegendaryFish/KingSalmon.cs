using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Achievements;
using WaasephisFishingPlus.Core;

namespace WaasephisFishingPlus.Content.Items.Fish.LegendaryFish
{
    public class KingSalmon : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 58;
            Item.height = 54;
            Item.value = Item.sellPrice(gold: 75);
			Item.rare = ModContent.RarityType<SalmonRarity>();
			Item.useTurn = true;
            Item.maxStack = 1;
        }
	}
}