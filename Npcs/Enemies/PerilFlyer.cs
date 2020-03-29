using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Dusts;
using MayhemmSTAANO.Items.Materials;
using MayhemmSTAANO.Buffs;

namespace MayhemmSTAANO.Npcs.Enemies
{
    public class PerilFlyer : ModNPC
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Peril Flyer");
        }

		public override void SetDefaults() 
		{
            npc.width = 48;
            npc.height = 28;
            npc.damage = 24;
            npc.defense = 10;
            npc.lifeMax = 320;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.knockBackResist = 0.2f;
            npc.aiStyle = 2;
            npc.noGravity = true;
		}

        public override void AI()
        {
            npc.rotation = (npc.velocity.X * 0.05f);
            npc.spriteDirection = npc.direction;
        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.position, ItemID.Heart);
            Item.NewItem(npc.position, ModContent.ItemType<PerilMaterial>(), Main.rand.Next(2, 5));
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(ModContent.BuffType<PerilCorrosion>(), 300);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.bloodMoon && NPC.downedBoss3)
            {
                return 0.2f;
            }
            else
            {
                return 0;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if(npc.life <= 0)
            {
                for (int dn = 0; dn < 12; dn++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<PerilDust>(), 0, 0, 0, default(Color), 1f);
                }
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/PerilFlyerGore1"));
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/PerilFlyerGore2"));
            }
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.429f);
        }
    }
}