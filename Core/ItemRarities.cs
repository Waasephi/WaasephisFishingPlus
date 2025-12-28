using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace WaasephisFishingPlus.Core
{
	public class OarfishRarity : ModRarity
	{
		public override Color RarityColor => Color.Lerp(new Color(186, 224, 238), new Color(82, 103, 124), (float)Math.Cos((double)(Main.GlobalTimeWrappedHourly % 2.5f / 2.5f * 5f)) / 2f + 0.5f);
	}
	public class SearobinRarity : ModRarity
	{
		public override Color RarityColor => Color.Lerp(new Color(243, 185, 147), new Color(117, 29, 29), (float)Math.Cos((double)(Main.GlobalTimeWrappedHourly % 2.5f / 2.5f * 5f)) / 2f + 0.5f);
	}
	public class MoonsquidRarity : ModRarity
	{
		public override Color RarityColor => Color.Lerp(new Color(206, 255, 239), new Color(33, 156, 140), (float)Math.Cos((double)(Main.GlobalTimeWrappedHourly % 2.5f / 2.5f * 5f)) / 2f + 0.5f);
	}
	public class BaxterRarity : ModRarity
	{
		public override Color RarityColor => Color.Lerp(new Color(207, 207, 207), new Color(47, 47, 47), (float)Math.Cos((double)(Main.GlobalTimeWrappedHourly % 2.5f / 2.5f * 5f)) / 2f + 0.5f);
	}
}