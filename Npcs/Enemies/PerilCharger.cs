using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Dusts;
using MayhemmSTAANO.Items.Materials;
using MayhemmSTAANO.Buffs;

namespace MayhemmSTAANO.Npcs.Enemies
{
    public class PerilCharger : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Peril Charger");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.width = 48;
            npc.height = 29;
            npc.damage = 24;
            npc.defense = 10;
            npc.lifeMax = 320;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.knockBackResist = 0.2f;
            npc.aiStyle = 3;
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.ai[1] < 1200)
            {
                npc.spriteDirection = -npc.direction;
                ++npc.frameCounter;
                if (npc.frameCounter >= 24)
                    npc.frameCounter = 0.0;
                npc.frame.Y = 30 * (int)(npc.frameCounter / 6.0);
            }

            if (npc.ai[1] > 1200 && npc.ai[1] < 1350)
            {
                npc.spriteDirection = -npc.direction;
                ++npc.frameCounter;
                if (npc.frameCounter >= 48)
                    npc.frameCounter = 0.0;
                npc.frame.Y = 30 * (int)(npc.frameCounter / 12.0);
            }

            if (!npc.collideY)
            {
                npc.frame.Y = 0;
            }
        }

        public override void AI()
        {
            npc.spriteDirection = -npc.direction;

            Player target = Main.player[npc.target];

            float distToX = target.position.X + (float)target.width * 0.5f - npc.Center.X;
            float distToY = target.position.Y + (float)target.height * 0.5f - npc.Center.Y;
            float distToTarget = (float)System.Math.Sqrt((double)(distToX * distToX + distToY * distToY));

            if(distToTarget < 800f && !(target.position.Y < npc.position.Y - 200))
            {
                npc.aiStyle = -1;
                float maxVel = 3f;
                if(target.position.X >= npc.position.X)
                {
                    npc.velocity.X += 1f;
                    if(npc.velocity.X > maxVel)
                    {
                        npc.velocity.X = maxVel;
                    }
                    npc.direction = 1;
                }
                else
                {
                    npc.velocity.X -= 1f;
                    if (npc.velocity.X < -maxVel)
                    {
                        npc.velocity.X = -maxVel;
                    }
                    npc.direction = -1;
                }
            }
            else
            {
                npc.aiStyle = 3;
            }
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
            if (npc.life <= 0)
            {
                for (int dn = 0; dn < 12; dn++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<PerilDust>(), 0, 0, 0, default(Color), 1f);
                }
                for(int g = 0; g < 2; g++)
                {
                    Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/PerilChargerGore1"));
                }
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/PerilChargerGore2"));
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/PerilChargerGore3"));
            }
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.429f);
        }
    }
}