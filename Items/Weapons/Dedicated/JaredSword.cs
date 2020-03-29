using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Weapons.Dedicated
{
	public class JaredSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Jetblade");
		}

		public override void SetDefaults()
		{
			item.damage = 23;
			item.melee = true;
			item.width = 20;
			item.height = 20;
			item.useTime = 24;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 6f;
			item.shoot = mod.ProjectileType("JaredSwordProj");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Main.PlaySound(SoundID.Item8, player.position);
			damage *= 2;
			return true;
		}
	}
}