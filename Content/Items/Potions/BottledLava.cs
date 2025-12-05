using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Buffs;

namespace WaasephisFishingPlus.Content.Items.Potions
{
	// This item showcases some advanced capabilities of healing potions. It heals a dynamic amount, adjusts its tooltip accordingly, and has a reduced potion cooldown.
	// A typical healing potion can get rid of the ModifyTooltips, GetHealLife, and ModifyPotionDelay methods and just assign Item.healLife.
	// A mana potion is exactly the same, except Item.healMana is used instead. (Also GetHealMana would be used for dynamic mana recovery values)
	public class BottledLava : ModItem
	{
		public static LocalizedText RestoreLifeText { get; private set; }


		public override void SetStaticDefaults()
		{
			RestoreLifeText = this.GetLocalization(nameof(RestoreLifeText));

			Item.ResearchUnlockCount = 30;
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.buyPrice(silver: 20);
		}

		public override bool? UseItem(Player player)
		{
			CombatText.NewText(player.getRect(), Color.Red, "80", true, false);
			player.statLife -= 80;
			player.AddBuff(BuffID.OnFire, 150);

			return true;
		}


		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Bottle)
				.AddIngredient(ItemID.Obsidian)
				.AddCondition(Condition.NearLava)
				.Register();
		}
	}
}