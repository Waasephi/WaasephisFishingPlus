using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace WaasephisFishingPlus.Content.Items.Accessories
{
	public class CoralHeart : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
            player.AddBuff(BuffID.Fishing, 2);
            player.AddBuff(BuffID.Sonar, 2);
			player.AddBuff(BuffID.Crate, 2);
			player.fishingSkill += 5;
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 30;
			Item.value = Item.buyPrice(gold: 1, silver: 50);
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
			Item.expert = false;
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Coral, 25);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
