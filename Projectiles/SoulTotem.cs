using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Dusts;

namespace MayhemmSTAANO.Projectiles
{
	public class SoulTotem : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Totem");
		}

		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 30;
			projectile.timeLeft = 900;
			projectile.penetrate = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.ignoreWater = false;
		}

		int shootTimer = 30;
		float drawRot = 0;
		float drawDist = 4;
		int time = 0;
		bool flag1 = true;
		bool flag2 = false;

		public override void AI()
		{
			shootTimer--;
			if (shootTimer <= 0)
			{
				for (int s = 0; s < 3; s++)
				{
					Projectile.NewProjectile(new Vector2(projectile.position.X + (projectile.width * 0.5f), projectile.position.Y), new Vector2(Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, -8)), ModContent.ProjectileType<SoulOrb>(), projectile.damage / 4, 0, projectile.owner);
				}
				shootTimer = Main.rand.Next(20, 35);
			}
			if(projectile.timeLeft < 30)
			{
				projectile.alpha -= 2;
				if(drawDist > 0)
				{
					drawDist -= 0.11f;
				}
			}
			if (flag1)
			{
				time++;
			}
			else
			{
				time--;
			}
			if(time >= 40)
			{
				flag1 = false;
			}
			else if(time <= 0)
			{
				flag1 = true;
				if (flag2)
				{
					flag2 = false;
				}
				else if (!flag2)
				{
					flag2 = true;
				}
			}
			if (flag2)
			{
				projectile.position.Y += 0.02f * time;
			}
			else
			{
				projectile.position.Y -= 0.02f * time;
			}
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor) //glowmask
		{
			Texture2D texture = Main.projectileTexture[projectile.type];
			for (int d = 0; d < 4; d++)
			{
				spriteBatch.Draw
				(
					texture,
					new Vector2
					(
						projectile.position.X - Main.screenPosition.X + projectile.width * 0.5f,
						projectile.position.Y - Main.screenPosition.Y + projectile.height * 0.5f
					) + new Vector2(drawDist, drawDist).RotatedBy((1.57 * d) + drawRot),
					new Rectangle(0, 0, texture.Width, texture.Height),
					new Color(50, 50, 50, 0),
					projectile.rotation,
					texture.Size() * 0.5f,
					projectile.scale,
					SpriteEffects.None,
					0f
				);
			}
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					projectile.position.X - Main.screenPosition.X + projectile.width * 0.5f,
					projectile.position.Y - Main.screenPosition.Y + projectile.height * 0.5f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				new Color(245, 245, 245, 210),
				projectile.rotation,
				texture.Size() * 0.5f,
				projectile.scale,
				SpriteEffects.None,
				0f
			);
			drawRot += 0.02f;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 24; i++)
			{
				int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<SoulDust>(), 0, 0, 0, default(Color), 1f);
				Main.dust[num1].noGravity = true;
				Main.dust[num1].velocity *= 0;
			}
		}
	}
}
