using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Content.Items.Bait
{
    public class FishFlakes : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 20;
            Item.value = Item.buyPrice(silver: 10);
            Item.rare = ItemRarityID.Blue;
			Item.bait = 5;
            Item.maxStack = 9999;
			Item.consumable = true;
        }
    }
}