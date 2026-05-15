using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using WaasephisFishingPlus.Content.Items.Materials;

namespace WaasephisFishingPlus.Content.Items.Armor.SandShark
{

	[AutoloadEquip(EquipType.Head)]
	public class SandSharkMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			ArmorIDs.Head.Sets.DrawHead[EquipLoader.GetEquipSlot(Mod, Name, EquipType.Head)] = false;
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 18;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Pink;
			Item.defense = 10;
		}

		public override void UpdateEquip(Player player)
		{
			player.fishingSkill += 8;
			player.GetCritChance(DamageClass.Generic) += 5;
			player.accDivingHelm = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<SandSharkShirt>() && legs.type == ModContent.ItemType<SandSharkFins>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = Language.GetTextValue("Mods.WaasephisFishingPlus.ArmorSetBonus.SandSharkArmor");
			player.GetAttackSpeed(DamageClass.Generic) *= 1.15f;
			player.desertBoots = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SharkFin, 5);
			recipe.AddIngredient(ItemID.AncientBattleArmorMaterial);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}