using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles.RevolverBullets
{
	public class PenumbraClipProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.timeLeft = 240;
			projectile.penetrate = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.ranged = true;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
		}

		public override void AI()
		{
			projectile.ai[0] += 1f;
			if(projectile.ai[0] >= 20)
			{
				projectile.velocity.Y = projectile.velocity.Y += 0.1f;
				projectile.velocity.X *= 0.993f;
			}
			projectile.rotation += projectile.velocity.X * 0.03f;
			if (projectile.velocity.Y >= 8f)
			{
				projectile.velocity.Y = 8f;
			}
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item14, projectile.position);
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("CoronaExplosion"), projectile.damage, 0f, 0);
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