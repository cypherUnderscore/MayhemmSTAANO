using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles.RevolverBullets //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
	public class RevolverNull : ModProjectile
	{
		public override void SetDefaults()
		{
			
			projectile.width = 4;
			projectile.height = 4;
			projectile.timeLeft = 90;
			projectile.penetrate = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.ranged = true;
		}

		public override void AI()
		{
			projectile.ai[0] += 1f;
			if(projectile.ai[0] >= 20)
			{
				projectile.velocity.Y = projectile.velocity.Y += 0.1f;
				projectile.velocity.X = projectile.velocity.X *= 0.98f;
			}
			projectile.rotation = projectile.rotation += 0.5f;
			if(Main.rand.Next(3) == 1)
			{
				int num2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 133, 0, 0, 0, default(Color), 1f);
				Main.dust[num2].velocity *= 0.6f;
			}
			if (projectile.velocity.Y >= 8f)
			{
				projectile.velocity.Y = 8f;
			}
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 4; i++)
			{
				int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 133, 0, 0, 0, default(Color), 1f);
				Main.dust[num1].velocity *= 0.8f;
			}
		}

	}
}