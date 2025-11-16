using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Core;

namespace WaasephisFishingPlus.Content.Items.Fish
{
    public class Oarfish : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 216;
            Item.height = 62;
            Item.value = Item.sellPrice(platinum: 1);
			Item.rare = ModContent.RarityType<OarfishRarity>();
			Item.useTurn = true;
            Item.maxStack = 1;
        }
    }
}