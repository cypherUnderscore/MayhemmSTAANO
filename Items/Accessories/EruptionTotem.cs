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
	public class EruptionTotem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eruption Totem");
			Tooltip.SetDefault("Activating Mana Surge summons an infernal totem at your position");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 26;
			item.value = 2000;
			item.rare = 2;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<STAANOPlayer>().fireT = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 6);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.AddIngredient(ModContent.ItemType<AshenTwig>(), 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
