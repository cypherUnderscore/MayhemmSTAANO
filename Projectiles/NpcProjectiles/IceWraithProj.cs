using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Dusts;
using MayhemmSTAANO.Buffs;

namespace MayhemmSTAANO.Projectiles.NpcProjectiles
{
	public class IceWraithProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Shard");
		}

		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.timeLeft = 300;
			projectile.penetrate = 1;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.extraUpdates = 1;
			projectile.alpha = 0;
		}

		public override void AI()
		{
			projectile.velocity.Y += 0.02f;
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			int d = Dust.NewDust(projectile.Center, 0, 0, ModContent.DustType<StyxIceDust>(), 0, 0, 155, default(Color), 0.6f);
			Main.dust[d].velocity *= 0f;
			Main.dust[d].noGravity = true;
			Main.dust[d].position = projectile.Center;
		}

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(ModContent.BuffType<Dissolving>(), 90);
		}

		public override void Kill(int timeLeft)
		{
			for(int d = 0; d < 16; d++)
			{
				Dust.NewDust(projectile.Center, projectile.width, projectile.height, ModContent.DustType<StyxIceDust>(), 0, 0, 155, default(Color), 0.6f);
			}
			Main.PlaySound(2, projectile.position, 27);
		}
	}
}
