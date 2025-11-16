using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Content.Items.Materials
{
	public class NeonScales : ModItem
	{
		public override void SetStaticDefaults() 
		{
		}

		public override void SetDefaults() 
		{
			Item.width = 16;
			Item.height = 18;
			Item.value = Item.sellPrice(silver: 8);
			Item.rare = ItemRarityID.Blue;
			Item.useTurn = true;
			Item.maxStack = 9999;
		}
	}
}