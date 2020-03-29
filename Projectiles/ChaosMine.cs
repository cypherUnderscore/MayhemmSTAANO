using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles
{
	public class ChaosMine : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bomb");
		}

		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.timeLeft = 300;
			projectile.penetrate = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.ranged = true;
			projectile.extraUpdates = 1;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 8;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			projectile.alpha = 255;
		}

		public override void AI()
		{
			projectile.alpha -= 15;
			projectile.rotation += 0.1f * projectile.velocity.X / 4;
			projectile.velocity *= 0.98f;
			Lighting.AddLight(projectile.Center, 0.3f, 0.4f, 0.2f);
			//int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 74, 0, 0, 0, default(Color), 0.8f);
			//Main.dust[num1].velocity *= 0f;
			//Main.dust[num1].noGravity = true;

			float centerY = projectile.Center.X; //SORRY EA
			float centerX = projectile.Center.Y;
			float num = 400f;
			bool chase = false;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].CanBeChasedBy(projectile, false) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[i].Center, 1, 1))
				{
					float distanceToX = Main.npc[i].position.X + (float)(Main.npc[i].width / 2);
					float distanceToY = Main.npc[i].position.Y + (float)(Main.npc[i].height / 2);
					float num3 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - distanceToX) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - distanceToY);

					if (num3 < num + 200)
					{
						num = num3;
						centerY = distanceToX;
						centerX = distanceToY;
						chase = true;
					}
				}
			}
			if (chase)
			{
				float speed = 5f;
				Vector2 vector35 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
				float num4 = centerY - vector35.X;
				float num5 = centerX - vector35.Y;
				float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
				num6 = speed / num6;
				num4 *= num6;
				num5 *= num6;
				projectile.velocity.X = (projectile.velocity.X * 20f + num4) / 21f;
				projectile.velocity.Y = (projectile.velocity.Y * 20f + num5) / 21f;
				return;
			}
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item62, projectile.position);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("ChaosExplosion"), projectile.damage, 0f, 0);
		}

		public override bool PreDraw(SpriteBatch sb, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				sb.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
	}
}
