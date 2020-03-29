using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Projectiles.Explosions;
using MayhemmSTAANO.Buffs;

namespace MayhemmSTAANO.Items.Weapons.Melee
{
	public class PerilCutter : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Peril Cutter");
			Tooltip.SetDefault("Hits cause a peril acid explosion");
		}

		public override void SetDefaults()
		{
			item.damage = 34;
			item.melee = true;
			item.width = 18;
			item.height = 18;
			item.useTime = 24;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 5000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			Projectile.NewProjectile(target.position.X, target.position.Y, 0, 0, ModContent.ProjectileType<PerilAcidExplosion>(), damage / 2, knockBack, player.whoAmI);
			Main.PlaySound(SoundID.NPCHit13, player.position);
			target.AddBuff(ModContent.BuffType<PerilCorrosion>(), 300);
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