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
using MayhemmSTAANO.Items.Accessories;

namespace MayhemmSTAANO.Items.Accessories
{
	public class SoulTalisman : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul Talisman");
			Tooltip.SetDefault("Magic projectiles have a chance to spawn stars from the sky or split into lingering light orbs\nAllows you to use Mana Surge\nWhile equipped, press the Mana Surge hotkey to activate Mana Surge\nMana Surge gives increased magic abilities and increases the chance of magic special effects activating\nActivating Mana Surge spawns a soul totem at your position\n12% increased magic damage\n6% increased magic critical stike chance\n6% decreased mana use");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 26;
			item.value = 5000;
			item.rare = 4;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<STAANOPlayer>().radCharm = true;
			player.GetModPlayer<STAANOPlayer>().soulT = true;
			player.GetModPlayer<STAANOPlayer>().manaSurgeAcc = true;
			player.magicDamage += 0.12f;
			player.manaCost -= 0.06f;
			player.magicCrit += 6;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<EruptionTotem>());
			recipe.AddIngredient(ModContent.ItemType<RadiantCharm>());
			recipe.AddIngredient(ModContent.ItemType<OverloaderCharm>());
			recipe.AddIngredient(ModContent.ItemType<BloodAmalgam>());
			recipe.AddIngredient(ItemID.SoulofFright);
			recipe.AddIngredient(ItemID.SoulofSight);
			recipe.AddIngredient(ItemID.SoulofMight);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
