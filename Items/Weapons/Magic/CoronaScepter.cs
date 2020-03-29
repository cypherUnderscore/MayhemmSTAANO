using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Weapons.Magic
{
	public class CoronaScepter : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Corona Scepter");
			Tooltip.SetDefault("Shoots corona orbs\n'Not a virus'");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.damage = 64;
			item.magic = true;
			item.width = 28;
			item.height = 30;
			item.useTime = 22;
			item.useAnimation = 22;
			item.mana = 11;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 2000;
			item.rare = 6;
			item.UseSound = SoundID.Item117;
			item.autoReuse = true;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("CoronaScepterProj");
			item.shootSpeed = 6f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			for (int i = 0; i < 3; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
				float scale = 1f - (Main.rand.NextFloat() * .2f);
				perturbedSpeed = perturbedSpeed * scale;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"TortureSoul", 18);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}