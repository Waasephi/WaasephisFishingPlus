using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.GameContent.ObjectInteractions;
using WaasephisFishingPlus.UserInterfaces;
using Terraria.Audio;
using WaasephisFishingPlus.Content.Items.Blocks;
using WaasephisFishingPlus.Content.Items.Filleting;

namespace WaasephisFishingPlus.Content.Tiles
{
	internal class FilletingTable : ModTile
	{
		public override void SetStaticDefaults()
		{
            Main.tileSolidTop[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(169, 125, 93), name);
            DustType = DustID.WoodFurniture;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<FilletKnife>();
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

		public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
		{
			return true;
		}

		public override bool RightClick(int i, int j)
        {
            int x = i;
            int y = j;
            while (Main.tile[x, y].TileType == Type) x--;
            x++;
            while (Main.tile[x, y].TileType == Type) y--;
            y++;

            FilletingUI.UIOpen = true;
            FilletingUI.openingPos = new Vector2(x * 16f, y * 16f);
            SoundEngine.PlaySound(SoundID.MenuOpen, new Vector2(x * 16f, y * 16f));
            return true;
        }
	}
}