using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles
{
	public class MagmatanaProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magma Slash");
		}
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.timeLeft = 180;
			projectile.penetrate = 5;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.melee = true;
			projectile.alpha = 255;
			drawOffsetX = -8;
		}

		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			projectile.alpha -= 45;
			for (int i = 0; i < 3; i++)
			{
				int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1f);
				Main.dust[num1].velocity *= 0.2f;
				Main.dust[num1].noGravity = true;
			}
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 10; i++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1f);
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 60);
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 60);
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
			new Color(255, 255, 255, 230),
			projectile.rotation,
			texture.Size() * 0.5f + new Vector2(0, 0),
			projectile.scale,
			SpriteEffects.None,
			0f
			);
		}
	}
}
