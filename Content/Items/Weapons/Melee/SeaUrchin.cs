using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Projectiles.Weapons.Melee;

namespace WaasephisFishingPlus.Content.Items.Weapons.Melee
{
	public class SeaUrchin : ModItem
	{
		public override void SetStaticDefaults()
		{
			// These are all related to gamepad controls and don't seem to affect anything else
			ItemID.Sets.Yoyo[Item.type] = true;
			ItemID.Sets.GamepadExtraRange[Item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
			// DisplayName.SetDefault("Ice Ball");
			// Tooltip.SetDefault("Shoots a frost bolt at the cursor");
		}

		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.width = 26;
			Item.height = 28;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.shootSpeed = 7f;
			Item.knockBack = 2.5f;
			Item.damage = 15;
			Item.rare = ItemRarityID.Blue;

			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;

			Item.UseSound = SoundID.Item1;
			Item.value = Item.sellPrice(silver: 60);
			Item.shoot = ModContent.ProjectileType<SeaUrchinProjectile>();
		}
	}
}