using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Projectiles;
using MayhemmSTAANO.Items.Materials;

namespace MayhemmSTAANO.Items.Weapons.Magic
{
	public class MagmaticStaff : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Magmatic Staff");
			Tooltip.SetDefault("Fires a fire bolt that weakly homes in on enemies");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.damage = 24;
			item.magic = true;
			item.width = 28;
			item.height = 30;
			item.useTime = 22;
			item.useAnimation = 22;
			item.mana = 8;
			item.useStyle = 5;
			item.knockBack = 2;
			item.value = 2500;
			item.rare = 2;
			item.autoReuse = true;
			item.noMelee = true;
			item.shoot = ModContent.ProjectileType<MagmaticStaffProj>();
			item.shootSpeed = 6f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Main.PlaySound(2, position, 42);
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<MagmaCrystal>(), 18);
			recipe.AddIngredient(ModContent.ItemType<AshenTwig>(), 14);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}