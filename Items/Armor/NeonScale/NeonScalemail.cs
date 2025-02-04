using WaasephisFishingPlus.Items.Filleting;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Armor.NeonScale
{
	[AutoloadEquip(EquipType.Body)]
	public class NeonScalemail : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 20;
			Item.value = 1500;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			player.fishingSkill += 4;
			player.accFlipper = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<NeonScales>(), 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}