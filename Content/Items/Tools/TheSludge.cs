using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Content.Items.Tools
{
    public class TheSludge : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 57;
            Item.height = 65;
			Item.value = Item.sellPrice(platinum: 9999);
            Item.rare = ItemRarityID.Master;
            Item.maxStack = 9999;
		}
    }
}