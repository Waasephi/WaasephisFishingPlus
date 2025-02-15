using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Terraria.UI.Chat;
using System.Linq;

namespace WaasephisFishingPlus.UserInterfaces
{
    public class FilletingUI
    {
        public static int Filleting = -1;
        public static bool UIOpen = false;
        public static bool IsHoveringOverAnyButton = false;
        public static Item CurrentlyHeldItem = new Item();
        public static Item CurrentlyHeldItem2 = new Item();
        public static Item CurrentlyHeldItem3 = new Item();
        public static float ItemScale = 2f;
        public static List<Knife> knives = new List<Knife>();
        public static Vector2 openingPos = Vector2.Zero;
        public static float itemOpacity = 0.5f;
        public static Vector2 itemPos = new Vector2(9, 9);

        public struct Knife
        {
            public Item knife;
            public int modifier;
            public int level;
        }

        public struct FishRecipes
        {
            public int DefaultAmount;
            public Item Output;
            public int KnifeLevel;
            public bool ignoreKnife = false;

            public FishRecipes()
            {
            }
        }


        public static Dictionary<Item, FishRecipes> recipes = new Dictionary<Item, FishRecipes>();

        public static Vector2 UITopLeft => new Vector2(Main.screenWidth * 0.5f, Main.screenHeight * 0.5f);
        public static void AddKnife(Item knifeItem, int modifier, int knifeLevel)
		{
			if (knives.Any(k => k.knife.type == knifeItem.type))
				return;
			knives.Add(new Knife { knife = knifeItem, modifier = modifier, level = knifeLevel });
		}
        public static void AddRecipe(Item inputItem, Item outputItem, int defaultAmount, int knifeLevel, bool ignoreKnifeModifier)
		{
			if (recipes.ContainsKey(inputItem))
				return; // Prevent duplicate recipes

			FishRecipes recipe = new FishRecipes
			{
				DefaultAmount = defaultAmount,
				Output = outputItem,
				KnifeLevel = knifeLevel,
				ignoreKnife = ignoreKnifeModifier
			};

			recipes.Add(inputItem, recipe);
		}
		
        public static Rectangle MouseScreenArea => Utils.CenteredRectangle(Main.MouseScreen, Vector2.One * 2f);

        public static Item PreviousOutputItem = new Item();
        public static void Draw(SpriteBatch spriteBatch)
        {
            if (!UIOpen)
            {
                Filleting = -1;
                return;
            }

            if (Main.LocalPlayer.chest != -1 || Main.LocalPlayer.sign != -1 || Main.InGuideCraftMenu)
            {
                closeUI();
            }

            if (Main.ingameOptionsWindow)
            {
                closeUI();
            }

            if (Vector2.Distance(Main.LocalPlayer.Center, openingPos) > 200f)
            {
                closeUI();
            }

            if (Main.keyState.IsKeyDown(Keys.Escape))
            {
                closeUI();
            }

			if (UIOpen)
			{
				Recipes.SetRecipes();
				Knives.setKnives();
			}
            
            Main.playerInventory = true;
            Main.npcChatText = string.Empty;

            Texture2D UIBoxTexture = ModContent.Request<Texture2D>("WaasephisFishingPlus/UserInterfaces/FilletingBar").Value;
            Vector2 UIBoxScale = Vector2.One * Main.UIScale;
            Vector2 UICenter = UITopLeft + new Vector2(UIBoxTexture.Width / 2f * UIBoxScale.X, UIBoxTexture.Height / 2f * UIBoxScale.Y);

            spriteBatch.Draw(UIBoxTexture, UITopLeft, null, Color.White, 0f, UIBoxTexture.Size() / 2, UIBoxScale, SpriteEffects.None, 0f);

            if (IsMouseOverUI((int)UITopLeft.X, (int)UITopLeft.Y, UIBoxTexture, UIBoxScale))
            {
                IsHoveringOverAnyButton = false;

                Main.LocalPlayer.mouseInterface = false;
                Main.blockMouse = true;
            }

            Texture2D CloseIconTexture = ModContent.Request<Texture2D>("WaasephisFishingPlus/UserInterfaces/CloseIcon").Value;
            Texture2D ItemIconTexture = ModContent.Request<Texture2D>("WaasephisFishingPlus/UserInterfaces/ItemIcon").Value;
            Texture2D ItemIconIronTexture = ModContent.Request<Texture2D>("WaasephisFishingPlus/UserInterfaces/ItemIconIron").Value;

            Point ButtonTopLeft = (UITopLeft + new Vector2(-32f, 32f) * UIBoxScale).ToPoint();

            Vector2 CloseIconTopLeft = ButtonTopLeft.ToVector2() + new Vector2(210, -165) * Main.UIScale;

            Vector2 startPosition = UITopLeft + new Vector2(-200, 0) * Main.UIScale;

			Vector2 itemSlot1DrawPosition = startPosition;
            Vector2 itemSlot2DrawPosition = startPosition + (new Vector2(182f, -50f) * Main.UIScale);
            Vector2 itemSlot3DrawPosition = startPosition + (new Vector2(364f, 0f) * Main.UIScale);

            DrawIcon(spriteBatch, CloseIconTopLeft, CloseIconTexture);
            DrawItemIcon(spriteBatch, itemSlot1DrawPosition, UIBoxScale, CurrentlyHeldItem, ItemIconTexture, 1);
            DrawItemIcon(spriteBatch, itemSlot2DrawPosition, UIBoxScale, CurrentlyHeldItem2, ItemIconTexture, 2);
            DrawItemIcon(spriteBatch, itemSlot3DrawPosition, UIBoxScale, CurrentlyHeldItem3, ItemIconIronTexture, 3);

            if (IsMouseOverUI((int)CloseIconTopLeft.X, (int)CloseIconTopLeft.Y, CloseIconTexture, UIBoxScale))
            {
                if (Main.mouseLeftRelease && Main.mouseLeft)
                {
                    closeUI();
                }
            }
            if (IsMouseOverUI((int)itemSlot1DrawPosition.X, (int)itemSlot1DrawPosition.Y, ItemIconTexture, UIBoxScale))
            {
                Main.LocalPlayer.mouseInterface = true;
                Main.blockMouse = true;
            }
            if (IsMouseOverUI((int)itemSlot2DrawPosition.X, (int)itemSlot2DrawPosition.Y, ItemIconTexture, UIBoxScale))
            {
                Main.LocalPlayer.mouseInterface = true;
                Main.blockMouse = true;
            }
            if (CurrentlyHeldItem3.IsAir && !CurrentlyHeldItem.IsAir && !CurrentlyHeldItem2.IsAir)
            {
                if (!PreviousOutputItem.IsAir)
                {
                    SubtractFromInput();
                }
                doFillet();
            }

            PreviousOutputItem = CurrentlyHeldItem3.Clone();
        }

        public static void closeUI()
        {
            UIOpen = false;
            DropAllItems();
            SoundEngine.PlaySound(SoundID.MenuClose, Main.LocalPlayer.Center);
            return;
        }

        private static void DropItem(Item item)
        {
            if (!item.IsAir)
            {
                Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_Misc("PlayerDropItemCheck"), item.type, item.stack);
            }
        }
        public static void DropAllItems()
        {
            DropItem(CurrentlyHeldItem);
            DropItem(CurrentlyHeldItem2);
            //DropItem(CurrentlyHeldItem3);

            CurrentlyHeldItem = new Item();
            CurrentlyHeldItem2 = new Item();
            //CurrentlyHeldItem3 = new Item();
        }

        public static void doFillet()
        {
            if (CurrentlyHeldItem2.IsAir) return;
            if (!CurrentlyHeldItem3.IsAir) return;

            foreach (var recipe in recipes)
            {
                if (recipe.Key.netID == CurrentlyHeldItem.netID)
                {
                    Item outputItem = recipe.Value.Output.Clone();
                    outputItem.stack = recipe.Value.DefaultAmount;
                    if (!recipe.Value.ignoreKnife) 
                    {
                        outputItem.stack += knifeModifierAmount();
                    }


                    if (GetKnifeLevel() >= recipe.Value.KnifeLevel)
                    {
                        CurrentlyHeldItem3 = outputItem; 
                        Main.instance.LoadItem(CurrentlyHeldItem3.type);
                        SoundEngine.PlaySound(SoundID.Grab);
                    }
                    break;
                }
            }
            if (CurrentlyHeldItem3.stack <= 0)
	            CurrentlyHeldItem3.TurnToAir();
        }

        public static int knifeModifierAmount()
        {
            foreach (var i in knives)
            {
                if (CurrentlyHeldItem2.netID == i.knife.netID) return i.modifier;
            }
            return 0;
        }

        public static int GetKnifeLevel()
        {
            foreach (var i in knives)
            {
                if (CurrentlyHeldItem2.netID == i.knife.netID) return i.level;
            }
            return -1;
        }

        public static void AddRecipe(Item item, FishRecipes recipe)
        {
            if (!recipes.ContainsKey(item)) recipes.Add(item, recipe);
        }

        public static void DrawTextDescription(SpriteBatch spriteBatch, Vector2 nameDrawCenter, string Text)
        {
            Vector2 scale = new Vector2(0.85f, 0.85f) * Main.UIScale;
            ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.MouseText.Value, Text, nameDrawCenter, Color.White, 0f, Vector2.Zero, scale);
        }

        public static void DrawIcon(SpriteBatch spriteBatch, Vector2 drawPositionTopLeft, Texture2D texture)
        {
            spriteBatch.Draw(texture, drawPositionTopLeft, null, Color.White, 0f, Vector2.Zero, Main.UIScale, SpriteEffects.None, 0f);
        }

        public static bool IsMouseOverUI(int TopLeftX, int TopLeftY, Texture2D texture, Vector2 backgroundScale)
        {
            Rectangle backgroundArea = new Rectangle(TopLeftX, TopLeftY, (int)(texture.Width * backgroundScale.X), (int)(texture.Height * backgroundScale.Y));
            return MouseScreenArea.Intersects(backgroundArea);
        }

        public static void DrawItemIcon(SpriteBatch spriteBatch, Vector2 itemSlotDrawPosition, Vector2 scale, Item item, Texture2D texture, int slotNumber)
        {
            Texture2D itemSlotTexture = texture;

            bool isHoveringOverItemIcon = MouseScreenArea.Intersects(new Rectangle((int)itemSlotDrawPosition.X, (int)itemSlotDrawPosition.Y, (int)(itemSlotTexture.Width * scale.X), (int)(itemSlotTexture.Height * scale.Y)));

            spriteBatch.Draw(itemSlotTexture, itemSlotDrawPosition, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

            if (!item.IsAir)
            {
                AttemptToDrawItemInIcon(spriteBatch, itemSlotDrawPosition, item, slotNumber);
                DrawItemStackCount(spriteBatch, itemSlotDrawPosition, scale, item);
            }

            if (isHoveringOverItemIcon)
                InteractWithItemSlot(slotNumber);
        }
        public static void DrawItemStackCount(SpriteBatch spriteBatch, Vector2 position, Vector2 scale, Item item)
        {
            if (item.stack > 1)
            {
                string stackCountText = item.stack.ToString();
                Vector2 textSize = FontAssets.ItemStack.Value.MeasureString(stackCountText) * scale * ItemScale;
                Vector2 textPosition = position + new Vector2(35f, 35f);

                ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.ItemStack.Value, stackCountText, textPosition, Color.White, 0f, Vector2.Zero, scale * 0.85f);
            }
        }
        public static void SubtractFromInput()
        {
            if (CurrentlyHeldItem3.IsAir)
                return;

            if (CurrentlyHeldItem.stack > 1)
            {
                CurrentlyHeldItem.stack -= 1;
            }
            else
            {
                CurrentlyHeldItem.TurnToAir();
            }
        }
        public static void AttemptToDrawItemInIcon(SpriteBatch spriteBatch, Vector2 drawPosition, Item item, int slotNumber)
        {
            float inventoryScale = Main.inventoryScale * 0.85f;
            Texture2D itemTexture = TextureAssets.Item[item.type].Value;
            Rectangle itemFrame = itemTexture.Frame(1, 1, 0, 0);
            bool hasMultipleFrames = Main.itemAnimations[item.type] != null;
            if (hasMultipleFrames)
                itemFrame = Main.itemAnimations[item.type].GetFrame(itemTexture);

            float baseScale = Main.UIScale;
            Color lightColor = Color.White;
            ItemSlot.GetItemLight(ref lightColor, ref baseScale, item, false);

            float itemScale = ItemScale;

            if (itemFrame.Width > 36 || itemFrame.Height > 36)
                itemScale = 36f / MathHelper.Max(itemFrame.Width, itemFrame.Height);

            itemScale *= inventoryScale * baseScale;
            drawPosition += Vector2.One * 15f * baseScale;
            drawPosition += itemPos;
            
            Color itemColor = Color.White;
            if (slotNumber == 3)
            {
                itemColor *= itemOpacity; 
            }

            spriteBatch.Draw(itemTexture, drawPosition, itemFrame, item.GetAlpha(itemColor), 0f, itemFrame.Size() * 0.5f, itemScale, SpriteEffects.None, 0f);
            spriteBatch.Draw(itemTexture, drawPosition, itemFrame, item.GetColor(itemColor), 0f, itemFrame.Size() * 0.5f, itemScale, SpriteEffects.None, 0f);
        }
        public static bool mouseItemIsKnife(Item item)
        {
            if (item.IsAir) return true;
            foreach (var i in knives)
            {
                if (i.knife.Name == item.Name)
                {
                    CurrentlyHeldItem3.TurnToAir();
                    return true;
                }
            }
            return false;
        }
        public static void InteractWithItemSlot(int slotNumber)
        {
            Item item = slotNumber switch
            {
                1 => CurrentlyHeldItem,
                2 => CurrentlyHeldItem2,
                3 => CurrentlyHeldItem3,
                _ => null
            };

            if (item == null) return;

            if (!item.IsAir)
            {
                Main.HoverItem = item.Clone();
                Main.instance.MouseTextHackZoom(string.Empty);
            }

            if (Main.mouseLeftRelease && Main.mouseLeft)
            {
                if (slotNumber == 1)
                {
                    CurrentlyHeldItem3.TurnToAir();
                }
                if (slotNumber == 3 && Main.mouseItem.netID == CurrentlyHeldItem3.netID)
                {
                    Main.mouseItem.stack += CurrentlyHeldItem3.stack; SubtractFromInput();
                    CurrentlyHeldItem3.TurnToAir(); 
                    return;
                }
                if (slotNumber == 3 && !Main.mouseItem.IsAir)  return; 
                if (slotNumber == 2 && !mouseItemIsKnife(Main.mouseItem)) return;


                Utils.Swap(ref Main.mouseItem, ref item);
                SoundEngine.PlaySound(SoundID.Grab);
            }
            if(Main.mouseRightRelease&&Main.mouseRight)
            {
                if (slotNumber == 1)
                {
                    if (Main.mouseItem.netID == CurrentlyHeldItem.netID) 
                    {
                        if (Main.mouseItem.stack != 9999)
                        {
                            Main.mouseItem.stack += 1;
                            CurrentlyHeldItem.stack -= 1;
                        }
                    } 
                }
            }

            switch (slotNumber)
            {
                case 1:
                    CurrentlyHeldItem = item;
                    break;
                case 2:
                    CurrentlyHeldItem2 = item;
                    break;
                case 3:
                    if (item.IsAir && !CurrentlyHeldItem3.IsAir)
                    {
                        SubtractFromInput();
                    }
                    CurrentlyHeldItem3 = item;
                    PreviousOutputItem = CurrentlyHeldItem3.Clone();
                    break;
            }
            if (CurrentlyHeldItem.IsAir || CurrentlyHeldItem2.IsAir)
            {
                CurrentlyHeldItem3.TurnToAir();
                PreviousOutputItem.TurnToAir();
            }
        }
    }
}
