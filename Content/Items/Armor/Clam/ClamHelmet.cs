using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.Enums;
using WaasephisFishingPlus.Content.Items.Materials;
using WaasephisFishingPlus.Content.Tiles.Decor;

namespace WaasephisFishingPlus.Content.Items.Armor.Clam
{

	[AutoloadEquip(EquipType.Head)]
	public class ClamHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			ArmorIDs.Head.Sets.DrawHead[EquipLoader.GetEquipSlot(Mod, Name, EquipType.Head)] = false;
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(silver: 50);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 7;
		}

		public override void UpdateEquip(Player player)
		{
			player.fishingSkill += 4;
			player.aggro += 5;
			player.statManaMax2 += 20;
			Lighting.AddLight(player.position, Color.White.ToVector3() * 0.5f);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<ClamChestplate>() && legs.type == ModContent.ItemType<ClamGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{	
			player.setBonus = Language.GetTextValue("Mods.WaasephisFishingPlus.ArmorSetBonus.ClamArmor");
			player.endurance *= 1.1f;
			player.GetJumpState<ClamJump>().Enable();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ClamShell>(), 10);
			recipe.AddIngredient(ItemID.WhitePearl, 5);
			recipe.AddTile(ModContent.TileType<Shellforge>());
			recipe.Register();
		}
		public class ClamJump : ExtraJump
		{
			public override Position GetDefaultPosition() => new After(BlizzardInABottle);

			/*public override IEnumerable<Position> GetModdedConstraints()
			{
				// By default, modded extra jumps set to be between two vanilla extra jumps (via After and Before) are ordered in load order.
				// This hook allows you to organize where this extra jump is located relative to other modded extra jumps that are also
				// placed between the same two vanilla extra jumps.
				yield return new Before(ModContent.GetInstance<MultipleUseExtraJump>());
			}*/

			public override float GetDurationMultiplier(Player player)
			{
				// Use this hook to set the duration of the extra jump
				// The XML summary for this hook mentions the values used by the vanilla extra jumps
				return 1f;
			}

			public override void UpdateHorizontalSpeeds(Player player)
			{
				// Use this hook to modify "player.runAcceleration" and "player.maxRunSpeed"
				// The XML summary for this hook mentions the values used by the vanilla extra jumps
				player.runAcceleration *= 1.3f;
				player.maxRunSpeed *= 1.3f;
			}

			public override void OnStarted(Player player, ref bool playSound)
			{
				// Use this hook to trigger effects that should appear at the start of the extra jump
				// This example mimics the logic for spawning the puff of smoke from the Cloud in a Bottle
				int offsetY = player.height;
				if (player.gravDir == -1f)
					offsetY = 0;

				offsetY -= 16;

				for (int i = 0; i < 10; i++)
				{
					Dust dust = Dust.NewDustDirect(player.position + new Vector2(-34f, offsetY), 102, 32, DustID.TreasureSparkle, -player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 100, Color.Gray, 1.5f);
					dust.velocity = dust.velocity * 0.5f - player.velocity * new Vector2(0.1f, 0.3f);
				}
			}

			public override void ShowVisuals(Player player)
			{
				// Use this hook to trigger effects that should appear throughout the duration of the extra jump
				// This example mimics the logic for spawning the dust from the Blizzard in a Bottle
				int offsetY = player.height - 6;
				if (player.gravDir == -1f)
					offsetY = 6;

				Vector2 spawnPos = new Vector2(player.position.X, player.position.Y + offsetY);

				for (int i = 0; i < 2; i++)
				{
					SpawnClamDust(player, spawnPos, 0.1f, i == 0 ? -0.07f : -0.13f);
				}

				for (int i = 0; i < 3; i++)
				{
					SpawnClamDust(player, spawnPos, 0.6f, 0.8f);
				}

				for (int i = 0; i < 3; i++)
				{
					SpawnClamDust(player, spawnPos, 0.6f, -0.8f);
				}
			}

			private static void SpawnClamDust(Player player, Vector2 spawnPos, float dustVelocityMultiplier, float playerVelocityMultiplier)
			{
				Dust dust = Dust.NewDustDirect(spawnPos, player.width, 12, DustID.Water, player.velocity.X * 0.3f, player.velocity.Y * 0.3f, newColor: Color.Gray);
				dust.fadeIn = 1.5f;
				dust.velocity *= dustVelocityMultiplier;
				dust.velocity += player.velocity * playerVelocityMultiplier;
				dust.noGravity = true;
				dust.noLight = true;
			}
		}
	}
}