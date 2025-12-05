using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using WaasephisFishingPlus.Content.Items.Potions;

namespace WaasephisFishingPlus.Content.Tiles
{
    public class LavaBombDispenser : ModTile
    {

        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = false;
            TileID.Sets.HasOutlines[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.addTile(Type);
            AnimationFrameHeight = 36;
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(151, 163, 163), name);
            MinPick = 50;
            DustType = DustID.Silver;
            HitSound = SoundID.Tink;
        }

        public override bool CanExplode(int i, int j)
        {
            return true;
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
        {
            return true;
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<BottledLava>();
            player.cursorItemIconText = "";
        }

        public override void MouseOverFar(int i, int j)
        {
            MouseOver(i, j);
            Player player = Main.LocalPlayer;
            if (player.cursorItemIconText == "")
            {
                player.cursorItemIconEnabled = false;
                player.cursorItemIconID = ItemID.None;
            }
        }

        public override bool RightClick(int i, int j)
        {


            Player player = Main.LocalPlayer;
			if (player.HasItem(ModContent.ItemType<BottledLava>()))
			{
				SoundEngine.PlaySound(SoundID.Item61, player.Center);

				Main.LocalPlayer.ConsumeItem(ModContent.ItemType<BottledLava>());

				int x = i;
				int y = j;
				while (Main.tile[x, y].TileType == Type) x--;
				x++;
				while (Main.tile[x, y].TileType == Type) y--;
				y++;

				int SpawnX = x * 16 + 55;
				int SpawnY = y * 16 + 50;

				Projectile.NewProjectile(new EntitySource_TileInteraction(player, x * 16, y * 16), SpawnX - 31, SpawnY - 60, 0, -3, ProjectileID.LavaBomb, 0, 0, Main.myPlayer);


			}
			return true;
		}
    }
}