using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace WaasephisFishingPlus.Content.Items.Accessories
{
	public class TrashHook : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{

			player.fishingSkill += 10;
			player.AddBuff(BuffID.Stinky, 2);

		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 34;
			Item.value = Item.sellPrice(silver: 50);
			Item.rare = ItemRarityID.Gray;
			Item.accessory = true;
			Item.expert = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TinCan, 5);
			recipe.AddIngredient(ItemID.FishingSeaweed, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
