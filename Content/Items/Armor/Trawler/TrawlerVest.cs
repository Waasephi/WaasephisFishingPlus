using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Content.Items.Armor.Trawler
{
	[AutoloadEquip(EquipType.Body)]
	public class TrawlerVest : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 20;
			Item.value = Item.sellPrice(gold: 2, silver: 50);
            Item.rare = ItemRarityID.LightRed;
			Item.defense = 12;
		}

		public override void UpdateEquip(Player player)
		{
			player.fishingSkill += 10;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AncientCloth, 5);
            recipe.AddIngredient(ItemID.AnglerVest);
            recipe.AddTile(TileID.Loom);
            recipe.Register();
		}
	}
}