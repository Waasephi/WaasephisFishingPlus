using Terraria;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Items.Fish.QuestFish
{
    public class Mecherel : ModItem
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

        public override bool IsAnglerQuestAvailable() => NPC.downedMechBossAny && Main.hardMode; // Makes the quest only appear in hard mode. Adding a '!' before Main.hardMode makes it ONLY available in pre-hardmode.

        public override void AnglerQuestChat(ref string description, ref string catchLocation)
        {
            description = "You know those huge robots? I heard a rumor that there are more of them! I heard that one of them is even a fish! Go find it!";
            catchLocation = "Caught Anywhere.";
        }
    }
}