using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Core;

namespace WaasephisFishingPlus.Content.Items.Fish
{
    public class RegalMoonsquid : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 50;
            Item.value = Item.sellPrice(platinum: 1);
			Item.rare = ModContent.RarityType<MoonsquidRarity>();
			Item.useTurn = true;
            Item.maxStack = 1;
        }
    }
}