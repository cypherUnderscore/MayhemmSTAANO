using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Weapons.Summon
{
	public class DarkChargerRemote : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Dark Charger Remote");
			Tooltip.SetDefault("Summons an explosive dark charger");
		}

		public override void SetDefaults() 
		{
			item.damage = 23;
			item.summon = true;
			item.width = 30;
			item.height = 28;
			item.useTime = 30;
			item.useAnimation = 30;
			item.mana = 5;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 2000;
			item.rare = 6;
			item.UseSound = SoundID.DD2_DefenseTowerSpawn;
			item.autoReuse = true;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("DarkCharger");
			item.shootSpeed = 8f;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(1, 0);
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"DarkScrap", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}