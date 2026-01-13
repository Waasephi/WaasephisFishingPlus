using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using WaasephisFishingPlus.Content.NPCs.Passive.PotSnails;

namespace WaasephisFishingPlus.Content.Items.Consumables.PotSnails
{
	public class PotSnailJungleItem : ModItem
	{
		public override void SetStaticDefaults() 
		{
		}

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 30;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = true;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Blue;
            Item.shootSpeed = 10;
            Item.shoot = ProjectileType<PotSnailJunglePot>();
        }

    }
}