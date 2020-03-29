using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Weapons.Magic
{
	public class CrimsonFlare : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Crimson Flare");
			Tooltip.SetDefault("Fires a slow moving red flare");
		}

		public override void SetDefaults() 
		{
			item.damage = 14;
			item.magic = true;
			item.width = 28;
			item.height = 30;
			item.useTime = 10;
			item.useAnimation = 10;
			item.mana = 4;
			item.useStyle = 5;
			item.knockBack = 0;
			item.value = 2000;
			item.rare = 1;
			item.UseSound = SoundID.Item9;
			item.autoReuse = true;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("CrimsonFlareProj");
			item.shootSpeed = 6f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 shootSpread = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(8));
			speedX = shootSpread.X;
			speedY = shootSpread.Y;

			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 20f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(1, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarkScrap", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}