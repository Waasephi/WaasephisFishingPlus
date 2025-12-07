using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using WaasephisFishingPlus.Content;
using WaasephisFishingPlus.UserInterfaces;
using Recipes = WaasephisFishingPlus.UserInterfaces.Recipes;

namespace WaasephisFishingPlus
{
    // Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
    public class WaasephisFishingPlus : Mod
    {
		public struct Knife
		{
			public Item knife;
			public int modifier;
			public int level;
		}

		public struct FishRecipes
		{
			public int DefaultAmount;
			public Item Output;
			public int KnifeLevel;
			public bool ignoreKnife = false;

			public FishRecipes()
			{
			}
		}

		public static List<Knife> knives = new List<Knife>();
		public static Dictionary<Item, FishRecipes> recipes = new Dictionary<Item, FishRecipes>();

		public static void AddKnife(Item knifeItem, int modifier, int knifeLevel)
		{
			if (knives.Any(k => k.knife.type == knifeItem.type))
				return;
			knives.Add(new Knife { knife = knifeItem, modifier = modifier, level = knifeLevel });
		}

		public static void AddRecipe(Item inputItem, Item outputItem, int defaultAmount, int knifeLevel, bool ignoreKnifeModifier)
		{
			if (recipes.ContainsKey(inputItem))
				return; // Prevent duplicate recipes

			FishRecipes recipe = new FishRecipes
			{
				DefaultAmount = defaultAmount,
				Output = outputItem,
				KnifeLevel = knifeLevel,
				ignoreKnife = ignoreKnifeModifier
			};

			recipes.Add(inputItem, recipe);
		}

		public override void PostAddRecipes()
		{
			Recipes.SetRecipes();
			Knives.setKnives();
		}

		public override object Call(params object[] args)
        {
            if (args.Length == 0)
            {
                return base.Call(args);
            }

            string command = args[0] as string;

            if (command == "AddKnife" && args.Length == 4)
            {
                Item knifeItem = args[1] as Item;
                int modifier = Convert.ToInt32(args[2]);
                int level = Convert.ToInt32(args[3]);
                AddKnife(knifeItem, modifier, level);
            }
            else if (command == "AddRecipe" && args.Length == 6)
            {
                Item inputItem = args[1] as Item;
                Item outputItem = args[2] as Item;
                int defaultAmount = Convert.ToInt32(args[3]);
                int knifeLevel = Convert.ToInt32(args[4]);
                bool ignoreKnifeModifier = Convert.ToBoolean(args[5]);
                AddRecipe(inputItem, outputItem, defaultAmount, knifeLevel, ignoreKnifeModifier);
            }

            return base.Call(args);
        }
    }
}
