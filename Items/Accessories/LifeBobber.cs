﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using WaasephisFishingPlus.Projectiles.Fishing;

namespace WaasephisFishingPlus.Items.Accessories
{
	public class LifeBobber : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.fishingSkill += 10;
			player.overrideFishingBobber = ModContent.ProjectileType<LifeBobberProjectile>();
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 30;
			Item.value = Item.buyPrice(gold: 1);
			Item.rare = ItemRarityID.Lime;
			Item.accessory = true;
			Item.expert = false;
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FishingBobberGlowingStar);
            recipe.AddIngredient(ItemID.LifeFruit, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
