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

namespace MayhemmSTAANO.Items.Accessories
{
	public class OverloaderCharm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Overloader Charm");
			Tooltip.SetDefault("Allows you to use Mana Surge\nWhile equipped, press the Mana Surge hotkey to activate Mana Surge\nMana Surge gives increased magic abilities and increases the chance of magic special effects activating");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 24;
			item.value = 5000;
			item.rare = 2;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<STAANOPlayer>().manaSurgeAcc = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Chain);
			recipe.AddIngredient(ItemID.ManaCrystal);
			recipe.AddIngredient(null, "AshenTwig", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
