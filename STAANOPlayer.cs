using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;

using MayhemmSTAANO.Buffs;
using MayhemmSTAANO.Projectiles;

namespace MayhemmSTAANO
{
	public class STAANOPlayer : ModPlayer
	{
		int manaSurgeTimer = 0;

		public bool nerfMisfire = false;
		public bool preventMisfire = false;
		public bool boneBullet = false;
		public bool equinoxChamber = false;
		public bool fireBullets = false;
		public bool gunBlueprints = false;
		public bool rocketBook = false;
		public bool diary = false;
		public bool darkClip = false;
		public bool dukeBullet = false;
		public bool singularityMag = false;
		public bool ba = false;
		public bool manaSurgeAcc = false;
		public bool radCharm = false;
		public bool fireT = false;
		public bool soulT = false;
		public bool heatFlask = false;
		public bool iceFlask = false;
		public bool frostFlare = false;

		public bool perilSet = false;

		public bool manaSurge = false;
		public bool manaSurgeCooldown = false;
		public bool perilCorrosion = false;
		public bool dissolving = false;

		public override void ResetEffects()
		{
			nerfMisfire = false;
			preventMisfire = false;
			boneBullet = false;
			equinoxChamber = false;
			fireBullets = false;
			gunBlueprints = false;
			rocketBook = false;
			diary = false;
			darkClip = false;
			dukeBullet = false;
			singularityMag = false;
			ba = false;
			manaSurgeAcc = false;
			radCharm = false;
			fireT = false;
			soulT = false;
			heatFlask = false;
			iceFlask = false;
			frostFlare = false;

			perilSet = false;

			manaSurge = false;
			manaSurgeCooldown = false;
			perilCorrosion = false;
			dissolving = false;
		}

		public override void UpdateDead()
		{
			manaSurge = false;
			manaSurgeCooldown = false;
			perilCorrosion = false;
			dissolving = false;
		}

		public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.Bullet && Main.rand.Next(5) == 0 && fireBullets == true)
			{
				type = mod.ProjectileType("FireBullet");
				Main.PlaySound(SoundID.DD2_FlameburstTowerShot, player.position);
			}

			if (item.useAmmo == AmmoID.Bullet && Main.rand.Next(9) == 0 && rocketBook)
			{
				int num1 = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 134, damage, 0f, player.whoAmI);
				Main.projectile[num1].velocity *= 0.6f;
			}

			if (item.useAmmo == AmmoID.Bullet && Main.rand.Next(4) == 0 && diary)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("DungeonBookProj"), damage, 0f, player.whoAmI);
			}
			return true;
		}

		public override void UpdateLifeRegen()
		{
			if (manaSurge)
			{
				manaSurgeTimer++;
				if(manaSurgeTimer >= 3)
				{
					player.statMana += 1;
					manaSurgeTimer = 0;
				}													
				player.manaCost -= 0.5f;
				player.magicCrit += 20;
				player.magicDamage += 0.25f;
			}
		}

		public override void UpdateBadLifeRegen()
		{
			if (perilCorrosion)
			{
				if(player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;

				player.lifeRegen -= 20;

				player.statDefense -= 8;
			}

			if (dissolving)
			{
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;

				player.lifeRegen -= 25;

				player.statDefense -= 12;
			}
		}

		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (MayhemmSTAANO.ManaSurgeHotkey.JustPressed && !manaSurgeCooldown && manaSurgeAcc)
			{
				Main.PlaySound(SoundID.Item68, player.position);

				if (manaSurgeAcc)
				{
					player.AddBuff(mod.BuffType("ManaSurge"), ManaSurgeTime(240));
					player.AddBuff(mod.BuffType("ManaSurgeCooldown"), ManaSurgeCooldown(1800));
				}

				if (fireT && !soulT)
				{
					Projectile.NewProjectile(player.position, Vector2.Zero, ModContent.ProjectileType<FireTotem>(), 50, 0, 0);
				}

				if (soulT)
				{
					Projectile.NewProjectile(player.position, Vector2.Zero, ModContent.ProjectileType<SoulTotem>(), 150, 0, 0);
				}
			}
		}

		public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
		{
			if (MayhemmSTAANO.ManaSurgeHotkey.JustPressed && manaSurgeAcc)
			{
				if (drawInfo.shadow == 0f)
				{
					int numDusts = 18;
					for (int k = 0; k < numDusts; k++)
					{
						Vector2 vel = new Vector2(0, 10).RotatedBy((int)(k - (numDusts / 2 - 1)) * 6.28318548f / numDusts);
						int d = Dust.NewDust(drawInfo.position, 0, 0, 229, vel.X, vel.Y, 0, default(Color), 1f);
						Main.dust[d].noGravity = true;
						Main.dust[d].noLight = true;
						Main.dust[d].velocity = Vector2.Normalize(vel) * 9f;
						Main.dust[d].position.X += player.width * 0.5f;
						Main.dust[d].position.Y += player.height * 0.5f;
						Main.playerDrawDust.Add(d);
					}
				}
			}
		}

		public void IncAllDamage(float percent)
		{
			player.meleeDamage += percent;
			player.rangedDamage += percent;
			player.magicDamage += percent;
			player.minionDamage += percent;
			player.thrownDamage += percent;
		}

		public void IncAllCrit(int amount)
		{
			player.meleeCrit += amount;
			player.rangedCrit += amount;
			player.magicCrit += amount;
			player.thrownCrit += amount;
		}

		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
			if (perilSet && Main.rand.Next(5) == 0)
			{
				target.AddBuff(ModContent.BuffType<PerilCorrosion>(), 120);
			}
		}

		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if (proj.GetGlobalProjectile<GlobalProj>().CanTriggerOnHitEffects(proj.type) && proj.magic == true && ba == true && (Main.rand.Next(3) == 0 || manaSurge))
			{
				for(int n = 0; n < 3; n++)
				{
					Projectile.NewProjectile(proj.position, new Vector2(Main.rand.NextFloat() * 8 - 4, (Main.rand.NextFloat() * 8) - 4), ModContent.ProjectileType<baBlood>(), damage / 16, knockback, proj.owner);
				}
			}

			if (proj.GetGlobalProjectile<GlobalProj>().CanTriggerOnHitEffects(proj.type) && proj.magic == true && soulT == true && (Main.rand.Next(3) == 0 || manaSurge))
			{
				for (int n = 0; n < 2; n++)
				{
					Projectile.NewProjectile(proj.position, new Vector2(Main.rand.NextFloat() * 8 - 4, (Main.rand.NextFloat() * 8) - 4), ModContent.ProjectileType<SoulOrb>(), damage / 6, knockback, proj.owner);
				}
			}

			if (proj.GetGlobalProjectile<GlobalProj>().CanTriggerOnHitEffects(proj.type) && proj.magic == true && frostFlare && (Main.rand.Next(10) == 0 || (manaSurge && Main.rand.Next(5) == 0)))
			{
				for (int n = 0; n < 2; n++)
				{
					Projectile.NewProjectile(target.Center + Vector2.Normalize(new Vector2(Main.rand.NextFloat(-32, 32), Main.rand.NextFloat(-32, 32))) * Main.rand.NextFloat(32, 48), new Vector2(0, 0), ModContent.ProjectileType<FrostFlareProj>(), damage / 2, knockback, proj.owner);
				}
				Main.PlaySound(2, proj.position, 8);
			}

			if (proj.GetGlobalProjectile<GlobalProj>().CanTriggerOnHitEffects(proj.type) && proj.magic == true && radCharm == true && (Main.rand.Next(5) == 0 || (manaSurge && Main.rand.NextBool() == true)))
			{
				Projectile.NewProjectile(new Vector2(proj.position.X + Main.rand.NextFloat(-48, 48), proj.position.Y - 800), new Vector2(Main.rand.NextFloat() * 8 - 4, 20), ModContent.ProjectileType<RadiantCharmProj>(), damage, knockback, proj.owner);
				Main.PlaySound(2, proj.position, 9);
			}

			if (proj.GetGlobalProjectile<GlobalProj>().CanTriggerOnHitEffects(proj.type) && proj.magic == true && heatFlask == true && Main.rand.Next(3) == 0)
			{
				target.AddBuff(BuffID.OnFire, 90);
			}

			if (proj.GetGlobalProjectile<GlobalProj>().CanTriggerOnHitEffects(proj.type) && proj.magic == true && iceFlask == true && Main.rand.Next(3) == 0)
			{
				target.AddBuff(BuffID.Frostburn, 120);
			}

			if (perilSet && Main.rand.Next(5) == 0)
			{
				target.AddBuff(ModContent.BuffType<PerilCorrosion>(), 120);
			}
		}

		public override void OnHitPvp(Item item, Player target, int damage, bool crit)
		{
			
		}

		public override void OnHitPvpWithProj(Projectile proj, Player target, int damage, bool crit)
		{
			
		}

		#region Misfire + supershot
		public void SixshooterSupershot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 19f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}

			int superMuzzleFlashType = 0;

			if (player.GetModPlayer<STAANOPlayer>().gunBlueprints)
			{
				for (int i = 0; i < 3; i++)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(18));
					float scale = 1f - (Main.rand.NextFloat() * .2f);
					perturbedSpeed = perturbedSpeed * scale;
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X / 2, perturbedSpeed.Y / 2, mod.ProjectileType("BlueprintSpark"), damage / 5 + 3, 0f, player.whoAmI);
				}
			}

			if (player.GetModPlayer<STAANOPlayer>().dukeBullet)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX / 2, speedY / 2, mod.ProjectileType("DukeBulletProj"), damage / 2, 0f, player.whoAmI);
				Main.PlaySound(SoundID.Item84, player.position);
			}

			if (!player.GetModPlayer<STAANOPlayer>().equinoxChamber) //regular super
			{
				Main.PlaySound(SoundID.Item124, player.position);
				type = mod.ProjectileType("RevolverSuper");
				damage *= 4;
				superMuzzleFlashType = 235;
			}
			if (player.GetModPlayer<STAANOPlayer>().equinoxChamber) //equinox chamber super
			{
				Main.PlaySound(SoundID.Item124, player.position);
				type = mod.ProjectileType("LightSuper");
				damage *= 5;
				superMuzzleFlashType = 159;
			}

			int num2 = Dust.NewDust(position, 0, 0, superMuzzleFlashType, 0, 0, 0, default(Color), 1.5f);
			Main.dust[num2].velocity.X = (speedX * Main.rand.NextFloat(0.6f) + 0.1f) + player.velocity.X;
			Main.dust[num2].velocity.Y = (speedY * Main.rand.NextFloat(0.6f) + 0.1f) + player.velocity.Y;
			Main.dust[num2].noGravity = true;
		}

		public void SixshooterMisfire(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 19f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}

			if (player.GetModPlayer<STAANOPlayer>().gunBlueprints)
			{
				for (int i = 0; i < 3; i++)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(18));
					float scale = 1f - (Main.rand.NextFloat() * .2f);
					perturbedSpeed = perturbedSpeed * scale;
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X / 2, perturbedSpeed.Y / 2, mod.ProjectileType("BlueprintSpark"), damage / 5 + 3, 0f, player.whoAmI);
				}
			}

			if (player.GetModPlayer<STAANOPlayer>().dukeBullet)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX / 2, speedY / 2, mod.ProjectileType("DukeBulletProj"), damage / 2, 0f, player.whoAmI);
				Main.PlaySound(SoundID.Item84, player.position);
			}

			if (!player.GetModPlayer<STAANOPlayer>().preventMisfire)  //Code for misfiring without any effects
			{
				Main.PlaySound(SoundID.Item10, player.position);
				type = mod.ProjectileType("RevolverNull");
				damage *= 0;
				speedX *= 0.3f;
				speedY *= 0.2f;
			}

			if (player.GetModPlayer<STAANOPlayer>().boneBullet) //bone misfire effect
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BoneBulletProj"), damage / 2, 0f, player.whoAmI);
			}

			if (player.GetModPlayer<STAANOPlayer>().equinoxChamber)  //equinox chamber misfire effect
			{
				type = mod.ProjectileType("DarkBeam");
				Main.PlaySound(SoundID.Item125, player.position);
				if (player.GetModPlayer<STAANOPlayer>().darkClip)
				{
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("PenumbraClipProj"), damage / 4, 0f, player.whoAmI);
				}
				else
				{
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("EquinoxChamberProj"), damage / 4, 0f, player.whoAmI);
				}
				damage *= 2;
			}
		}
		#endregion

		public int WeaponCooldownTime(float baseTime)
		{
			return (int)baseTime;
		}

		public int ManaSurgeTime(float baseTime)
		{
			if (soulT)
			{
				baseTime = 300;
			}
			return (int)baseTime;
		}

		public int ManaSurgeCooldown(float baseTime)
		{
			if (soulT)
			{
				baseTime = 1500;
			}
			return (int)baseTime;
		}
	}
}
