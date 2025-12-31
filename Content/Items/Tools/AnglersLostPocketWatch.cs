using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace WaasephisFishingPlus.Content.Items.Tools
{
	public class AnglersLostPocketWatch : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 26;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.value = Item.buyPrice(platinum: 1);
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.rare = ItemRarityID.Quest;
			Item.UseSound = SoundID.Item29;
		}

		// UseStyle is called each frame that the item is being actively used.
		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			// Each frame, make some dust
			if (Main.rand.NextBool())
			{
				Dust.NewDust(player.position, player.width, player.height, DustID.YellowStarDust, 0f, 0f, 150, Color.White, 1.1f); // Makes dust from the player's position and copies the hitbox of which the dust may spawn. Change these arguments if needed.
				Dust.NewDust(player.position, player.width, player.height, DustID.ManaRegeneration, 0f, 0f, 150, Color.White, 1.1f);
			}

		}
		public override bool? UseItem(Player player)
		{
			Main.AnglerQuestSwap();
			return true;
		}
	}
}