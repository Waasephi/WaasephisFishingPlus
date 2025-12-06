using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Items.Materials;
using WaasephisFishingPlus.Content.Tiles.Decor;

namespace WaasephisFishingPlus.Content.Items.Armor.Clam;

[AutoloadEquip(EquipType.Body)]
public class ClamChestplate : ModItem
{
	public override void SetStaticDefaults()
	{
		base.SetStaticDefaults();
	}

	public override void SetDefaults()
	{
		Item.width = 30;
		Item.height = 20;
		Item.value = Item.sellPrice(silver: 75);
        Item.rare = ItemRarityID.Blue;
		Item.defense = 8;
	}

	public override void UpdateEquip(Player player)
	{
		player.fishingSkill += 4;
		player.aggro += 10;
		player.GetDamage(DamageClass.Generic) *= 1.1f;
		player.GetCritChance(DamageClass.Generic) += 5;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<ClamShell>(), 20);
		recipe.AddTile(ModContent.TileType<Shellforge>());
		recipe.Register();
	}
}