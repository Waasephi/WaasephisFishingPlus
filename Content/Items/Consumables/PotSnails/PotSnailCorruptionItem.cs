using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.NPCs.Passive.PotSnails;
using static Terraria.ModLoader.ModContent;

namespace WaasephisFishingPlus.Content.Items.Consumables.PotSnails
{
	public class PotSnailCorruptionItem : ModItem
	{
		public override void SetStaticDefaults() 
		{

		}

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 28;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = true;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Green;
            Item.shootSpeed = 10;
            Item.shoot = ProjectileType<PotSnailCorruptionPot>();
        }

    }
}