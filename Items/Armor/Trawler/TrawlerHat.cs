using WaasephisFishingPlus.Items.Filleting;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

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
			player.setBonus = "Greatly reduced enemy spawn rate"; //this should probably be localized
			player.GetModPlayer<TrawlerSetbonusPlayer>().SetBonus = true;
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

	public class TrawlerSetbonusPlayer : ModPlayer
	{
		public bool SetBonus = false;

		public override void ResetEffects()
		{
			SetBonus = false;
		}
	}

	public class TrawlerItemGlobal : GlobalItem
	{
		public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (item.fishingPole > 0 && player.GetModPlayer<TrawlerSetbonusPlayer>().SetBonus)
			{
				Projectile.NewProjectile(source, position, velocity + new Vector2(2 * player.direction, 0), type, damage, knockback, player.whoAmI);
			}

			return base.Shoot(item, player, source, position, velocity, type, damage, knockback);
		}
	}
}