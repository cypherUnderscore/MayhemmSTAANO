using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.BossDrops.Prototype
{
	public class BoltSwarm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bolt Swarmer");
		}

		public override void SetDefaults()
		{
			item.damage = 7;
			item.ranged = true;
			item.width = 38;
			item.height = 24;
			item.useTime = 6;
			item.useAnimation = 6;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 1;
			item.value = 5000;
			item.rare = 1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Bolt");
			item.shootSpeed = 6f;
			item.expert = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Main.PlaySound(2, position, 91);
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			for (int s = 0; s < 2; s++)
			{
				Vector2 shootSpread = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
				Projectile.NewProjectile(position, shootSpread, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1f, 0);
		}
	}
}