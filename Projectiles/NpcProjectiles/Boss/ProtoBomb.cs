using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles.NpcProjectiles.Boss
{
	public class ProtoBomb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bomb");
		}

		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.timeLeft = 600;
			projectile.penetrate = 1;
			projectile.hostile = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.aiStyle = 2;
		}

		public override void AI()
		{
			Lighting.AddLight(projectile.position, 0.5f, 0.05f, 0);
			projectile.alpha -= 255;
			if (Main.rand.Next(10) == 0)
			{
				int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, 182, 0, 0, 0, default(Color), 1.2f);
				Main.dust[d].velocity *= 0f;
				Main.dust[d].noGravity = true;
				Main.dust[d].position = projectile.Center;
			}
		}

		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("GenericExplodeEnemy"), projectile.damage, 0, 0, 182f, 0f);
			Main.PlaySound(SoundID.Item14, projectile.position);
		}
	}
}
