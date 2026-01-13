using Terraria;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Content.Buffs
{
	public class MinorDefenseBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.statDefense += 4;
		}
	}
}