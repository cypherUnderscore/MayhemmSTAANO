using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Projectiles;

namespace MayhemmSTAANO.Items.Weapons.Magic
{
	public class ElectroHarp : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Electro Harp");
			Tooltip.SetDefault("Fires a storm of music notes\n'May contain traces of thorium'");
		}

		public override void SetDefaults()
		{
			item.damage = 105;
			item.width = 50;
			item.height = 50;
			item.mana = 5;
			item.useTime = 6;
			item.useAnimation = 6;
			item.magic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.holdStyle = 3;
			item.useStyle = 5;
			item.knockBack = 2;
			item.value = Item.sellPrice(0, 30, 0, 0);
			item.rare = 10;
			item.shoot = ModContent.ProjectileType<EHarpNote1>();
			item.shootSpeed = 9f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 20f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			for(int s = 0; s < 2; s++)
			{
				int rand = Main.rand.Next(3);

				if (rand == 0) type = ModContent.ProjectileType<EHarpNote1>();
				else if (rand == 1) type = ModContent.ProjectileType<EHarpNote2>();
				else if (rand == 2) type = ModContent.ProjectileType<EHarpNote3>();

				Vector2 shootSpread = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
				speedX = shootSpread.X;
				speedY = shootSpread.Y;

				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, 0f, player.whoAmI);
			}

			float dtmx = player.Center.X - Main.MouseWorld.X;
			float dtmy = player.Center.Y - Main.MouseWorld.Y;
			float dtm = (float)System.Math.Sqrt((double)(dtmx * dtmx + dtmy * dtmy));

			Main.harpNote = dtm / 540;
			if (Main.harpNote > 1f) Main.harpNote = 1f;

			Main.PlaySound(2, position, 26);

			return false;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(1, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MagicalHarp);
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}