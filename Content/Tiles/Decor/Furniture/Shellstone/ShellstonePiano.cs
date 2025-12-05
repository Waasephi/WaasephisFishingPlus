using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;

namespace WaasephisFishingPlus.Content.Tiles.Decor.Furniture.Shellstone
{
	public class ShellstonePiano : ModTile
	{

		public override void SetStaticDefaults()
		{
			Main.tileSolidTop[Type] = false;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.Origin = new Point16(1, 1);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(83, 89, 104), Lang.GetItemName(ItemID.Piano));
			DustType = DustID.Cobalt;
			HitSound = SoundID.Tink;
			AdjTiles = new int[] { TileID.Pianos };
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}