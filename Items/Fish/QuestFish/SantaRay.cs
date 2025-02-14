using Terraria;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Fish.QuestFish
{
    public class SantaRay : ModItem
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
			Item.height = 40;
		}

        public override bool IsQuestFish() => true; // Makes the item a quest fish


        public override void AnglerQuestChat(ref string description, ref string catchLocation)
        {
            description = "Every winter, Santa Claus comes around and gives us presents. I've heard he has a collection of pet fish, Get me one so I can blackmail Santa to get me good presents!";
            catchLocation = "Caught in the Tundra.";
        }
    }
}