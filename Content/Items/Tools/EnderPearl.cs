using Microsoft.Build.ObjectModelRemoting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI.Chat;

namespace WaasephisFishingPlus.Content.Items.Tools
{
	public class EnderPearl : ModItem
	{
		public override bool PreDrawTooltipLine(DrawableTooltipLine line, ref int yOffset)
		{
			if (line.Name == "ItemName")
			{
				Color outer = EnderPearlProjectile.C1 * 0.6f;
				Color inner = Color.Lerp(EnderPearlProjectile.C2, Color.Black, 0.5f);
				TextSnippet[] snippets = ChatManager.ParseMessage(line.Text, inner).ToArray();
				ChatManager.ConvertNormalSnippets(snippets);
				for (int i = 0; i < 16; ++i)
				{
					Vector2 circular = new Vector2(5, 0).RotatedBy(MathHelper.ToRadians(i / 16f * 360 + Main.GameUpdateCount));
					ChatManager.DrawColorCodedStringShadow(Main.spriteBatch, line.Font, line.Text, new Vector2(line.X, line.Y) + circular, outer * 0.08f, line.Rotation, line.Origin, line.BaseScale, line.MaxWidth, line.Spread);
				}
				ChatManager.DrawColorCodedStringShadow(Main.spriteBatch, line.Font, line.Text, new Vector2(line.X, line.Y), outer, line.Rotation, line.Origin, line.BaseScale, line.MaxWidth, line.Spread);
				ChatManager.DrawColorCodedString(Main.spriteBatch, line.Font, snippets, new Vector2(line.X, line.Y), inner, line.Rotation, line.Origin, line.BaseScale, out _, line.MaxWidth);
			}
			else
			{
				Color inner = EnderPearlProjectile.C1 * 0.8f;
				Color outer = Color.Lerp(EnderPearlProjectile.C2, Color.Black, 0.6f);
				TextSnippet[] snippets = ChatManager.ParseMessage(line.Text, inner).ToArray();
				ChatManager.ConvertNormalSnippets(snippets);
				ChatManager.DrawColorCodedStringShadow(Main.spriteBatch, line.Font, line.Text, new Vector2(line.X, line.Y), outer, line.Rotation, line.Origin, line.BaseScale, line.MaxWidth, line.Spread);
				ChatManager.DrawColorCodedString(Main.spriteBatch, line.Font, snippets, new Vector2(line.X, line.Y), inner, line.Rotation, line.Origin, line.BaseScale, out _, line.MaxWidth);
			}
			return false;
		}
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 22;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.sellPrice(silver: 20);
            Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.maxStack = 16;
			Item.consumable = true;
		}
		public override void HoldItem(Player player)
		{
			if(!player.ItemAnimationActive || player.ItemAnimationEndingOrEnded)
				UpdatePearl(player, false);
		}
		public override bool? UseItem(Player player)
		{
			UpdatePearl(player, true);
			return true;
		}
		public bool UpdatePearl(Player player, bool use = false, bool skip = false)
		{
			int type = ModContent.ProjectileType<EnderPearlProjectile>();
			Projectile pearl = null;
			for (int i = 0; i < Main.projectile.Length; ++i)
			{
				Projectile p = Main.projectile[i];
				if (p.active && p.type == type && p.owner == player.whoAmI )
				{
					pearl = p;
					break;
				}
			}
			if(!skip)
			{
				if (Main.myPlayer == player.whoAmI)
				{
					if (!use)
						pearl ??= Projectile.NewProjectileDirect(player.GetSource_ItemUse(Item), player.Center, Vector2.Zero, type, 0, 0, Main.myPlayer, -1);
					else if (pearl != null && pearl.ai[0] == -1 && player.ItemAnimationJustStarted)
					{
						pearl.ai[0] = 0;
						pearl.netUpdate = true;
						return true;
					}
				}
			}
			return pearl == null || pearl.ai[0] == -1;
		}
		public override bool CanUseItem(Player player)
		{
			return UpdatePearl(player, false, true);
		}
		public override bool ConsumeItem(Player player)
		{
			return true;
		}
	}
	public class EnderPearlProjectile : ModProjectile
	{
		public static readonly Color C1 = new(44, 205, 177, 0);
		public static readonly Color C2 = new(6, 57, 49);
		private float Timer = 0;
		public Vector2 MousePosition
		{
			get
			{
				return new Vector2(Projectile.ai[1], Projectile.ai[2]);
			}
			set
			{
				Projectile.ai[1] = value.X;
				Projectile.ai[2] = value.Y;
			}
		}
		public override string Texture => "WaasephisFishingPlus/Content/Items/Tools/EnderPearl";
		public override void SetStaticDefaults()
		{

		}
		public override void SetDefaults()
		{
			Projectile.width = Projectile.height = 22;
			Projectile.friendly = Projectile.hostile = false;
			Projectile.tileCollide = false;
			Projectile.timeLeft = 620;
			Projectile.ignoreWater = true;
		}
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
		{
			width = 12;
			height = 12;
			return base.TileCollideStyle(ref width, ref height, ref fallThrough, ref hitboxCenterFrac);
		}
		public List<Vector2> Path;
		public List<Vector2> PredictMovementPath()
		{
			List<Vector2> path = new();
			Vector2 pos = Projectile.Center;
			Vector2 velo = Projectile.velocity;
			path.Add(pos + velo);
			for (int i = 0; i < 120; ++i)
			{
				velo.Y += 0.1f;
				if (Collision.WetCollision(pos - new Vector2(6, 6), 12, 12))
					pos += velo * 0.5f;
				else
					pos += velo;
				path.Add(pos);
				if (Collision.TileCollision(pos - new Vector2(6, 6), velo, 12, 12, true, true, 1) != velo)
				{
					break;
				}
			}
			return path;
		}
		private static Texture2D pixel;
		public override bool PreDraw(ref Color lightColor)
		{
			if (pixel == null)
			{
				pixel = new Texture2D(Main.graphics.GraphicsDevice, 2, 2);
				pixel.SetData([Color.White, Color.White, Color.White, Color.White]);
			}
			Player player = Main.player[Projectile.owner];
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Vector2 drawOrigin = texture.Size() / 2;

			Color c = C1 * 1.5f;
			Color c2 = C2 * 1.25f;

			Vector2 drawPos = Projectile.Center;
			if (Projectile.ai[0] <= 0)
				drawPos.Y += player.gfxOffY;
			for (int i = 0; i < 12; ++i)
			{
				Vector2 circular = new Vector2(2, 0).RotatedBy(i / 12f * MathHelper.TwoPi + MathHelper.ToRadians(Timer * 3));
				Main.spriteBatch.Draw(texture, drawPos + circular - Main.screenPosition, null, c, Projectile.rotation, drawOrigin, Projectile.scale * 0.75f, Projectile.spriteDirection != 1 ? SpriteEffects.FlipVertically : SpriteEffects.None, 0f);
			}

			int startingPoint = 0;
			if (Projectile.ai[0] <= 0 || Path == null)
				Path = PredictMovementPath();
			int max = Math.Clamp(Path.Count, 0, 120);
			if (Projectile.ai[0] > 0)
				startingPoint = Math.Clamp(360 - Projectile.timeLeft, 0, max);
			Vector2 prev = Projectile.ai[0] <= 0 || Path == null || Path.Count <= startingPoint ? Projectile.Center : Path[startingPoint];
			for(int i = startingPoint + 1; i < max; ++i)
			{
				Vector2 toPrev = prev - Path[i];

				float interval = 0.2f;
				for(float j = 0; j < 1; j += interval)
				{
					float percent = (i - j) / (max - 1);
					float iPer = 1 - percent;
					float sin = 1.0f + 0.6f * MathF.Sin(MathHelper.ToRadians((i - j) * 90 + (Timer + j) * -6));
					float sizeY = 1 + sin - percent;
					Vector2 pos = Vector2.Lerp(Path[i], prev, j);
					if (Projectile.ai[0] <= 0)
							pos.Y += player.gfxOffY;
					Main.spriteBatch.Draw(pixel, pos - Main.screenPosition, null, c * iPer, toPrev.ToRotation(), new Vector2(0, 1), new Vector2(toPrev.Length() / 2f * interval, sizeY + 1.25f), Projectile.spriteDirection != 1 ? SpriteEffects.FlipVertically : SpriteEffects.None, 0f);
					Main.spriteBatch.Draw(pixel, pos - Main.screenPosition, null, c2 * (1 - percent * percent), toPrev.ToRotation(), new Vector2(0, 1), new Vector2(toPrev.Length() / 2f * interval, sizeY), Projectile.spriteDirection != 1 ? SpriteEffects.FlipVertically : SpriteEffects.None, 0f);
				}
				prev = Path[i];
			}
			Main.spriteBatch.Draw(texture, drawPos - Main.screenPosition, null, lightColor, Projectile.rotation, drawOrigin, Projectile.scale * 0.75f, Projectile.spriteDirection != 1 ? SpriteEffects.FlipVertically : SpriteEffects.None, 0f);
			return false;
		}
		public Vector2 findVelocityNeededToLandAtMouse()
		{
			Vector2 initial = Projectile.Center;
			Vector2 final = MousePosition;
			Vector2 toFinal = final - initial;

			float maxDistance = 1000f;
			float time = 120;
			float distance = toFinal.Length();

			if(distance > maxDistance)
			{
				distance = maxDistance;
				final = initial + toFinal.SafeNormalize(Vector2.Zero) * distance;
			}

			time = MathF.Min(distance * time / maxDistance, time);


			float gravity = 0.1f;
			Vector2 finalV = new Vector2(
				(final.X - initial.X) / time,
				(final.Y - initial.Y - 0.5f * gravity * time * time) / time
				);
			return finalV;
		}
		public override void AI()
		{
			++Timer;
			Player player = Main.player[Projectile.owner];
			if (Projectile.ai[0] <= 0)
			{
				if (player.HeldItem.type == ModContent.ItemType<EnderPearl>())
				{
					Projectile.hide = true;
					Projectile.timeLeft = 360;
					player.heldProj = Projectile.whoAmI;

					if(player.whoAmI == Main.myPlayer)
					{
						if(MousePosition != Main.MouseWorld)
						{
							MousePosition = Main.MouseWorld;
							Projectile.netUpdate = true;
						}
					}

					Vector2 toMouse = MousePosition - player.Center;
					player.ChangeDir(Math.Sign(toMouse.X));
					Vector2 norm = toMouse.SafeNormalize(Vector2.Zero);
					Projectile.velocity = findVelocityNeededToLandAtMouse();
					norm.Y -= 0.5f;
					norm = norm.SafeNormalize(Vector2.Zero);
					norm.X *= 0.5f;
					Projectile.rotation = norm.ToRotation() + MathHelper.ToRadians(player.direction * player.gravDir * -1);

					Vector2 offset = new Vector2(12, -6 * player.direction).RotatedBy(Projectile.rotation);
					offset.X *= 0.5f;
					Projectile.Center = offset + player.Center + new Vector2(0, -2);

					Projectile.spriteDirection = player.direction;

					player.heldProj = Projectile.whoAmI;
					player.SetCompositeArmBack(true, Player.CompositeArmStretchAmount.Full, 0f);
					player.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, MathHelper.WrapAngle(player.gravDir * Projectile.rotation + MathHelper.ToRadians(-90)));

					if (!Main.rand.NextBool(3))
					{
						Dust dust = Dust.NewDustDirect(Projectile.Center - Projectile.velocity - new Vector2(12, 12), 16, 16, DustID.RainbowMk2);
						dust.scale = dust.scale * 0.3f + 0.9f;
						dust.fadeIn = 0.1f;
						dust.color = Color.Lerp(C1, C2, Main.rand.NextFloat()) * 0.6f;
						dust.noGravity = true;
						dust.velocity *= 0.5f;
						dust.velocity -= Projectile.velocity * 0.3f;
					}
				}
				else
				{
					Projectile.Kill();
				}
				if (Projectile.ai[0] == 0)
				{
					Projectile.timeLeft = 360;
					Projectile.ai[0] = 1;
					if (player.whoAmI == Main.myPlayer)
						Projectile.netUpdate = true;
				}
			}
			else
			{
				if (Projectile.ai[0] == 1 || !Projectile.tileCollide)
				{
					Projectile.ai[0] = 2;
					Projectile.tileCollide = true;
					Path = PredictMovementPath();
					float r = Projectile.velocity.ToRotation();
					for (int i = 0; i < 30; ++i)
					{
						Vector2 circular = new Vector2(4, 0).RotatedBy(i / 30f * MathHelper.TwoPi);
						circular.X *= 0.4f;
						circular = circular.RotatedBy(r);
						Dust dust = Dust.NewDustDirect(Projectile.Center - new Vector2(5, 5), 0, 0, DustID.RainbowMk2);
						dust.scale += 0.5f;
						dust.fadeIn = 0.2f;
						dust.color = C1;
						dust.noGravity = true;
						dust.velocity *= 0.1f;
						dust.velocity += Projectile.velocity + circular;
					}
					SoundEngine.PlaySound(SoundID.Item67.WithPitchOffset(0.8f).WithVolumeScale(0.7f), Projectile.Center);
				}
				Projectile.hide = false;
				Projectile.velocity.Y += 0.1f;
				Projectile.rotation += Projectile.velocity.X * 0.01f;
				for (float j = 0; j < 1.0f; j += 0.25f)
				{
					Dust dust = Dust.NewDustDirect(Projectile.Center - Projectile.velocity * (1 - j) - new Vector2(5, 5), 0, 0, DustID.RainbowMk2);
					dust.scale = dust.scale * 0.1f + 0.7f;
					dust.fadeIn = 0.1f;
					dust.color = C1 * 0.4f;
					dust.noGravity = true;
					dust.velocity *= 0.05f;
					dust.velocity -= Projectile.velocity * 0.25f;

					for(int i = 0; i < 3; i++)
					{
						Vector2 circular = new Vector2(1, 0).RotatedBy(MathHelper.ToRadians((Timer + j) * 12 * Projectile.direction + i * 120));
						dust = Dust.NewDustDirect(Projectile.Center - Projectile.velocity * (1 - j) - new Vector2(5, 5), 0, 0, DustID.RainbowMk2);
						dust.scale = 0.7f;
						dust.fadeIn = 0.05f;
						dust.color = C1 * 0.36f;
						dust.noGravity = true;
						dust.velocity *= 0.01f;
						dust.velocity += circular * 4.5f;
						dust.velocity += Projectile.velocity * 0.25f;
					}
				}

				if (Collision.WetCollision(Projectile.Center - new Vector2(6, 6), 12, 12))
					Projectile.Center -= Projectile.velocity * 0.5f;
			}
		}
		public override void OnKill(int timeLeft)
		{
			if (Projectile.ai[0] <= 0)
				return;
			Player player = Main.player[Projectile.owner];
			Vector2 p = Projectile.Center + new Vector2(0, Projectile.height * 0.5f - player.height * 0.5f);
			Color c2 = C2;
			c2.A = 0;
			for (int i = 0; i < 48; ++i)
			{
				float percent = i / 48f;
				float sin = 0.5f + 0.5f * MathF.Sin(percent * MathF.PI * 4);
				Vector2 circular = new Vector2(4, 0).RotatedBy(percent * MathHelper.TwoPi);
				Dust dust = Dust.NewDustDirect(p - new Vector2(5, 5), 0, 0, DustID.RainbowMk2);
				dust.scale += 0.5f;
				dust.fadeIn = 0.2f;
				dust.color = Color.Lerp(C1, c2, sin);
				dust.noGravity = true;
				dust.velocity *= 0.1f;
				dust.velocity += circular;
			}
			SoundEngine.PlaySound(SoundID.Item67.WithPitchOffset(-0.3f).WithVolumeScale(0.7f), Projectile.Center);
		}
		public override bool ShouldUpdatePosition()
		{
			return Projectile.ai[0] > 1;
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Player player = Main.player[Projectile.owner];
			Vector2 pos = Projectile.Center + new Vector2(0, Projectile.height * 0.5f - player.height);
			player.Teleport(pos, TeleportationStyleID.DebugTeleport, 0);
			if (Main.myPlayer == Projectile.owner)
				NetMessage.SendData(MessageID.TeleportEntity, -1, -1, null, 0, Projectile.owner, pos.X, pos.Y, TeleportationStyleID.DebugTeleport, 0, 0);
			return base.OnTileCollide(oldVelocity);
		}
	}
}