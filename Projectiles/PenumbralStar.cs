using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles
{
	public class PenumbralStar : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Star");
		}

		public override void SetDefaults()
		{
			projectile.width = 50;
			projectile.height = 50;
			projectile.timeLeft = 300;
			projectile.penetrate = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.ranged = true;
		}

		public override void AI()
		{
			int num1 = Dust.NewDust(projectile.Center, 0, 0, 159, 0, 0, 0, default(Color), 0.6f);
			Main.dust[num1].velocity *= 0f;
			Lighting.AddLight(projectile.Center, 0.5f, 0.4f, 0.2f);
			projectile.alpha -= 255;
			projectile.rotation += 0.05f;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 2;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 16; i++)
			{
				int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 159, 0, 0, 0, default(Color), 0.6f);
			}
		}
	}
}
