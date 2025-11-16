using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using WaasephisFishingPlus.Content.Buffs.Pets.LightPets;
using WaasephisFishingPlus.Content.Projectiles.Pets.LightPets;

namespace WaasephisFishingPlus.Content.Items.Pets.LightPets
{
	public class AnglerLantern : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Fish);
			Item.width = 20;
			Item.height = 20;
			Item.shoot = ModContent.ProjectileType<AnglerFishPet>();
			Item.buffType = ModContent.BuffType<AnglerFishBuff>();
			Item.rare = ItemRarityID.LightRed;
		}

		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 2, true);
			}
		}
	}
}