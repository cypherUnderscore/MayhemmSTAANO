using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Weapons.Ranged
{
	public class Dawn : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dawn");
		}

		public override void SetDefaults()
		{
			item.damage = 123;
			item.ranged = true;
			item.width = 38;
			item.height = 24;
			item.useTime = 1;
			item.useAnimation = 36;
			item.reuseDelay = 10;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 6;
			item.value = 5000;
			item.rare = 1;
			item.UseSound = SoundID.Item15;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("DawnLaser");
			item.shootSpeed = 8f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}

			if(player.itemAnimation <= 1)
			{
				Main.PlaySound(SoundID.Item68, player.position);
				Main.PlaySound(SoundID.Item91, player.position);
				return true;
			}

			return false;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-0.2f, 0f);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofMight, 8);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(ItemID.LaserRifle);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}