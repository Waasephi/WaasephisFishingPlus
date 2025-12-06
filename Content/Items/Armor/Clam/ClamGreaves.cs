using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Items.Materials;
using WaasephisFishingPlus.Content.Tiles.Decor;

namespace WaasephisFishingPlus.Content.Items.Armor.Clam
{
	[AutoloadEquip(EquipType.Legs)]
	public class ClamGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 16;
			Item.value = Item.sellPrice(silver: 50);
            Item.rare = ItemRarityID.Blue;
			Item.defense = 7;
		}

		public override void UpdateEquip(Player player)
		{
			player.fishingSkill += 4;
			player.aggro += 5;
			player.moveSpeed *= 0.95f;
			player.accFlipper = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ClamShell>(), 15);
			recipe.AddTile(ModContent.TileType<Shellforge>());
			recipe.Register();
		}
	}
}