using WaasephisFishingPlus.Projectiles.Pets;
using Terraria;
using Terraria.ModLoader;

namespace WaasephisFishingPlus.Buffs.Pets
{
    public class SeaSlugBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        { // This method gets called every frame your buff is active on your player.
            bool unused = false;
            player.BuffHandle_SpawnPetIfNeededAndSetTime(buffIndex, ref unused, ModContent.ProjectileType<SeaSlug>());
        }
    }
}