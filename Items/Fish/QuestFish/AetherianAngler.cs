using Terraria;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Fish.QuestFish
{
    public class AetherianAngler : ModItem
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
			Item.width = 40;
			Item.height = 50;
		}

        public override bool IsQuestFish() => true; // Makes the item a quest fish


        public override void AnglerQuestChat(ref string description, ref string catchLocation)
        {
            description = "Have you seen the shimmer? I tried fishing in it once to see what lived in there, and thats an experience I'd never like to have ever again... There has to be some weird creatures nearby though, try fishing nearby!";
            catchLocation = "Caught in the Aether.";
        }
    }
}