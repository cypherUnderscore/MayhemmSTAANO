using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles
{
	public class FrostFlareProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frostburn");
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.timeLeft = 300;
			projectile.penetrate = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.magic = true;
			projectile.light = 0.6f;
			projectile.alpha = 255;
			drawOriginOffsetY = -12;
		}

		public override void AI()
		{
			projectile.alpha -= 15;

			if (++projectile.frameCounter >= 5)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= Main.projFrames[projectile.type])
				{
					projectile.frame = 0;
				}
			}

			if(Main.rand.Next(4) == 0)
			{
				int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, 20, 0, 0, 0, default(Color), 0.8f);
				Main.dust[d].velocity *= 0;
			}
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 8; i++)
			{
				int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, 20, 0, 0, 0, default(Color), 1.2f);
				Main.dust[d].velocity *= 0;
			}
		}
	}
}
