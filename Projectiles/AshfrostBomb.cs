using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Dusts;
using MayhemmSTAANO.Buffs;

namespace MayhemmSTAANO.Projectiles
{
	public class AshfrostBomb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("AshfrostBomb");
		}

		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.timeLeft = 90;
			projectile.penetrate = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.melee = true;
		}

		float rotVel = 0;

		public override void AI()
		{
			rotVel += 0.01f;
			projectile.rotation += rotVel;

			if(projectile.timeLeft <= 30)
			{
				projectile.alpha += 15;
			}

			int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<StyxIceDust>(), 0, 0, 0, default(Color), 0.6f);
			Main.dust[d].noGravity = true;
			Main.dust[d].velocity *= 0;
			Main.dust[d].alpha = projectile.alpha;
			Main.dust[d].position = projectile.Center;

			projectile.velocity *= 0.97f;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(ModContent.BuffType<Dissolving>(), 120);
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			target.AddBuff(ModContent.BuffType<Dissolving>(), 120);
		}
	}
}
