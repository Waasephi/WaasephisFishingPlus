using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Items.Fish;

namespace WaasephisFishingPlus.Content
{
	// This class contains thoughtful examples of item recipe creation.
	// Recipes are explained in detail on the https://github.com/tModLoader/tModLoader/wiki/Basic-Recipes and https://github.com/tModLoader/tModLoader/wiki/Intermediate-Recipes wiki pages. Please visit the wiki to learn more about recipes if anything is unclear.
	public class RecipeGroups : ModSystem
	{
		public override void AddRecipeGroups()
		{
			// While an "IronBar" group exists, "SilverBar" does not. tModLoader will merge recipe groups registered with the same name, so if you are registering a recipe group with a vanilla item as the 1st item, you can register it using just the internal item name if you anticipate other mods wanting to use this recipe group for the same concept. By doing this, multiple mods can add to the same group without extra effort. In this case we are adding a SilverBar group. Don't store the RecipeGroup instance, it might not be used, use the same nameof(ItemID.ItemName) or RecipeGroupID returned from RegisterGroup when using Recipe.AddRecipeGroup instead.
			RecipeGroup SilverBarRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.SilverBar)}",
			ItemID.SilverBar, ItemID.TungstenBar);
			RecipeGroup.RegisterGroup(nameof(ItemID.SilverBar), SilverBarRecipeGroup);

			RecipeGroup MythrilBarRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.MythrilBar)}",
			ItemID.MythrilBar, ItemID.OrichalcumBar);
			RecipeGroup.RegisterGroup(nameof(ItemID.MythrilBar), MythrilBarRecipeGroup);

			RecipeGroup SquidRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ModContent.ItemType<Squid>())}",
			ModContent.ItemType<Squid>(), ModContent.ItemType<AncientSquid>());
			RecipeGroup.RegisterGroup(nameof(Squid), SquidRecipeGroup);
		}
	}
}