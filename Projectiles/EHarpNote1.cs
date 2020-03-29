using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Dusts;

namespace MayhemmSTAANO.Projectiles
{
	public class EHarpNote1 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Music Note");
		}

		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 8;
			projectile.timeLeft = 300;
			projectile.penetrate = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.magic = true;
			projectile.alpha = 155;
		}

		public override void AI()
		{
			projectile.spriteDirection = projectile.direction;
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

			Lighting.AddLight(projectile.position, 0, 0, 0.4f);

			projectile.velocity *= 1.03f;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<BlueTechDust>(), projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 0.8f);
				Main.dust[d].noGravity = true;
			}
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor) //glowmask
		{
			Texture2D texture = Main.projectileTexture[projectile.type];
			if (projectile.spriteDirection == 1)
			{
				spriteBatch.Draw
				(
					texture,
					new Vector2
				(
					projectile.position.X - Main.screenPosition.X + projectile.width * 0.5f,
					projectile.position.Y - Main.screenPosition.Y + projectile.height * 0.5f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				new Color(255, 255, 255, projectile.alpha),
				projectile.rotation,
				texture.Size() * 0.5f,
				projectile.scale,
				SpriteEffects.None,
				0f
				);
			}
			else
			{
				spriteBatch.Draw
				(
					texture,
					new Vector2
				(
					projectile.position.X - Main.screenPosition.X + projectile.width * 0.5f,
					projectile.position.Y - Main.screenPosition.Y + projectile.height * 0.5f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				new Color(255, 255, 255, projectile.alpha),
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
