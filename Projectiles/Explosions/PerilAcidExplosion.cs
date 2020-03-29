using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Dusts;
using MayhemmSTAANO.Buffs;

namespace MayhemmSTAANO.Projectiles.Explosions
{
	public class PerilAcidExplosion : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Explosion");
		}

		public override void SetDefaults()
		{
			projectile.width = 48;
			projectile.height = 48;
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
				int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<PerilAcidDust>(), 0, 0, 0, default(Color), 2f);
				Main.dust[num1].noGravity = true;
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
	}
}
