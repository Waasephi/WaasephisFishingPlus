using Terraria;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Content.Buffs
{
	public class MinorSwiftnessBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.moveSpeed *= 1.15f;
		}
	}
}