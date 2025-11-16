using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Items.Fish;
using WaasephisFishingPlus.Content.Buffs;

namespace WaasephisFishingPlus.Content.Items.Potions
{
	public class StablizingPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 20;

			// Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
			ItemID.Sets.DrinkParticleColors[Type] = [
				new Color(238, 220, 185),
				new Color(158, 116, 63),
				new Color(235, 186, 123)
			];
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 30;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.buyPrice(gold: 1);
			Item.buffType = ModContent.BuffType<StablizedBuff>(); // Specify an existing buff to be applied when used.
			Item.buffTime = 14400; // The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(ModContent.ItemType<AncientSquid>());
			recipe.AddIngredient(ItemID.Waterleaf);
			recipe.AddIngredient(ItemID.StoneBlock);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();

		}
	}
}