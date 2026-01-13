using Terraria;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Content.Buffs
{
	public class MinorDamageBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetDamage(DamageClass.Generic) *= 1.05f;
		}
	}
}