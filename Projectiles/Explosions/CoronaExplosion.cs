using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles.Explosions
{
	public class CoronaExplosion : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corona Explosion");
		}

		public override void SetDefaults()
		{
			projectile.width = 64;
			projectile.height = 64;
			projectile.timeLeft = 1;
			projectile.penetrate = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.ignoreWater = false;
			projectile.light = 0.6f;
		}

		public override void AI()
		{
			for (int i = 0; i < 16; i++)
			{
				int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 159, 0, 0, 0, default(Color), 2f);
				Main.dust[num1].noGravity = true;
			}
		}
	}
}
