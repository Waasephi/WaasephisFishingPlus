using Terraria;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Content.Buffs
{
	public class TackleBoxBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.fishingSkill += 10;
			player.accTackleBox = true;
		}
	}
}