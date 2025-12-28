using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using WaasephisFishingPlus.Core;

namespace WaasephisFishingPlus.Content.Tiles.Decor.Paintings
{
    internal class BaxterByThePond : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileWaterDeath[Type] = false;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(153, 119, 94), Language.GetText("MapObject.Painting"));
            HitSound = SoundID.Dig;
            DustType = -1;
        }
    }

    internal class BaxterByThePondItem : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ModContent.RarityType<BaxterRarity>();
			Item.createTile = ModContent.TileType<BaxterByThePond>();
        }
    }
}