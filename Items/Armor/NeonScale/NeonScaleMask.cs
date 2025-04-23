using WaasephisFishingPlus.Items.Filleting;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace WaasephisFishingPlus.Items.Armor.NeonScale
{

	[AutoloadEquip(EquipType.Head)]
	public class NeonScaleMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			ArmorIDs.Head.Sets.DrawHead[EquipLoader.GetEquipSlot(Mod, Name, EquipType.Head)] = false;
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = 750;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			player.fishingSkill += 2;
			player.gills = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<NeonScalemail>() && legs.type == ModContent.ItemType<NeonScaleGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = Language.GetTextValue("Mods.WaasephisFishingPlus.ArmorSetBonus.NeonScaleArmor");
			player.discountAvailable = true;
			player.discountEquipped = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<NeonScales>(), 7);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}