using WaasephisFishingPlus.Items.Filleting;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Armor.Trawler
{

	[AutoloadEquip(EquipType.Head)]
	public class TrawlerHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
            ArmorIDs.Head.Sets.DrawHatHair[EquipLoader.GetEquipSlot(Mod, Name, EquipType.Head)] = true;
        }

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 14;
			Item.value = Item.sellPrice(gold: 2, silver: 50);
            Item.rare = ItemRarityID.LightRed;
			Item.defense = 11;
		}

		public override void UpdateEquip(Player player)
		{
			player.fishingSkill += 10;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<TrawlerVest>() && legs.type == ModContent.ItemType<TrawlerPants>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Greatly reduced enemy spawn rate";
			player.anglerSetSpawnReduction = true;
			player.calmed = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AncientCloth, 5);
            recipe.AddIngredient(ItemID.AnglerHat);
            recipe.AddTile(TileID.Loom);
            recipe.Register();
		}
	}
}