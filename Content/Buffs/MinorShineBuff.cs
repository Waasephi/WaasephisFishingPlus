using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Content.Buffs
{
	public class MinorShineBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
		}

		public override void Update(Player player, ref int buffIndex)
		{
			Lighting.AddLight(player.position, Color.White.ToVector3() * 0.5f);
		}
	}
}