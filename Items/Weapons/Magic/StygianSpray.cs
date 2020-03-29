using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Projectiles;

namespace MayhemmSTAANO.Items.Weapons.Magic
{
	public class StygianSpray : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Stygian Spray");
			Tooltip.SetDefault("Fires a barrage of stygian water");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.damage = 53;
			item.magic = true;
			item.width = 28;
			item.height = 30;
			item.useTime = 7;
			item.useAnimation = 7;
			item.mana = 3;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 15000;
			item.rare = 7;
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
			item.noMelee = true;
			item.shoot = ModContent.ProjectileType<StygianSprayProj>();
			item.shootSpeed = 8f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			for (int i = 0; i < 2; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
				float scale = 1f - (Main.rand.NextFloat() * .2f);
				perturbedSpeed = perturbedSpeed * scale;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"AshenTwig", 12);
			recipe.AddIngredient(null, "HellIce", 16);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}