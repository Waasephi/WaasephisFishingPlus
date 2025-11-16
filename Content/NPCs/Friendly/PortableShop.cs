using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Items.Bait;
using WaasephisFishingPlus.Content.Items.FishingRods;
using WaasephisFishingPlus.Content.Items.Potions;
using WaasephisFishingPlus.Content.Items.Tools;

namespace WaasephisFishingPlus.Content.NPCs.Friendly
{
	public class PortableShop : ModNPC
	{
		public const string ShopName = "Shop";

        private static Profiles.StackedNPCProfile NPCProfile;

        public override void SetStaticDefaults()
		{
            NPCID.Sets.ActsLikeTownNPC[Type] = true;
            NPCID.Sets.ShimmerTownTransform[Type] = true;
			NPCID.Sets.NoTownNPCHappiness[Type] = true;

            NPCProfile = new Profiles.StackedNPCProfile(new Profiles.DefaultNPCProfile(Texture, -1), new Profiles.DefaultNPCProfile(Texture + "_Shimmer", -1));
        }

        public override ITownNPCProfile TownNPCProfile()
        {
            return NPCProfile;
        }

		public override void SetDefaults()
		{
			NPC.townNPC = true; // Sets NPC to be a Town NPC
			NPC.friendly = true; // NPC Will not attack player
			NPC.width = 42;
			NPC.height = 40;
			NPC.damage = 0;
			NPC.defense = 0;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath14;
			NPC.knockBackResist = 0f;
			NPC.aiStyle = 7;
			TownNPCStayingHomeless = true;
		}

		public override bool CanChat()
		{
			return true;
		}

		public override void SetChatButtons(ref string button, ref string button2)  //Allows you to set the text for the buttons that appear on this town NPC's chat window.
		{
			button = "Shop";   //this defines the buy button name
		}

		public override void OnChatButtonClicked(bool firstButton, ref string shop) //Allows you to make something happen whenever a button is clicked on this town NPC's chat window. The firstButton parameter tells whether the first button or second button (button and button2 from SetChatButtons) was clicked. Set the shop parameter to true to open this NPC's shop.
		{
			if (firstButton)
			{
				shop = ShopName;   //so when you click on buy button opens the shop
			}
		}

		public override void AddShops()
		{
			var npcShop = new NPCShop(Type, ShopName)
			.Add<GoldfishMirror>()
			.Add(ItemID.WoodFishingPole)
			.Add(ItemID.ReinforcedFishingPole, Condition.DownedSkeletron)
			.Add<GoldfishingRod>(Condition.Hardmode)
			.Add<BudGold>(Condition.DownedEowOrBoc)
			.Add<FishFlakes>()
			.Add(ItemID.ApprenticeBait, Condition.DownedEyeOfCthulhu)
			.Add(ItemID.JourneymanBait, Condition.Hardmode)
			.Add(ItemID.MasterBait, Condition.DownedGolem)
			.Add(ItemID.ChumBucket, Condition.BloodMoon)
			.Add(ItemID.BottomlessBucket, Condition.Hardmode, Condition.InRain)
			.Add(ItemID.SuperAbsorbantSponge, Condition.Hardmode, Condition.InRain)
			.Add(ItemID.BottomlessLavaBucket, Condition.Hardmode, Condition.InUnderworldHeight)
			.Add(ItemID.LavaAbsorbantSponge, Condition.Hardmode, Condition.InUnderworldHeight)
			.Add(ItemID.BottomlessHoneyBucket, Condition.Hardmode, Condition.DownedQueenBee, Condition.InJungle)
			.Add(ItemID.HoneyAbsorbantSponge, Condition.Hardmode, Condition.DownedQueenBee, Condition.InJungle)
			.Add<BottomlessChumBucket>(Condition.BloodMoon, Condition.Hardmode)
			.Add(ItemID.FishingBobber, Condition.Hardmode);

			npcShop.Register();
		}

		public override string GetChat()       //Allows you to give this town NPC a chat message when a player talks to it.
		{
			return Language.GetTextValue("Mods.WaasephisFishingPlus.Dialogue.PortableShop.Default" + Main.rand.Next(1, 5));
		}

		public override void AI()
		{
			NPC.TargetClosest(true);
            Player player = Main.player[NPC.target];
			
			NPC.spriteDirection = NPC.direction;

			NPC.velocity.X = 0;

			if (Main.rand.NextBool(1500))
			{
				EmoteBubble.NewBubble(EmoteID.ItemFishingRod, new WorldUIAnchor(NPC), 200);
			}
		}

		public override void OnKill()
		{
			EmoteBubble.NewBubble(EmoteID.EmoteSadness, new WorldUIAnchor(NPC), 100);
			NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, (int)NPC.Center.Y, NPCID.GoldfishWalker, ai3: NPC.whoAmI);
			NPC.SpawnedFromStatue = true;
			NPC.netUpdate = true;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
			   BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
				new FlavorTextBestiaryInfoElement("Mods.WaasephisFishingPlus.Bestiary.PortableShop"),
			});
		}
	}
}