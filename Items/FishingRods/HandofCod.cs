using WaasephisFishingPlus.Projectiles.Fishing;
using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.FishingRods
{
    public class HandofCod : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.CanFishInLava[Item.type] = false; // Allows the pole to fish in lava
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<Prismaline>();
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 34;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 8;
            Item.useTime = 8;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.Purple;
            Item.fishingPole = 10000; // Sets the poles fishing power
            Item.shootSpeed = 15f; // Sets the speed in which the bobbers are launched. Wooden Fishing Pole is 9f and Golden Fishing Rod is 17f.
            Item.shoot = ProjectileID.ConfettiGun; // The bobber projectile. Note that this will be overridden by Fishing Bobber accessories if present, so don't assume the bobber spawned is the specified projectile. https://terraria.wiki.gg/wiki/Fishing_Bobbers
        }

        // Grants the High Test Fishing Line bool if holding the item.
        // NOTE: Only triggers through the hotbar, not if you hold the item by hand outside of the inventory.

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WoodFishingPole);
            recipe.AddIngredient(ItemID.ReinforcedFishingPole);
            recipe.AddIngredient(ItemID.FisherofSouls);
            recipe.AddIngredient(ItemID.Fleshcatcher);
            recipe.AddIngredient(ItemID.ScarabFishingRod);
            recipe.AddIngredient(ItemID.BloodFishingRod);
            recipe.AddIngredient(ItemID.FiberglassFishingPole);
            recipe.AddIngredient(ItemID.MechanicsRod);
            recipe.AddIngredient(ItemID.SittingDucksFishingRod);
            recipe.AddIngredient(ItemID.HotlineFishingHook);
            recipe.AddIngredient(ItemID.GoldenFishingRod);
            recipe.AddIngredient(ModContent.ItemType<BonePole>());
            recipe.AddIngredient(ModContent.ItemType<CrystalCatcher>());
			recipe.AddIngredient(ModContent.ItemType<ChlorophyteFishingRod>());
			recipe.AddIngredient(ModContent.ItemType<RegalScepter>());			
			recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}