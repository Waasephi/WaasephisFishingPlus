using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Potions
{
	public class BudGold : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 20;

			// Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
			ItemID.Sets.DrinkParticleColors[Type] = [
				new (25, 97, 26),
				new (203, 179, 73),
				new (186, 186, 186)
			];
		}

		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 22;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.buyPrice(silver: 30);
			Item.value = Item.sellPrice(silver: 10);
			Item.buffType = BuffID.Tipsy; // Specify an existing buff to be applied when used.
			Item.buffTime = 28800; // The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
		}
	}
}