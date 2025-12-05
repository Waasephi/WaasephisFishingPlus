using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace WaasephisFishingPlus.Content.Tiles.Decor
{
	public class Shellforge : ModTile
	{
		public Asset<Texture2D> GlowTexture { get; private set; }

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
			AddMapEntry(new Color(83, 89, 104), name);
			DustType = DustID.Cobalt;
			HitSound = SoundID.Tink;
			AdjTiles = new int[] { TileID.Furnaces };
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			Tile tile = Framing.GetTileSafely(i, j);
			if (tile.TileFrameX < 18)
			{
				r = 0.8f;
				g = 0.8f;
				b = 1f;
			}
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			GlowTexture ??= ModContent.Request<Texture2D>("WaasephisFishingPlus/Content/Tiles/Decor/ShellforgeGlow");

			Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);

			if (Main.drawToScreen)
			{
				zero = Vector2.Zero;
			}
		}
	}
}