using Terraria.ModLoader;
using Terraria.Achievements;
using WaasephisFishingPlus.Content.Items.Fish.LegendaryFish;
using WaasephisFishingPlus.Content.Items.Tools;

namespace WaasephisFishingPlus.Content.Achievements
{
	public class ChallengerAchievementOarfish : ModAchievement
	{
		public override void SetStaticDefaults()
		{
			Achievement.SetCategory(AchievementCategory.Challenger);
			AddItemPickupCondition(ModContent.ItemType<Oarfish>());
		}
	}
	public class ChallengerAchievementKingSalmon : ModAchievement
	{
		public override void SetStaticDefaults()
		{
			Achievement.SetCategory(AchievementCategory.Challenger);
			AddItemPickupCondition(ModContent.ItemType<KingSalmon>());
		}
	}
	public class ChallengerAchievementSearobin : ModAchievement
	{
		public override void SetStaticDefaults()
		{
			Achievement.SetCategory(AchievementCategory.Challenger);
			AddItemPickupCondition(ModContent.ItemType<Searobin>());
		}
	}
	public class ChallengerAchievementMoonsquid : ModAchievement
	{
		public override void SetStaticDefaults()
		{
			Achievement.SetCategory(AchievementCategory.Challenger);
			AddItemPickupCondition(ModContent.ItemType<RegalMoonsquid>());
		}
	}
	public class ChallengerAchievementEnderPearl : ModAchievement
	{
		public override void SetStaticDefaults()
		{
			Achievement.SetCategory(AchievementCategory.Challenger);
			AddItemPickupCondition(ModContent.ItemType<EnderPearl>());
		}
	}
}