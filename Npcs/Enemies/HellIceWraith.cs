using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Dusts;
using MayhemmSTAANO.Items.Materials;
using MayhemmSTAANO.Projectiles.NpcProjectiles;
using MayhemmSTAANO.Buffs;
using System;

namespace MayhemmSTAANO.Npcs.Enemies
{
    public class HellIceWraith : ModNPC
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stygian Frostwraith");
        }

		public override void SetDefaults() 
		{
            npc.width = 26;
            npc.height = 26;
            npc.damage = 85;
            npc.defense = 24;
            npc.lifeMax = 1000;
            npc.HitSound = SoundID.NPCHit5;
            npc.DeathSound = SoundID.Item27;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 2;
            npc.noGravity = true;
		}

        private Player player;

        int timer = 240;
        int timer2 = 0;

        public override void AI()
        {
            player = Main.player[npc.target];

            float toTargetX = npc.position.X + (float)(npc.width / 2) - Main.player[npc.target].position.X - (float)(Main.player[npc.target].width / 2);
            float toTargetY = npc.position.Y + (float)(npc.height / 2) - Main.player[npc.target].position.Y - (float)(Main.player[npc.target].height / 2);
            float lookRotation = (float)Math.Atan2((double)toTargetY, (double)toTargetX) - 1.57f;
            float distance = (float)Math.Sqrt((double)(toTargetX * toTargetX + toTargetY * toTargetY));

            npc.rotation = lookRotation;

            timer--;

            if(distance < 600 && timer <= 0)
            {
                npc.velocity *= 0.92f;
                if(npc.velocity.X < 1.5 && npc.velocity.Y < 1.5)
                {
                    timer2++;
                    if(timer2 > 30)
                    {
                        for (int p = 0; p < 3; p++)
                        {
                            if (Main.netMode != 1)
                            {
                                Vector2 speed = new Vector2(toTargetX / distance * 5, toTargetY / distance * 5).RotatedByRandom(MathHelper.ToRadians(25));
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -speed.X, -speed.Y, ModContent.ProjectileType<IceWraithProj>(), 30, 0, Main.myPlayer);
                                Main.PlaySound(SoundID.DD2_FlameburstTowerShot, npc.position);
                            }
                        }
                        timer = 240;
                        timer2 = 0;
                    }
                }
            }
        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.position, ModContent.ItemType<HellIce>(), Main.rand.Next(1, 3));
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(ModContent.BuffType<Dissolving>(), 150);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.player[Main.myPlayer].ZoneUnderworldHeight && NPC.downedGolemBoss)
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
                    Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<StyxIceDust>(), 0, 0, 0, default(Color), 1f);
                }
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/HellIceWraithGore1"));
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/HellIceWraithGore2"));
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/HellIceWraithGore3"));
            }
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.629f);
        }
    }
}