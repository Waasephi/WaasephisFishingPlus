using Terraria.Achievements;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Items.Blocks;
using WaasephisFishingPlus.Content.Items.Filleting;
using WaasephisFishingPlus.Content.Items.Fish.LegendaryFish;
using WaasephisFishingPlus.Content.Items.FishingRods;
using WaasephisFishingPlus.Content.Items.Tools;

namespace WaasephisFishingPlus.Content.Achievements
{
	public class CollectorAchievementFilletingTable : ModAchievement
	{
		public override void SetStaticDefaults()
		{
			Achievement.SetCategory(AchievementCategory.Collector);
			AddItemPickupCondition(ModContent.ItemType<FilletingTableItem>());
		}
	}
	public class CollectorAchievementPortableShop : ModAchievement
	{
		public override void SetStaticDefaults()
		{
			Achievement.SetCategory(AchievementCategory.Collector);
			AddItemPickupCondition(ModContent.ItemType<PortableShopBox>());
		}
	}
	public class CollectorAchievementHandofCod : ModAchievement
	{
		public override void SetStaticDefaults()
		{
			Achievement.SetCategory(AchievementCategory.Collector);
			AddItemPickupCondition(ModContent.ItemType<HandofCod>());
		}
	}
	public class CollectorAchievementGalacticKnife : ModAchievement
	{
		public override void SetStaticDefaults()
		{
			Achievement.SetCategory(AchievementCategory.Collector);
			AddItemPickupCondition(ModContent.ItemType<GalacticFilletKnife>());
		}
	}

	public class CollectorAchievementPrismaline : ModAchievement
	{
		public override void SetStaticDefaults()
		{
			Achievement.SetCategory(AchievementCategory.Collector);
			AddItemPickupCondition(ModContent.ItemType<Prismaline>());
		}
	}
	public class CollectorAchievementCatfish : ModAchievement
	{
		public override void SetStaticDefaults()
		{
			Achievement.SetCategory(AchievementCategory.Collector);
			AddItemPickupCondition(ModContent.ItemType<TrueCatFish>());
		}
	}
}