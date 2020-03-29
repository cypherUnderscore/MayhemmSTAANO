using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Armor.Peril
{
	[AutoloadEquip(EquipType.Legs)]
	public class PerilLegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Peril Leggings");
			Tooltip.SetDefault("10% increased movement speed");
		}
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.value = 5000;
			item.rare = 2;
			item.defense = 7;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.10f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "PerilMaterial", 16);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
