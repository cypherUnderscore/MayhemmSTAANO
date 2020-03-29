using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles
{
	public class CrimsonFlareProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laser");
		}

		public override void SetDefaults()
		{
			projectile.width = 2;
			projectile.height = 2;
			projectile.timeLeft = 300;
			projectile.penetrate = -1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
		}

		public override void AI()
		{
			int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, 182, 0, 0, 0, default(Color), 1.2f);
			Main.dust[d].noGravity = true;
			Main.dust[d].position = projectile.Center;
		}
	}
}
