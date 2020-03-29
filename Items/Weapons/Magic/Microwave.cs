using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Weapons.Magic
{
	public class Microwave : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Microwave");
			Tooltip.SetDefault("Cook your foes alive");
		}

		public override void SetDefaults() 
		{
			item.damage = 26;
			item.magic = true;
			item.width = 28;
			item.height = 30;
			item.useTime = 1;
			item.useAnimation = 20;
			item.mana = 11;
			item.useStyle = 5;
			item.knockBack = 0;
			item.value = 2000;
			item.rare = 6;
			item.UseSound = SoundID.Item15;
			item.autoReuse = true;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("InvisRad");
			item.shootSpeed = 4f;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(1, 0);
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"ReflectiveAlloy", 6);
			recipe.AddIngredient(ItemID.Wire, 25);
			recipe.AddIngredient(ItemID.HellstoneBar, 2);
			recipe.AddIngredient(ItemID.Glass, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}