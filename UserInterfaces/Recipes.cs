using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content.Tiles.Decor;
using WaasephisFishingPlus.Content.Items.Fish.QuestFish;
using WaasephisFishingPlus.Content.Items.Fish;
using WaasephisFishingPlus.Content.Items.Food;
using WaasephisFishingPlus.Content.Items.Materials;
using WaasephisFishingPlus.Content.Items.Weapons.Melee;
using WaasephisFishingPlus.Content.Items.Weapons.Ranged;
using static WaasephisFishingPlus.WaasephisFishingPlus;
using static WaasephisFishingPlus.UserInterfaces.FilletingUI;
using Terraria.ModLoader.Default;
using WaasephisFishingPlus.Content.Items.Consumables.PotSnails;
using WaasephisFishingPlus.Content.Items.Tools;

namespace WaasephisFishingPlus.UserInterfaces
{
    internal class Recipes
    {
	    private static bool recipesInitialized = false;
        public static void SetRecipes()
        {

            /*
            this is how to do it with modded inputs and modded outputs
            item = new Item();
            item.SetDefaults(ModContent.ItemType<GalacticFilletKnife>()); //modded input
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item() };
            Recipe.Output.SetDefaults(ModContent.ItemType<FilletKnife>());  //modded output
            AddRecipe(item, Recipe);
            */

            if (recipesInitialized) return; // Prevents duplicate recipes from being added
            recipesInitialized = true;
            Item item = new Item();
            FishRecipes Recipe;

			#region Regular Fish

            item = new Item();
            item.SetDefaults(ItemID.ArmoredCavefish);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.IronBar);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.AtlanticCod);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ModContent.ItemType<FishFillet>());
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Bass);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ModContent.ItemType<FishFillet>());
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.BlueJellyfish);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0, ignoreKnife = true };
            Recipe.Output.SetDefaults(ItemID.JellyfishNecklace);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.ChaosFish);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 1 };
            Recipe.Output.SetDefaults(ItemID.SoulofLight);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.CrimsonTigerfish);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 1 };
            Recipe.Output.SetDefaults(ItemID.SoulofNight);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Damselfish);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ModContent.ItemType<FishFillet>());
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.DoubleCod);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ModContent.ItemType<FishFillet>());
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Ebonkoi);
            Recipe = new FishRecipes { DefaultAmount = 4, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.DemoniteOre);
            AddRecipe(item, Recipe);

			item = new Item();
            item.SetDefaults(ItemID.FlarefinKoi);
            Recipe = new FishRecipes { DefaultAmount = 3, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.Hellstone);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Flounder);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ModContent.ItemType<FishFillet>());
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.FrostMinnow);
            Recipe = new FishRecipes { DefaultAmount = 20, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.SnowBlock);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.GoldenCarp);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.GoldenDelight);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.GreenJellyfish);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0, ignoreKnife = true };
            Recipe.Output.SetDefaults(ItemID.JellyfishNecklace);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Hemopiranha);
            Recipe = new FishRecipes { DefaultAmount = 4, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.CrimtaneOre);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Hungerfish);
            Recipe = new FishRecipes { DefaultAmount = 20, Output = new Item(), KnifeLevel = 1 };
            Recipe.Output.SetDefaults(ItemID.FleshBlock);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Honeyfin);
            Recipe = new FishRecipes { DefaultAmount = 5, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.BottledHoney);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.NeonTetra);
            Recipe = new FishRecipes { DefaultAmount = 3, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ModContent.ItemType<NeonScales>());
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Obsidifish);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.Obsidian);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.PinkJellyfish);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0, ignoreKnife = true };
            Recipe.Output.SetDefaults(ItemID.JellyfishNecklace);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.PrincessFish);
            Recipe = new FishRecipes { DefaultAmount = 5, Output = new Item(), KnifeLevel = 1 };
            Recipe.Output.SetDefaults(ItemID.CrystalShard);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Prismite);
            Recipe = new FishRecipes { DefaultAmount = 10, Output = new Item(), KnifeLevel = 1 };
            Recipe.Output.SetDefaults(ItemID.CrystalShard);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.RedSnapper);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ModContent.ItemType<FishFillet>());
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.RockLobster);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.LobsterTail);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Salmon);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ModContent.ItemType<FishFillet>());
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Shrimp);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ModContent.ItemType<FishFillet>());
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.SpecularFish);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ModContent.ItemType<FishFillet>());
            AddRecipe(item, Recipe);

			item = new Item();
            item.SetDefaults(ItemID.Stinkfish);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.Stinkbug);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Trout);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ModContent.ItemType<FishFillet>());
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Tuna);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ModContent.ItemType<FishFillet>());
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.VariegatedLardfish);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ModContent.ItemType<FishFillet>());
            AddRecipe(item, Recipe);

			#endregion

			#region Quest Fish
			item = new Item();
            item.SetDefaults(ItemID.AmanitaFungifin);
            Recipe = new FishRecipes { DefaultAmount = 5, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.GlowingMushroom);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Angelfish);
            Recipe = new FishRecipes { DefaultAmount = 5, Output = new Item(), KnifeLevel = 1 };
            Recipe.Output.SetDefaults(ItemID.PixieDust);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Batfish);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0, ignoreKnife = true };
            Recipe.Output.SetDefaults(ItemID.ChainKnife);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.BloodyManowar);
            Recipe = new FishRecipes { DefaultAmount = 3, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.TissueSample);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Bonefish);
            Recipe = new FishRecipes { DefaultAmount = 6, Output = new Item(), KnifeLevel = 1 };
            Recipe.Output.SetDefaults(ItemID.Bone);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.BumblebeeTuna);
            Recipe = new FishRecipes { DefaultAmount = 5, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.HoneyBlock);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Bunnyfish);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.BunnyStew);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.CapnTunabeard);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 1, ignoreKnife = true };
            Recipe.Output.SetDefaults(ItemID.PirateMap);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Catfish);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0, ignoreKnife = true };
            Recipe.Output.SetDefaults(ItemID.LicenseCat);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Cloudfish);
            Recipe = new FishRecipes { DefaultAmount = 10, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.Cloud);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Clownfish);
            Recipe = new FishRecipes { DefaultAmount = 5, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.Coral);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Cursedfish);
            Recipe = new FishRecipes { DefaultAmount = 4, Output = new Item(), KnifeLevel = 1 };
            Recipe.Output.SetDefaults(ItemID.CursedFlame);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.DemonicHellfish);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.HellstoneBar);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Derpfish);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 1, ignoreKnife = true };
            Recipe.Output.SetDefaults(ItemID.GlommerPetItem);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Dirtfish);
            Recipe = new FishRecipes { DefaultAmount = 20, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.DirtBlock);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.DynamiteFish);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.Dynamite);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.EaterofPlankton);
            Recipe = new FishRecipes { DefaultAmount = 5, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.RottenChunk);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.FallenStarfish);
            Recipe = new FishRecipes { DefaultAmount = 5, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.FallenStar);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.TheFishofCthulu);
            Recipe = new FishRecipes { DefaultAmount = 5, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.Lens);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Fishotron);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0, ignoreKnife = true };
            Recipe.Output.SetDefaults(ItemID.ClothierVoodooDoll);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Fishron);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 1 };
            Recipe.Output.SetDefaults(ItemID.ScalyTruffle);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.GuideVoodooFish);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0, ignoreKnife = true };
            Recipe.Output.SetDefaults(ItemID.GuideVoodooDoll);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Harpyfish);
            Recipe = new FishRecipes { DefaultAmount = 5, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.Feather);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Ichorfish);
            Recipe = new FishRecipes { DefaultAmount = 4, Output = new Item(), KnifeLevel = 1 };
            Recipe.Output.SetDefaults(ItemID.Ichor);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.InfectedScabbardfish);
            Recipe = new FishRecipes { DefaultAmount = 3, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ShadowScale);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Jewelfish);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.Geode);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.MirageFish);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 2, ignoreKnife = true };
            Recipe.Output.SetDefaults(ItemID.RodofDiscord);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Mudfish);
            Recipe = new FishRecipes { DefaultAmount = 20, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.MudBlock);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.MutantFlinxfin);
            Recipe = new FishRecipes { DefaultAmount = 3, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.FlinxFur);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Pengfish);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.Penguin);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Pixiefish);
            Recipe = new FishRecipes { DefaultAmount = 5, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.PixieDust);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.ScarabFish);
            Recipe = new FishRecipes { DefaultAmount = 3, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ScarabBomb);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.ScorpioFish);
            Recipe = new FishRecipes { DefaultAmount = 3, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.Stinger);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Slimefish);
            Recipe = new FishRecipes { DefaultAmount = 15, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.Gel);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Spiderfish);
            Recipe = new FishRecipes { DefaultAmount = 4, Output = new Item(), KnifeLevel = 1 };
            Recipe.Output.SetDefaults(ItemID.SpiderFang);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.TropicalBarracuda);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0, ignoreKnife = true };
            Recipe.Output.SetDefaults(ItemID.RobotHat);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.TundraTrout);
            Recipe = new FishRecipes { DefaultAmount = 20, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.IceBlock);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.UnicornFish);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 1 };
            Recipe.Output.SetDefaults(ItemID.UnicornHorn);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Wyverntail);
            Recipe = new FishRecipes { DefaultAmount = 3, Output = new Item(), KnifeLevel = 1 };
            Recipe.Output.SetDefaults(ItemID.SoulofFlight);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.ZombieFish);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0, ignoreKnife = true };
            Recipe.Output.SetDefaults(ItemID.Shackle);
            AddRecipe(item, Recipe);
			#endregion

			#region Modded Regular Fish

			item = new Item();
			item.SetDefaults(ModContent.ItemType<AncientSquid>());
			Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 1 };
			Recipe.Output.SetDefaults(ItemID.AncientCloth);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<Asterovy>());
			Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ItemID.Meteorite);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<Ebonthodian>());
			Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 1 };
			Recipe.Output.SetDefaults(ItemID.SoulofNight);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<Ectolione>());
			Recipe = new FishRecipes { DefaultAmount = 5, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ItemID.EchoCoating);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<EtherianSeadragon>());
			Recipe = new FishRecipes { DefaultAmount = 5, Output = new Item(), KnifeLevel = 2 };
			Recipe.Output.SetDefaults(ItemID.DefenderMedal);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<FrigidLoach>());
			Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 1, ignoreKnife = true };
			Recipe.Output.SetDefaults(ItemID.FrostCore);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<Gobee>());
			Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ItemID.Stinger);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<GrassyGrouper>());
			Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ItemID.HerbBag);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<Heartang>());
			Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ItemID.LifeCrystal);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<Nebulagazer>());
			Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 2 };
			Recipe.Output.SetDefaults(ItemID.FragmentNebula);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<Solamola>());
			Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 2 };
			Recipe.Output.SetDefaults(ItemID.FragmentSolar);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<SporeSnapper>());
			Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ItemID.JungleSpores);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<Squid>());
			Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ItemID.BlackInk);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<Stardustfish>());
			Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 2 };
			Recipe.Output.SetDefaults(ItemID.FragmentStardust);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<SunRay>());
			Recipe = new FishRecipes { DefaultAmount = 20, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ItemID.SunplateBlock);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<TheSludge>());
			Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ModContent.ItemType<TheSludge>());
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<Vortexeye>());
			Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 2 };
			Recipe.Output.SetDefaults(ItemID.FragmentVortex);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<Woodskip>());
			Recipe = new FishRecipes { DefaultAmount = 15, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ItemID.Wood);
			AddRecipe(item, Recipe);

			#endregion

			#region Modded Quest Fish

			item = new Item();
			item.SetDefaults(ModContent.ItemType<AetherianAngler>());
			Recipe = new FishRecipes { DefaultAmount = 5, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ItemID.ShimmerBlock);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<Garnite>());
			Recipe = new FishRecipes { DefaultAmount = 20, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ItemID.Granite);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<GlassAnomalocaris>());
			Recipe = new FishRecipes { DefaultAmount = 20, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ItemID.Glass);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<HellstoneSnail>());
			Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ItemID.HellstoneBar);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<Marbeel>());
			Recipe = new FishRecipes { DefaultAmount = 20, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ItemID.Marble);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<Mecherel>());
			Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 1 };
			Recipe.Output.SetDefaults(ItemID.HallowedBar);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<SantaRay>());
			Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 1, ignoreKnife = true };
			Recipe.Output.SetDefaults(ItemID.SnowGlobe);
			AddRecipe(item, Recipe);

			#endregion

			#region Legendary Fish

			item = new Item();
			item.SetDefaults(ModContent.ItemType<Oarfish>());
			Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0, ignoreKnife = true };
			Recipe.Output.SetDefaults(ModContent.ItemType<OarfishTrophyItem>());
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<RegalMoonsquid>());
			Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0, ignoreKnife = true };
			Recipe.Output.SetDefaults(ModContent.ItemType<RegalMoonsquidTrophyItem>());
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<Searobin>());
			Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0, ignoreKnife = true };
			Recipe.Output.SetDefaults(ModContent.ItemType<SearobinTrophyItem>());
			AddRecipe(item, Recipe);

			#endregion

			#region Usable Items
			item = new Item();
            item.SetDefaults(ItemID.FrogLeg);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0, ignoreKnife = true };
            Recipe.Output.SetDefaults(ItemID.Frog);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.BalloonPufferfish);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0, ignoreKnife = true };
            Recipe.Output.SetDefaults(ItemID.ShinyRedBalloon);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.BombFish);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.Bomb);
            AddRecipe(item, Recipe);

			item = new Item();
            item.SetDefaults(ItemID.PurpleClubberfish);
            Recipe = new FishRecipes { DefaultAmount = 25, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.EbonstoneBlock);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.ReaverShark);
            Recipe = new FishRecipes { DefaultAmount = 3, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ModContent.ItemType<SharkTooth>());
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Rockfish);
            Recipe = new FishRecipes { DefaultAmount = 25, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.StoneBlock);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.SawtoothShark);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ModContent.ItemType<SharkTooth>());
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.FrostDaggerfish);
            Recipe = new FishRecipes { DefaultAmount = 3, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.IceBlock);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Swordfish);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0, ignoreKnife = true };
            Recipe.Output.SetDefaults(ItemID.Trident);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.ZephyrFish);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0, ignoreKnife = true };
            Recipe.Output.SetDefaults(ItemID.CarbonGuitar);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Honeyfin);
            Recipe = new FishRecipes { DefaultAmount = 3, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.BottledHoney);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Toxikarp);
            Recipe = new FishRecipes { DefaultAmount = 25, Output = new Item(), KnifeLevel = 1 };
            Recipe.Output.SetDefaults(ItemID.LesionBlock);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Bladetongue);
            Recipe = new FishRecipes { DefaultAmount = 25, Output = new Item(), KnifeLevel = 1 };
            Recipe.Output.SetDefaults(ItemID.FleshBlock);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.CrystalSerpent);
            Recipe = new FishRecipes { DefaultAmount = 25, Output = new Item(), KnifeLevel = 1 };
            Recipe.Output.SetDefaults(ItemID.CrystalBlock);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.ScalyTruffle);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 1, ignoreKnife = true };
            Recipe.Output.SetDefaults(ItemID.TruffleWorm);
            AddRecipe(item, Recipe);

			item = new Item();
            item.SetDefaults(ItemID.ObsidianSwordfish);
            Recipe = new FishRecipes { DefaultAmount = 25, Output = new Item(), KnifeLevel = 1 };
            Recipe.Output.SetDefaults(ItemID.Obsidian);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Oyster);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.WhitePearl);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.CombatBook);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.SpellTome);
            AddRecipe(item, Recipe);
			#endregion

			#region Modded Usable Items

			item = new Item();
			item.SetDefaults(ModContent.ItemType<FleshySpewer>());
			Recipe = new FishRecipes { DefaultAmount = 25, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ItemID.CrimstoneBlock);
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<SeaUrchin>());
			Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 1 };
			Recipe.Output.SetDefaults(ItemID.VialofVenom);
			AddRecipe(item, Recipe);

			#endregion

			#region Modded Critters

			item = new Item();
			item.SetDefaults(ModContent.ItemType<PotSnailCorruptionItem>());
			Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ModContent.ItemType<PurpleGelatin>());
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<PotSnailDesertItem>());
			Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ModContent.ItemType<YellowGelatin>());
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<PotSnailDungeonItem>());
			Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ModContent.ItemType<PurpleGelatin>());
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<PotSnailHellItem>());
			Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ModContent.ItemType<RedGelatin>());
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<PotSnailIceItem>());
			Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ModContent.ItemType<BlueGelatin>());
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<PotSnailJungleItem>());
			Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ModContent.ItemType<GreenGelatin>());
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<PotSnailTempleItem>());
			Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ModContent.ItemType<GreenGelatin>());
			AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ModContent.ItemType<PotSnailUGItem>());
			Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
			Recipe.Output.SetDefaults(ModContent.ItemType<BlueGelatin>());
			AddRecipe(item, Recipe);

			#endregion

			#region Bait
			item = new Item();
            item.SetDefaults(ItemID.ApprenticeBait);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.JourneymanBait);
            Recipe = new FishRecipes { DefaultAmount = 3, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.MasterBait);
            Recipe = new FishRecipes { DefaultAmount = 5, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.BlackDragonfly);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.BlackScorpion);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.BlueDragonfly);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Buggy);
            Recipe = new FishRecipes { DefaultAmount = 3, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.EnchantedNightcrawler);
            Recipe = new FishRecipes { DefaultAmount = 4, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Firefly);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.GlowingSnail);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.GoldButterfly);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.GoldenDelight);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.GoldDragonfly);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.GoldenDelight);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.GoldGrasshopper);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.GoldenDelight);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.GoldLadyBug);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.GoldenDelight);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.GoldWaterStrider);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.GoldenDelight);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.GoldWorm);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.GoldenDelight);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.GoldGoldfish);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.GoldOre);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Grasshopper);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.GreenDragonfly);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Grubby);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.HellButterfly);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.JuliaButterfly);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.LadyBug);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Lavafly);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.LightningBug);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.MagmaSnail);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Maggot);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.MonarchButterfly);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.OrangeDragonfly);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.PurpleEmperorButterfly);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.RedAdmiralButterfly);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.RedDragonfly);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Scorpion);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Sluggy);
            Recipe = new FishRecipes { DefaultAmount = 3, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Snail);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Stinkbug);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.SulphurButterfly);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.TreeNymphButterfly);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.TruffleWorm);
            Recipe = new FishRecipes { DefaultAmount = 10, Output = new Item(), KnifeLevel = 1 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.UlyssesButterfly);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.WaterStrider);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Worm);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.YellowDragonfly);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.ZebraSwallowtailButterfly);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ChumBucket);
            AddRecipe(item, Recipe);

            //Junk
            item = new Item();
            item.SetDefaults(ItemID.OldShoe);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.Leather);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Seaweed);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.ApprenticeBait);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.TinCan);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.TinBar);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.JojaCola);
            Recipe = new FishRecipes { DefaultAmount = 2, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.BottledWater);
            AddRecipe(item, Recipe);
            #endregion

            #region Other

            item = new Item();
            item.SetDefaults(ItemID.FishMinecart);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0, ignoreKnife = true };
            Recipe.Output.SetDefaults(ItemID.Minecart);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.GoldfishTrophy);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.Goldfish);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.BunnyfishTrophy);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0, ignoreKnife = true };
            Recipe.Output.SetDefaults(ItemID.Bunnyfish);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.SwordfishTrophy);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0, ignoreKnife = true };
            Recipe.Output.SetDefaults(ItemID.Swordfish);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.SharkteethTrophy);
            Recipe = new FishRecipes { DefaultAmount = 5, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ModContent.ItemType<SharkTooth>());
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.SilentFish);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.Bass);
            AddRecipe(item, Recipe);

            item = new Item();
            item.SetDefaults(ItemID.Goldfish);
            Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0 };
            Recipe.Output.SetDefaults(ItemID.GoldOre);
            AddRecipe(item, Recipe);

			item = new Item();
			item.SetDefaults(ItemID.WhiteString);
			Recipe = new FishRecipes { DefaultAmount = 1, Output = new Item(), KnifeLevel = 0, ignoreKnife = true };
			Recipe.Output.SetDefaults(ItemID.HighTestFishingLine);
			AddRecipe(item, Recipe);
			#endregion
		}
    }
}
