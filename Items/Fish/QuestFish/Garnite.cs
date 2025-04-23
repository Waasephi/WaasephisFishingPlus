using Terraria;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Fish.QuestFish
{
    public class Garnite : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            // DefaultToQuestFish sets quest fish properties.
            // Of note, it sets rare to ItemRarityID.Quest, which is the special rarity for quest items.
            // It also sets uniqueStack to true, which prevents players from picking up a 2nd copy of the item into their inventory.
            Item.DefaultToQuestFish();
			Item.width = 38;
			Item.height = 38;
        }

        public override bool IsQuestFish() => true; // Makes the item a quest fish
    }
}