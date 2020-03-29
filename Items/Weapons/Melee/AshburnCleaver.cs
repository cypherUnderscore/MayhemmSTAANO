using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Projectiles;
using Microsoft.Xna.Framework;
using MayhemmSTAANO.Buffs;

namespace MayhemmSTAANO.Items.Weapons.Melee
{
	public class AshburnCleaver : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ashburn Cleaver");
			Tooltip.SetDefault("Hits cause ice spikes to rise from below the hit enemy");
		}

		public override void SetDefaults()
		{
			item.damage = 78;
			item.melee = true;
			item.width = 18;
			item.height = 18;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 15000;
			item.rare = 7;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			for(int s = 0; s < 4; s++)
			{
				Vector2 randomSpawn = new Vector2(target.Center.X + Main.rand.NextFloat(-24, 24), target.Center.Y + Main.rand.NextFloat(-4, 4) + 48);
				Projectile.NewProjectile(randomSpawn.X, randomSpawn.Y, 0, -6 * Main.rand.NextFloat(0.8f, 1.2f), ModContent.ProjectileType<IceSpike>(), damage, knockBack, player.whoAmI);
			}
			target.AddBuff(ModContent.BuffType<Dissolving>(), 120);
			Main.PlaySound(SoundID.Item101, player.position);
		}

		public override void OnHitPvp(Player player, Player target, int damage, bool crit)
		{
			target.AddBuff(ModContent.BuffType<Dissolving>(), 120);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AshenTwig", 12);
			recipe.AddIngredient(null, "HellIce", 16);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}