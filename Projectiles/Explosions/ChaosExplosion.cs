using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles.Explosions
{
	public class ChaosExplosion : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Explosion");
		}

		public override void SetDefaults()
		{
			projectile.width = 72;
			projectile.height = 72;
			projectile.timeLeft = 1;
			projectile.penetrate = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.ignoreWater = false;
		}

		public override void AI()
		{
			for (int i = 0; i < 24; i++)
			{
				int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 74, 0, 0, 0, default(Color), 2f);
				Main.dust[num1].noGravity = true;
			}
		}
	}
}

