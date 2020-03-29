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
	[AutoloadEquip(EquipType.Head)]
	public class PerilHead : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Peril Helmet");
			Tooltip.SetDefault("5% increased critical strike chance");
		}
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 20;
			item.value = 5000;
			item.rare = 2;
			item.defense = 6;
		}

		public override void UpdateEquip(Player player)
		{
			STAANOPlayer modPlayer = player.GetModPlayer<STAANOPlayer>();

			modPlayer.IncAllCrit(5);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("PerilBody") && legs.type == mod.ItemType("PerilLegs");
		}

		public override void UpdateArmorSet(Player player)
		{
			STAANOPlayer modPlayer = player.GetModPlayer<STAANOPlayer>();
			player.setBonus = "Immune to Peril Corrosion\n5% increased damage\nYour attacks have a chance to inflict Peril Acid";
			modPlayer.IncAllDamage(0.05f);
			modPlayer.perilSet = true;
			player.buffImmune[mod.BuffType("PerilCorrosion")] = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "PerilMaterial", 24);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
