using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using WaasephisFishingPlus.Content.Buffs;

namespace WaasephisFishingPlus.Content.Tiles
{
    public class BaitBox : ModTile
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
            AddMapEntry(new Color(171, 182, 183), name);
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
            player.cursorItemIconID = ItemID.JourneymanBait;
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

			player.AddBuff(ModContent.BuffType<TackleBoxBuff>(), 14400);

			return true;
		}
    }
}