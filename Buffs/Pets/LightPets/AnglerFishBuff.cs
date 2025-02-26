using Terraria;
using Terraria.ModLoader;
using WaasephisFishingPlus.Projectiles.Pets.LightPets;

namespace WaasephisFishingPlus.Buffs.Pets.LightPets
{
	public class AnglerFishBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			Main.lightPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{ // This method gets called every frame your buff is active on your player.
			bool unused = false;
			player.BuffHandle_SpawnPetIfNeededAndSetTime(buffIndex, ref unused, ModContent.ProjectileType<AnglerFishPet>());
		}
	}
}