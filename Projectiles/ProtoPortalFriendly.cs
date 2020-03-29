using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles
{
	public class ProtoPortalFriendly : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Portal");
		}

		float p2Rot;

		public override void SetDefaults()
		{
			projectile.width = 38;
			projectile.height = 38;
			projectile.timeLeft = 600;
			projectile.penetrate = 7;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.magic = true;
		}

		public override void AI()
		{
			projectile.rotation += 0.07f;
			p2Rot -= 0.08f;
			projectile.velocity *= 0.99f;

			Lighting.AddLight(projectile.Center, 0.5f, 0.05f, 0);

			if (Main.rand.Next(5) == 0)
			{
				int d = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 182, 0f, 0f, 100, default(Color), 0.8f);
				Main.dust[d].velocity *= 1.5f;
				Main.dust[d].noGravity = true;
			}
			if(projectile.timeLeft <= 60)
			{
				int d2 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 0, 0, 182, 0f, 0f, 100, default(Color), 0.8f);
				Main.dust[d2].velocity *= 3f;
				Main.dust[d2].noGravity = true;

				projectile.alpha += 5;
				projectile.scale -= 0.03f;
				if(projectile.scale <= 0)
				{
					projectile.scale = 0;
				}
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if(projectile.penetrate <= 2)
			{
				projectile.timeLeft = 30;
				projectile.damage = 0;
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D portal2 = Main.projectileTexture[projectile.type];
			Vector2 portalOrigin = new Vector2(portal2.Width * 0.5f, portal2.Height * 0.5f);
			Vector2 portalPos = projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY);
			Main.spriteBatch.Draw(portal2, portalPos, null, new Color(255, 255, 255, projectile.alpha + 150), p2Rot, portalOrigin, projectile.scale * 1.2f, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(portal2, portalPos, null, new Color(255, 255, 255, projectile.alpha + 150), projectile.rotation, portalOrigin, projectile.scale, SpriteEffects.None, 0f);

			Main.spriteBatch.Draw(portal2, portalPos, null, new Color(255, 255, 255, projectile.alpha + 70), p2Rot, portalOrigin, projectile.scale * 1.4f, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(portal2, portalPos, null, new Color(255, 255, 255, projectile.alpha + 70), projectile.rotation, portalOrigin, projectile.scale * 1.2f, SpriteEffects.None, 0f);
			return false;
		}
	}
}
