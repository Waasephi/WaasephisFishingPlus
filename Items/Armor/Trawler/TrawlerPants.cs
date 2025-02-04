using WaasephisFishingPlus.Items.Filleting;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Armor.Trawler
{
	[AutoloadEquip(EquipType.Legs)]
	public class TrawlerPants : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = Item.sellPrice(gold: 2, silver: 50);
            Item.rare = ItemRarityID.LightRed;
			Item.defense = 11;
		}

		public override void UpdateEquip(Player player)
		{
			player.fishingSkill += 10;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AncientCloth, 5);
			recipe.AddIngredient(ItemID.AnglerPants);
            recipe.AddTile(TileID.Loom);
            recipe.Register();
        }
    }
}