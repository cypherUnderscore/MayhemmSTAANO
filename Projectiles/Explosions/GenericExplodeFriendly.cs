using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles.Explosions
{
	public class GenericExplodeFriendly : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Explosion");
		}

		public override void SetDefaults()
		{
			projectile.width = 96;
			projectile.height = 96;
			projectile.timeLeft = 1;
			projectile.penetrate = -1;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = false;
		}

		public override void AI()
		{
			for (int i = 0; i < 16; i++)
			{
				int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, (int)projectile.ai[0], 0, 0, 0, default(Color), 2f);
				Main.dust[num1].noGravity = true;
			}
		}
	}
}
