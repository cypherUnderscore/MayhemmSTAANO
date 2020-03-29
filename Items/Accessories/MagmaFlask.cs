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
using MayhemmSTAANO.Items.Materials;

namespace MayhemmSTAANO.Items.Accessories
{
	public class MagmaFlask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flask of Eternal Heat");
			Tooltip.SetDefault("'A flask filled with forever hot magma'\nIncreases to magic abilities\nMagic attacks have a chance to set enemies on fire");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.value = 5000;
			item.rare = 2;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<STAANOPlayer>().heatFlask = true;
			player.magicCrit += 6;
			player.magicDamage *= 1.08f;
			player.manaCost *= 0.92f;
			player.statManaMax2 += 25;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<MagmaCrystal>(), 6);
			recipe.AddIngredient(ModContent.ItemType<AshenTwig>(), 8);
			recipe.AddIngredient(ModContent.ItemType<GelFlask>());
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
