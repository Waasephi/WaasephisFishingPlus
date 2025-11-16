using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Buffs;
using WaasephisFishingPlus.Content.Items.Fish;

namespace WaasephisFishingPlus.Content.Items.Potions
{
	/// <summary>
	/// A potion that applies the ExampleWeaponImbue buff to the player.
	/// See also ExampleWeaponImbue and ExampleWeaponEnchantmentPlayer.
	/// </summary>
	public class FlaskofBetsy : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 20;

			ItemID.Sets.DrinkParticleColors[Type] = [
				new Color(255, 203, 103),
				new Color(255, 145, 56),
				new Color(231, 92, 24)
			];
		}

		public override void SetDefaults()
		{
			Item.UseSound = SoundID.Item3;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useTurn = true;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
			Item.width = 22;
			Item.height = 30;
			Item.buffType = ModContent.BuffType<BetsyCurseImbue>();
			Item.buffTime = Item.flaskTime;
			Item.value = Item.sellPrice(silver:50);
			Item.rare = ItemRarityID.Yellow;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient<EtherianSeadragon>()
				.AddTile(TileID.ImbuingStation)
				.Register();
		}
	}
}