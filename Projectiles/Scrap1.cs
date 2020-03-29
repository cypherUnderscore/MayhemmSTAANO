using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles
{
	public class Scrap1 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scrap");
		}

		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.timeLeft = 300;
			projectile.penetrate = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.melee = true;
		}

		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			projectile.velocity.Y += 0.1f;

			if (Main.rand.Next(5) == 0)
			{
				int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, 182, 0, 0, 0, default(Color), 0.8f);
				Main.dust[d].velocity *= 0;
				Main.dust[d].noGravity = true;
			}
		}

		public override void Kill(int timeLeft)
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

			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("GenericExplodeFriendly"), projectile.damage, 0, 0, 182f, 0f);
			Main.PlaySound(SoundID.Item14, projectile.position);
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor) //glowmask
		{
			Texture2D texture = mod.GetTexture("Projectiles/Scrap1_glow");
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
	}
}
