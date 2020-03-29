using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Dusts;
using MayhemmSTAANO.Buffs;

namespace MayhemmSTAANO.Projectiles
{
	public class JaredSwordProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jetblade");
		}

		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 22;
			projectile.timeLeft = 600;
			projectile.penetrate = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.melee = true;
			projectile.alpha = 155;
			drawOffsetX = 4;
		}

		int time = 0;
		int time2 = 0;

		float rotVel = 0;

		bool bool1 = false;
		bool bool2 = false;

		public override void AI()
		{
			if(time >= 120)
			{
				projectile.velocity.Y = 8;
				projectile.velocity.X = 0;
				projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
				bool1 = true;

				projectile.height = 4;

				drawOriginOffsetY = -8;
			}
			else
			{
				rotVel += 0.005f;
				projectile.rotation += rotVel;

				time++;

				projectile.velocity *= 0.98f;
			}

			if (bool2)
			{
				time2++;
				if(time2 >= 60)
				{
					projectile.Kill();
				}
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (bool1)
			{
				bool2 = true;
				projectile.velocity *= 0;
				return false;
			}
			else
			{
				return true;
			}
		}

		public override void Kill(int timeLeft)
		{
			if (bool2)
			{
				int g = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[g].velocity *= 0.4f;
				Gore gore85 = Main.gore[g];
				gore85.velocity.X = gore85.velocity.X + 1f;
				Gore gore86 = Main.gore[g];
				gore86.velocity.Y = gore86.velocity.Y + 1f;
				g = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[g].velocity *= 0.4f;
				Gore gore87 = Main.gore[g];
				gore87.velocity.X = gore87.velocity.X - 1f;
				Gore gore88 = Main.gore[g];
				gore88.velocity.Y = gore88.velocity.Y + 1f;
				g = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[g].velocity *= 0.4f;
				Gore gore89 = Main.gore[g];
				gore89.velocity.X = gore89.velocity.X + 1f;
				Gore gore90 = Main.gore[g];
				gore90.velocity.Y = gore90.velocity.Y - 1f;
				g = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[g].velocity *= 0.4f;
				Gore gore91 = Main.gore[g];
				gore91.velocity.X = gore91.velocity.X - 1f;
				Gore gore92 = Main.gore[g];
				gore92.velocity.Y = gore92.velocity.Y - 1f;

				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("GenericExplodeFriendly"), projectile.damage, 0, 0, 229, 0f);
				Main.PlaySound(SoundID.Item14, projectile.position);
			}
			else
			{
				for (int i = 0; i < 16; i++)
				{
					int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, 229, 0, 0, 0, default(Color), 1f);
					Main.dust[d].noGravity = true;
				}
			}
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor) //glowmask
		{
			Texture2D texture = mod.GetTexture("Projectiles/JaredSwordProj");
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					projectile.position.X - Main.screenPosition.X + projectile.width * 0.5f,
					projectile.position.Y - Main.screenPosition.Y + projectile.height * 0.5f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				projectile.rotation,
				texture.Size() * 0.5f,
				projectile.scale * 1.2f,
				SpriteEffects.None,
				0f
			);
		}
	}
}
