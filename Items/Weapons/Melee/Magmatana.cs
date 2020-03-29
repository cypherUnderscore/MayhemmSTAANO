using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Projectiles;
using MayhemmSTAANO.Items.Materials;

namespace MayhemmSTAANO.Items.Weapons.Melee
{
	public class Magmatana : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Magmatana");
			Tooltip.SetDefault("Fires a lava slash");
		}

		public override void SetDefaults()
		{
			item.damage = 28;
			item.melee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 30;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 4;
			item.useTurn = true;
			item.value = 2500;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 6f;
			item.shoot = ModContent.ProjectileType<MagmatanaProj>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Main.PlaySound(SoundID.DD2_FlameburstTowerShot, player.position);
			damage *= 2;
			return true;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 120);
		}

		public override void OnHitPvp(Player player, Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 120);
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