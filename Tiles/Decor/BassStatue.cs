using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using WaasephisFishingPlus.NPCs.Passive;

namespace WaasephisFishingPlus.Tiles.Decor
{
	public class BassStatue : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileObsidianKill[Type] = true;
			TileID.Sets.DisableSmartCursor[Type] = true;
			TileID.Sets.IsAMechanism[Type] = true; // Ensures that this tile and connected pressure plate won't be removed during the "Remove Broken Traps" worldgen step

			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.addTile(Type);

			DustType = DustID.Silver;

			AddMapEntry(new Color(144, 148, 144), Language.GetText("MapObject.Statue"));
		}

		// This hook allows you to make anything happen when this statue is powered by wiring.
		// In this example, powering the statue either spawns a random coin with a 95% chance, or, with a 5% chance - a goldfish.
		public override void HitWire(int i, int j)
		{
			// Find the coordinates of top left tile square through math
			int y = j - Main.tile[i, j].TileFrameY / 18;
			int x = i - Main.tile[i, j].TileFrameX / 18;

			const int TileWidth = 2;
			const int TileHeight = 3;

			// Here we call SkipWire on all tile coordinates covered by this tile. This ensures a wire signal won't run multiple times.
			for (int yy = y; yy < y + TileHeight; yy++)
			{
				for (int xx = x; xx < x + TileWidth; xx++)
				{
					Wiring.SkipWire(xx, yy);
				}
			}

			// Calculcate the center of this tile to use as an entity spawning position.
			// Note that we use 0.65 for height because even though the statue takes 3 blocks, its appearance is shorter.
			float spawnX = (x + TileWidth * 0.5f) * 16;
			float spawnY = (y + TileHeight * 0.65f) * 16;

			// This example shows both item spawning code and npc spawning code, you can use whichever code suits your mod
			// There is a 95% chance for item spawn and a 5% chance for npc spawn
			// If you want to make a item spawning statue, see below.

			var entitySource = new EntitySource_TileUpdate(x, y, context: "BassStatue");
			{
				// If you want to make an NPC spawning statue, see below.
				int npcIndex = -1;

				// 30 is the time before it can be used again. NPC.MechSpawn checks nearby for other spawns to prevent too many spawns. 3 in immediate vicinity, 6 nearby, 10 in world.
				int spawnedNpcId = ModContent.NPCType<BassCritter>();

				if (Wiring.CheckMech(x, y, 30) && NPC.MechSpawn(spawnX, spawnY, spawnedNpcId))
				{
					npcIndex = NPC.NewNPC(entitySource, (int)spawnX, (int)spawnY - 12, spawnedNpcId);
				}

				if (npcIndex >= 0)
				{
					var npc = Main.npc[npcIndex];

					npc.value = 0f;
					npc.npcSlots = 0f;
					// Prevents Loot if NPCID.Sets.NoEarlymodeLootWhenSpawnedFromStatue and !Main.HardMode or NPCID.Sets.StatueSpawnedDropRarity != -1 and NextFloat() >= NPCID.Sets.StatueSpawnedDropRarity or killed by traps.
					// Prevents CatchNPC
					npc.SpawnedFromStatue = true;
				}
			}
		}
	}

	internal class BassStatueItem : ModItem
	{
		public override void SetStaticDefaults()
		{

		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 24;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 10;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = Item.sellPrice(copper: 60);
			Item.rare = ItemRarityID.White;
			Item.createTile = ModContent.TileType<BassStatue>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StoneBlock, 50);
			recipe.AddIngredient(ItemID.Bass, 5);
			recipe.AddTile(TileID.HeavyWorkBench);
			recipe.Register();
		}
	}
}