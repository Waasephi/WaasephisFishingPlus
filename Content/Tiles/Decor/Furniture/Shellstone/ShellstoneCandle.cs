using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace WaasephisFishingPlus.Content.Tiles.Decor.Furniture.Shellstone
{
	public class ShellstoneCandle : ModTile
	{
		private Asset<Texture2D> GlowTexture;

		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			Main.tileLighted[Type] = true;
			TileID.Sets.DisableSmartCursor[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
			TileObjectData.newTile.CoordinateHeights = new int[] { 18 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.addTile(Type);
			TileObjectData.newTile.WaterDeath = false;
			TileObjectData.newTile.WaterPlacement = LiquidPlacement.Allowed;
			TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
			LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(83, 89, 104), Lang.GetItemName(ItemID.Candle));
			RegisterItemDrop(ModContent.ItemType<ShellstoneCandleItem>());
			DustType = DustID.Pearlsand;
			HitSound = SoundID.Tink;
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
			AdjTiles = new int[] { TileID.Candles };
		}

		public override void HitWire(int i, int j)
		{
			if (Main.tile[i, j].TileFrameX >= 18)
			{
				Main.tile[i, j].TileFrameX -= 18;
			}
			else
			{
				Main.tile[i, j].TileFrameX += 18;
			}
		}

		public override bool RightClick(int i, int j)
		{
			Main.player[Main.myPlayer].PickTile(i, j, 100);
			return true;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void MouseOver(int i, int j)
		{
			Player player = Main.LocalPlayer;
			player.noThrow = 2;
			player.cursorItemIconEnabled = true;
			player.cursorItemIconID = ModContent.ItemType<ShellstoneCandleItem>();
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

		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			GlowTexture ??= ModContent.Request<Texture2D>("WaasephisFishingPlus/Content/Tiles/Decor/Furniture/Shellstone/ShellstoneCandleGlow");

			Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);

			if (Main.drawToScreen)
			{
				zero = Vector2.Zero;
			}
		}
	}
}