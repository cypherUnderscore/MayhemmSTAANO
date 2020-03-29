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
	public class PerilStaffProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Acid");
		}

		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.timeLeft = 150;
			projectile.penetrate = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.magic = true;
			projectile.alpha = 155;
		}

		public override void AI()
		{
			projectile.rotation += 0.1f;
			for (int i = 0; i < 2; i++)
			{
				int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<PerilAcidDust>(), 0, 0, 100, default(Color), 1.5f);
				Main.dust[d].velocity *= 0f;
				Main.dust[d].noGravity = true;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(ModContent.BuffType<PerilCorrosion>(), 300);
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			target.AddBuff(ModContent.BuffType<PerilCorrosion>(), 300);
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 8; i++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<PerilAcidDust>(), projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1f);
			}
		}
	}
}
