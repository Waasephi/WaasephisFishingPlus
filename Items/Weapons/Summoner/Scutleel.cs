using WaasephisFishingPlus.Projectiles.Weapons.Summoner;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Weapons.Summoner
{
	public class Scutleel : ModItem
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ebondune Chain");
			// Tooltip.SetDefault("Has little to no damage fall off between hitting multiple enemies");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			// Call this method to quickly set some of the properties below.
			//Item.DefaultToWhip(ModContent.ProjectileType<ExampleWhipProjectileAdvanced>(), 20, 2, 4);

			Item.DamageType = DamageClass.SummonMeleeSpeed;
			Item.damage = 170;
			Item.knockBack = 8;
			Item.rare = ItemRarityID.Yellow;

			Item.shoot = ModContent.ProjectileType<ScutleelProjectile>();
			Item.shootSpeed = 4;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.UseSound = SoundID.Item152;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;
		}
		public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
    }
}