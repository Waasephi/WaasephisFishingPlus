using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;

namespace WaasephisFishingPlus.Content.Tiles.Decor.Furniture.Shellstone
{
	public class ShellstoneBathtub : ModTile
	{

		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
			TileObjectData.newTile.Origin = new Point16(1, 1);
			TileObjectData.addTile(Type);
			AddMapEntry(new Color(83, 89, 104), Lang.GetItemName(ItemID.Bathtub));
			DustType = DustID.Cobalt;
			HitSound = SoundID.Tink;
			AdjTiles = new int[] { TileID.Bathtubs };
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}