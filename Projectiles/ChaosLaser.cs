using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles
{
	public class ChaosLaser : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laser");
		}

		public int shootTimer = 20;

		public override void SetDefaults()
		{
			projectile.width = 12;
			projectile.height = 12;
			projectile.timeLeft = 180;
			projectile.penetrate = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.ranged = true;
			projectile.extraUpdates = 5;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 8;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			projectile.alpha = 255;
		}

		public override void AI()
		{
			shootTimer -= 1;
			projectile.alpha -= 75;
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			Lighting.AddLight(projectile.Center, 0.3f, 0.4f, 0.2f);
			if (shootTimer <= 0)
			{
				shootTimer = 20;
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, Main.rand.NextFloat() * 6 - 3, Main.rand.NextFloat() * 6 - 3, mod.ProjectileType("ChaosMine"), projectile.damage / 3, 0f, projectile.owner);
			}
			//int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 74, 0, 0, 0, default(Color), 0.8f);
			//Main.dust[num1].velocity *= 0f;
			//Main.dust[num1].noGravity = true;
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

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 1;
		}
	}
}
