using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.BossDrops.Prototype
{
	public class PortalCore : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Portal Core");
		}

		public override void SetDefaults()
		{
			item.damage = 36;
			item.magic = true;
			item.width = 38;
			item.height = 24;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 5000;
			item.rare = 1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ProtoPortalFriendly");
			item.shootSpeed = 8f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Main.PlaySound(2, position, 92);
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			Vector2 shootSpread = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(8));
			speedX = shootSpread.X;
			speedY = shootSpread.Y;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1f, 0);
		}
	}
}