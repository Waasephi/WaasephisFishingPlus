using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.NPCs.Passive.PotSnails;
using static Terraria.ModLoader.ModContent;

namespace WaasephisFishingPlus.Content.Items.Consumables.PotSnails
{
	public class PotSnailDungeonItem : ModItem
	{
		public override void SetStaticDefaults() 
		{
		}

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = true;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Orange;
            Item.shootSpeed = 10;
            Item.shoot = ProjectileType<PotSnailDungeonPot>();
        }

    }
}