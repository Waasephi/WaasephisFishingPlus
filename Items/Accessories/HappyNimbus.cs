using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace WaasephisFishingPlus.Items.Accessories
{
	[AutoloadEquip(EquipType.Balloon)]
	public class HappyNimbus : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			if (Main.raining)
			{
				player.fishingSkill += 20;
			}
			
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 26;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.LightRed;
			Item.accessory = true;
			Item.expert = false;
		}
    }
}
