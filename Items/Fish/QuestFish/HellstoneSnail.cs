using Terraria;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Fish.QuestFish
{
    public class HellstoneSnail : ModItem
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
			Item.height = 34;
        }

        public override bool IsQuestFish() => true; // Makes the item a quest fish


        public override void AnglerQuestChat(ref string description, ref string catchLocation)
        {
            description = "Have you been to the Underworld yet? There are unique fish that live in lava down there! I've GOT to see some! I'm not going myself, that place isn't very kid friendly, you do it! You can fish in lava with the critters found down there, just need a fireproof net to get them.";
            catchLocation = "Caught in the Underworld.";
        }
    }
}