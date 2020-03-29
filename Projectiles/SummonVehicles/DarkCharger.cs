using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles.SummonVehicles
{
	public class DarkCharger : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Car");
			Main.projFrames[projectile.type] = 2;
		}

		public override void SetDefaults()
		{
			projectile.width = 26;
			projectile.height = 26;
			projectile.timeLeft = 300;
			projectile.penetrate = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.ranged = true;
			drawOffsetX = -13;
		}
		

		public override void AI()
		{
			if(projectile.velocity.X >= 0)
			{
				projectile.rotation = projectile.velocity.Y / 25;
			}
			else
			{
				projectile.rotation = -projectile.velocity.Y / 25;
			}
			projectile.spriteDirection = projectile.direction;
			projectile.velocity.Y += 0.2f;

			if (++projectile.frameCounter >= 3)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= Main.projFrames[projectile.type])
				{
					projectile.frame = 0;
				}
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if(projectile.velocity.X != projectile.oldVelocity.X)
			{
				projectile.velocity.X = -projectile.velocity.X;
				Main.PlaySound(SoundID.Item10, projectile.position);
			}
			if(projectile.velocity.X >= 0)
			{
				projectile.velocity.X = 10f;
			}
			else
			{
				projectile.velocity.X = -10f;
			}
			return false;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 4; i++)
			{
				int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 182, 0, 0, 0, default(Color), 1f);
				Main.dust[num1].velocity *= 0.8f;
			}
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("GenericExplodeFriendly"), projectile.damage, projectile.knockBack, projectile.owner, 182);
			Main.PlaySound(SoundID.Item14, projectile.position);

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
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor) //glowmask
		{
			if (projectile.velocity.X >= 0)
			{
				Texture2D texture = mod.GetTexture("Projectiles/SummonVehicles/DarkCharger_glow");
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
					projectile.scale,
					SpriteEffects.None,
					0f
				);
			}
			else
			{
				Texture2D texture = mod.GetTexture("Projectiles/SummonVehicles/DarkCharger_glow");
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
					projectile.scale,
					SpriteEffects.FlipHorizontally,
					0f
				);
			}
		}
	}
}