using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using WaasephisFishingPlus.Items.Tools;

namespace WaasephisFishingPlus.NPCs.Friendly
{
	public class PortableShop : ModNPC
	{
		public const string ShopName = "Shop";
		public override void SetStaticDefaults()
		{
			NPCID.Sets.ActsLikeTownNPC[Type] = true;
			NPCID.Sets.ShimmerTownTransform[Type] = false;
			NPCID.Sets.NoTownNPCHappiness[Type] = true;
		}

		public override void SetDefaults()
		{
			NPC.townNPC = false; // Sets NPC to be a Town NPC
			NPC.friendly = true; // NPC Will not attack player
			NPC.width = 42;
			NPC.height = 40;
			NPC.damage = 0;
			NPC.defense = 0;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;
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
				.Add(ItemID.WoodFishingPole)
				.Add(ItemID.ReinforcedFishingPole, Condition.DownedSkeletron)
				.Add(ItemID.ApprenticeBait, Condition.DownedEyeOfCthulhu)
				.Add(ItemID.JourneymanBait, Condition.Hardmode)
				.Add(ItemID.MasterBait, Condition.DownedGolem)
				.Add(ItemID.ChumBucket, Condition.BloodMoon)
				.Add<BottomlessChumBucket>(Condition.BloodMoon, Condition.Hardmode)
				;

			npcShop.Register();
		}

		public override string GetChat()       //Allows you to give this town NPC a chat message when a player talks to it.
		{
			switch (Main.rand.Next(4))    //this are the messages when you talk to the npc
			{
			case 0:
				return "*Blub*";

			case 1:
				return "*Glub*";

			case 2:
				return "...";

			default:
				return "*Fish Noise*";
			}
		}
		public override void AI()
		{
			NPC.spriteDirection = NPC.direction;

			NPC.velocity.X *= 0;

			if (Main.rand.NextBool(1500))
			{
				EmoteBubble.NewBubble(EmoteID.ItemFishingRod, new WorldUIAnchor(NPC), 200);
			}
		}
	}
}