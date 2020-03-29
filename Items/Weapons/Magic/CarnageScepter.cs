using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Projectiles;

namespace MayhemmSTAANO.Items.Weapons.Magic
{
	public class CarnageScepter : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Carnage Scepter");
			Tooltip.SetDefault("Shoots an acid ball");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.damage = 41;
			item.magic = true;
			item.width = 28;
			item.height = 30;
			item.useTime = 18;
			item.useAnimation = 18;
			item.mana = 7;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 2000;
			item.rare = 2;
			item.autoReuse = true;
			item.noMelee = true;
			item.shoot = ModContent.ProjectileType<PerilStaffProj>();
			item.shootSpeed = 8f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Main.PlaySound(2, position, 21);
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"PerilMaterial", 24);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}