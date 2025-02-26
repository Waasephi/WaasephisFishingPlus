using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using WaasephisFishingPlus.NPCs.Friendly;

namespace WaasephisFishingPlus.Items.Tools
{
	public class PortableShopBox : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 46;
			Item.useTime = 30;
			Item.useAnimation = 22;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.noUseGraphic = true;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.rare = ItemRarityID.Quest;
			Item.UseSound = SoundID.Item14;
		}

		public override bool? UseItem(Player player)
		{
			for (int k = 0; k < Main.maxNPCs; k++)
			{
				if (Main.npc[k].active && (Main.npc[k].type == ModContent.NPCType<PortableShop>() ||
				Main.npc[k].active && Main.npc[k].type == ModContent.NPCType<PortableShop>() ||
				Main.npc[k].type == ModContent.NPCType<PortableShop>()))
				{
					Main.npc[k].active = false;
				}
			}

			NPC.NewNPC(player.GetSource_ItemUse(player.HeldItem), (int)player.Center.X, (int)player.Center.Y - 25, ModContent.NPCType<PortableShop>());
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GoldCoin, 20);
            recipe.AddIngredient(ItemID.WoodenCrate, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}