using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Dusts;

namespace MayhemmSTAANO.Projectiles
{
	public class RadiantCharmProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Star");
		}

		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.timeLeft = 300;
			projectile.penetrate = -1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.alpha = 230;
		}

		float drawRot = 0;
		float soundTimer = 20;

		public override void AI()
		{
			projectile.spriteDirection = projectile.direction;
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

			Lighting.AddLight(projectile.position, 0, 0, 0.4f);

			soundTimer--;
			if(soundTimer <= 0)
			{
				Main.PlaySound(2, projectile.position, 9);
				soundTimer = Main.rand.Next(15, 30);
			}

			drawRot += 0.1f;

			if (Main.rand.Next(3) == 0)
			{
				int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1.5f);
				Main.dust[d].noGravity = true;
			}
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 0.8f);
				Main.dust[d].noGravity = true;
			}
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor) //glowmask
		{
			Texture2D texture = Main.projectileTexture[projectile.type];
			spriteBatch.Draw
			(
				texture,
				new Vector2
			(
				projectile.position.X - Main.screenPosition.X + projectile.width * 0.5f,
				projectile.position.Y - Main.screenPosition.Y + projectile.height * 0.5f
			),
			new Rectangle(0, 0, texture.Width, texture.Height),
			new Color(200, 200, 200, 230),
			projectile.rotation,
			texture.Size() * 0.5f + new Vector2(0, -10),
			projectile.scale,
			SpriteEffects.None,
			0f
			);

			Texture2D trail = ModContent.GetTexture("MayhemmSTAANO/Projectiles/RadiantCharmProjStar");
			spriteBatch.Draw
			(
				trail,
				new Vector2
			(
				projectile.position.X - Main.screenPosition.X + projectile.width * 0.5f,
				projectile.position.Y - Main.screenPosition.Y + projectile.height * 0.5f
			),
			new Rectangle(0, 0, trail.Width, trail.Height),
			Color.White,
			drawRot,
			trail.Size() * 0.5f,
			projectile.scale,
			SpriteEffects.None,
			0f
			);
		}
	}
}
