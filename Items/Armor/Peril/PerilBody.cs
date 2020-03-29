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
	[AutoloadEquip(EquipType.Body)]
	public class PerilBody : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Peril Ribcage");
			Tooltip.SetDefault("5% increased critical strike chance\n10% increased damage");
		}
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 22;
			item.value = 5000;
			item.rare = 2;
			item.defense = 7;
		}

		public override void UpdateEquip(Player player)
		{
			STAANOPlayer modPlayer = player.GetModPlayer<STAANOPlayer>();
			modPlayer.IncAllDamage(0.05f);
			modPlayer.IncAllCrit(5);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "PerilMaterial", 32);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
