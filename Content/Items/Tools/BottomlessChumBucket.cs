using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace WaasephisFishingPlus.Content.Items.Tools
{
	public class BottomlessChumBucket : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.buyPrice(gold: 25);
            Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shootSpeed = 7f;
			Item.shoot = ProjectileID.ChumBucket;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int chumAmount = 3;
			float spreadAmount = 25f; // how much the different bobbers are spread out.

			for (int index = 0; index < chumAmount; ++index)
			{
				Vector2 chumSpeed = velocity + new Vector2(Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f, Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f);

				Projectile.NewProjectile(source, position, chumSpeed, type, 0, 0f, player.whoAmI);
			}
			return false;
		}
	}
}