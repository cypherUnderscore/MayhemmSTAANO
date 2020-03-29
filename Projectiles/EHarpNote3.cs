using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Dusts;
using MayhemmSTAANO.Projectiles.Explosions;

namespace MayhemmSTAANO.Projectiles
{
	public class EHarpNote3 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Music Note");
		}

		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 18;
			projectile.timeLeft = 300;
			projectile.penetrate = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.extraUpdates = 1;
			projectile.magic = true;
			projectile.alpha = 155;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 12;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void AI()
		{
			projectile.spriteDirection = projectile.direction;
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

			Lighting.AddLight(projectile.position, 0, 0, 0.4f);

			#region homing ai code
			float num132 = (float)Math.Sqrt((double)(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y)); //not my code, used a tutorial on the tmodloader forums
			float num133 = projectile.localAI[0];
			if (num133 == 0f)
			{
				projectile.localAI[0] = num132;
				num133 = num132;
			}
			float num134 = projectile.position.X;
			float num135 = projectile.position.Y;
			float num136 = 300f;
			bool flag3 = false;
			int num137 = 0;
			if (projectile.ai[1] == 0f)
			{
				for (int num138 = 0; num138 < 200; num138++)
				{
					if (Main.npc[num138].CanBeChasedBy(this, false) && (projectile.ai[1] == 0f || projectile.ai[1] == (float)(num138 + 1)))
					{
						float num139 = Main.npc[num138].position.X + (float)(Main.npc[num138].width / 2);
						float num140 = Main.npc[num138].position.Y + (float)(Main.npc[num138].height / 2);
						float num141 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num139) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num140);
						if (num141 < num136 && Collision.CanHit(new Vector2(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2)), 1, 1, Main.npc[num138].position, Main.npc[num138].width, Main.npc[num138].height))
						{
							num136 = num141;
							num134 = num139;
							num135 = num140;
							flag3 = true;
							num137 = num138;
						}
					}
				}
				if (flag3)
				{
					projectile.ai[1] = (float)(num137 + 1);
				}
				flag3 = false;
			}
			if (projectile.ai[1] > 0f)
			{
				int num142 = (int)(projectile.ai[1] - 1f);
				if (Main.npc[num142].active && Main.npc[num142].CanBeChasedBy(this, true) && !Main.npc[num142].dontTakeDamage)
				{
					float num143 = Main.npc[num142].position.X + (float)(Main.npc[num142].width / 2);
					float num144 = Main.npc[num142].position.Y + (float)(Main.npc[num142].height / 2);
					if (Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num143) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num144) < 1000f)
					{
						flag3 = true;
						num134 = Main.npc[num142].position.X + (float)(Main.npc[num142].width / 2);
						num135 = Main.npc[num142].position.Y + (float)(Main.npc[num142].height / 2);
					}
				}
				else
				{
					projectile.ai[1] = 0f;
				}
			}
			if (!projectile.friendly)
			{
				flag3 = false;
			}
			if (flag3)
			{
				float num145 = num133;
				Vector2 vector10 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
				float num146 = num134 - vector10.X;
				float num147 = num135 - vector10.Y;
				float num148 = (float)Math.Sqrt((double)(num146 * num146 + num147 * num147));
				num148 = num145 / num148;
				num146 *= num148;
				num147 *= num148;
				int num149 = 8;
				projectile.velocity.X = (projectile.velocity.X * (float)(num149 - 1) + num146) / (float)num149;
				projectile.velocity.Y = (projectile.velocity.Y * (float)(num149 - 1) + num147) / (float)num149;
			}
			#endregion
		}

		public override void Kill(int timeLeft)
		{
			int g = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
			Main.gore[g].velocity *= 0.4f;
			Gore gore85 = Main.gore[g];
			gore85.velocity.X = gore85.velocity.X + 1f;
			Gore gore86 = Main.gore[g];
			gore86.velocity.Y = gore86.velocity.Y + 1f;
			g = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
			Main.gore[g].velocity *= 0.4f;
			Gore gore87 = Main.gore[g];
			gore87.velocity.X = gore87.velocity.X - 1f;
			Gore gore88 = Main.gore[g];
			gore88.velocity.Y = gore88.velocity.Y + 1f;
			g = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
			Main.gore[g].velocity *= 0.4f;
			Gore gore89 = Main.gore[g];
			gore89.velocity.X = gore89.velocity.X + 1f;
			Gore gore90 = Main.gore[g];
			gore90.velocity.Y = gore90.velocity.Y - 1f;
			g = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
			Main.gore[g].velocity *= 0.4f;
			Gore gore91 = Main.gore[g];
			gore91.velocity.X = gore91.velocity.X - 1f;
			Gore gore92 = Main.gore[g];
			gore92.velocity.Y = gore92.velocity.Y - 1f;

			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, ModContent.ProjectileType<GenericExplodeFriendly>(), projectile.damage, 0, 0, ModContent.DustType<BlueTechDust>(), 0f);
			Main.PlaySound(SoundID.Item14, projectile.position);

			for (int i = 0; i < 16; i++)
			{
				int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<BlueTechDust>(), 0, 0, 0, default(Color), 1.5f);
				Main.dust[d].noGravity = true;
			}
		}


		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor) //glowmask
		{
			Texture2D texture = Main.projectileTexture[projectile.type];
			if(projectile.spriteDirection == 1)
			{
				spriteBatch.Draw
				(
					texture,
					new Vector2
				(
					projectile.position.X - Main.screenPosition.X + projectile.width * 0.5f,
					projectile.position.Y - Main.screenPosition.Y + projectile.height * 0.5f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				new Color(255, 255, 255, projectile.alpha),
				projectile.rotation,
				texture.Size() * 0.5f,
				projectile.scale,
				SpriteEffects.None,
				0f
				);
			}
			else
			{
				spriteBatch.Draw
				(
					texture,
					new Vector2
				(
					projectile.position.X - Main.screenPosition.X + projectile.width * 0.5f,
					projectile.position.Y - Main.screenPosition.Y + projectile.height * 0.5f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				new Color(255, 255, 255, projectile.alpha),
				projectile.rotation,
				texture.Size() * 0.5f,
				projectile.scale,
				SpriteEffects.FlipHorizontally,
				0f
				);
			}
		}

		public override bool PreDraw(SpriteBatch sb, Color lightColor)
		{
			if (projectile.spriteDirection == 1)
			{
				Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
				for (int k = 0; k < projectile.oldPos.Length; k++)
				{
					Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
					Color color = new Color(155, 155, 155, 100) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
					sb.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
				}
			}
			else
			{
				Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
				for (int k = 0; k < projectile.oldPos.Length; k++)
				{
					Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
					Color color = new Color(155, 155, 155, 100) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
					sb.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.FlipHorizontally, 0f);
				}
			}
			return true;
		}
	}
}
