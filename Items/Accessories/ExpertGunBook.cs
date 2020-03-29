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
	public class ExpertGunBook : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Expert's Guide to Firearms");
			Tooltip.SetDefault("Guns have a chance to fire a homing soul or a rocket\nSupershots and misfires create damaging sparks\n15% increased bullet and rocket damage\n'Pretty sure this book is filled to the brim with illegal knowledge, but who really cares?'");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 25000;
			item.rare = 9;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<STAANOPlayer>().diary = true;
			player.GetModPlayer<STAANOPlayer>().rocketBook = true;
			player.GetModPlayer<STAANOPlayer>().gunBlueprints = true;
			player.bulletDamage *= 1.15f;
			player.rocketDamage *= 1.15f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentVortex, 5);
			recipe.AddIngredient(ItemID.FragmentSolar, 5);
			recipe.AddIngredient(ItemID.FragmentNebula, 5);
			recipe.AddIngredient(ItemID.FragmentStardust, 5);
			recipe.AddIngredient(null, "DungeonBook");
			recipe.AddIngredient(null, "GunPaper");
			recipe.AddIngredient(null, "GunBlueprints");
			recipe.AddIngredient(null, "RocketBook");
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
