using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;

namespace WaasephisFishingPlus.Content.Tiles.Decor.Furniture.Shellstone
{
	public class ShellstoneBookcase : ModTile
	{

		public override void SetStaticDefaults()
		{
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 16 };
			TileObjectData.addTile(Type);
			AddMapEntry(new Color(83, 89, 104), Lang.GetItemName(ItemID.Bookcase));
			DustType = DustID.Cobalt;
			HitSound = SoundID.Tink;
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
			AdjTiles = new int[] { TileID.Bookcases };
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}