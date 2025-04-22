using WaasephisFishingPlus.Items.Filleting;
using WaasephisFishingPlus.Items.FishingRods;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using WaasephisFishingPlus.Items.Fish;

namespace WaasephisFishingPlus.Items.Tools
{
	public class GoldfishMirror : ModItem
	{

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.IceMirror);
			Item.width = 30;
			Item.height = 26;
			Item.value = Item.buyPrice(gold: 5);
		}

		// UseStyle is called each frame that the item is being actively used.
		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			// Each frame, make some dust
			if (Main.rand.NextBool())
			{
				Dust.NewDust(player.position, player.width, player.height, DustID.Water, 0f, 0f, 150, Color.White, 1.1f); // Makes dust from the player's position and copies the hitbox of which the dust may spawn. Change these arguments if needed.
				Dust.NewDust(player.position, player.width, player.height, DustID.FishronWings, 0f, 0f, 150, Color.White, 1.1f);
			}

			// This sets up the itemTime correctly.
			if (player.itemTime == 0)
			{
				player.ApplyItemTime(Item);
			}
			else if (player.itemTime == player.itemTimeMax / 2)
			{
				// This code runs once halfway through the useTime of the Item. You'll notice with magic mirrors you are still holding the item for a little bit after you've teleported.

				// Make dust 70 times for a cool effect.
				for (int d = 0; d < 70; d++)
				{
					Dust.NewDust(player.position, player.width, player.height, DustID.FishronWings, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 150, default, 1.5f);
				}

				// This code releases all grappling hooks and kills/despawns them.
				player.RemoveAllGrapplingHooks();

				player.Spawn(PlayerSpawnContext.RecallFromItem);

				// Make dust 70 times for a cool effect. This dust is the dust at the destination.
				for (int d = 0; d < 70; d++)
				{
					Dust.NewDust(player.position, player.width, player.height, DustID.FishronWings, 0f, 0f, 150, default, 1.5f);
				}
			}
		}
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ItemID.CellPhone);
			recipe.AddIngredient(ItemID.PDA);
			recipe.AddIngredient(ModContent.ItemType<GoldfishMirror>());
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}