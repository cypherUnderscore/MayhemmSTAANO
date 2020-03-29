using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Npcs.Bosses.Prototype
{
	[AutoloadBossHead]
	public class PrototypeMain : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Prototype");
			Main.npcFrameCount[npc.type] = 8;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 1824;
			npc.damage = 25;
			npc.defense = 8;
			npc.knockBackResist = 0f;
			npc.width = 50;
			npc.height = 50;
			npc.value = Item.buyPrice(0, 7, 0, 0);
			npc.npcSlots = 5f;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.Item14;
			npc.netAlways = true;
			npc.visualOffset = new Vector2(-25, 4);
			npc.localAI[1] = 0;
			npc.aiStyle = -1;
		}

		bool net;

		bool sp0PosSelected = false;
		bool playerRelativeDir;
		bool prdSelected = false;
		bool sp1Cond1 = false;
		bool spawnedPortals = false;

		int subphase = 0;
		int sp1ShootDelay = 0;
		int sp1Timer = 0;
		int sp2Timer = 0;
		float sp1MaxVel = 7f;

		int bombDelay = 0;

		Vector2 sp0TargetPos;

		public override void FindFrame(int frameHeight)
		{
			if (npc.ai[1] < 1200)
			{
				npc.spriteDirection = npc.direction;
				++npc.frameCounter;
				if (npc.frameCounter >= 48)
					npc.frameCounter = 0.0;
				npc.frame.Y = 50 * (int)(npc.frameCounter / 6.0);
			}

			if (npc.ai[1] > 1200 && npc.ai[1] < 1350)
			{
				npc.spriteDirection = npc.direction;
				++npc.frameCounter;
				if (npc.frameCounter >= 96)
					npc.frameCounter = 0.0;
				npc.frame.Y = 50 * (int)(npc.frameCounter / 12.0);
			}
		}

		public override void AI()
		{
			if (Main.expertMode)
			{
				sp1MaxVel = 10f;
			}
			Player target = Main.player[npc.target]; //selects the target player
			npc.TargetClosest(true);
			if (!Main.player[npc.target].active || Main.player[npc.target].dead) //despawn code
			{
				npc.TargetClosest(true);
				if (!Main.player[npc.target].active || Main.player[npc.target].dead)
				{
					npc.localAI[2]++;
					if (npc.localAI[2] >= 300)
					{
						npc.active = false;
					}
				}
				else
				{
					npc.localAI[2] = 0;
				}
			}
			if (Main.netMode != NetmodeID.MultiplayerClient) //multiplayer stuff
			{
				net = true;
			}
			else
			{
				net = false;
			}
			npc.localAI[1]++;
			if(npc.localAI[1] >= 30) //startup timer
			{
				if(npc.life < npc.lifeMax * 0.25f || (Main.expertMode && npc.life < npc.lifeMax * 0.4f)) //shoot bombs below a certain health/
				{
					bombDelay++;
					if (net && bombDelay >= 45)
					{
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Main.rand.NextFloat()* 8f - 4f, -6f, mod.ProjectileType("ProtoBomb"), 12, Main.myPlayer, 0, 0f, 0f);
						bombDelay = 0;
					}
				}
				#region Main AI
				if (subphase == 0)
				{
					if (net)
					{
						if (!sp0PosSelected)
						{
							sp0TargetPos = new Vector2(target.position.X + Main.rand.Next(-250, 250), target.position.Y + Main.rand.Next(-200, -90)); //set the target position relative to the targeted player
							sp0PosSelected = true;
							npc.netUpdate = true;
						}
						else
						{
							npc.position = Vector2.Lerp(npc.position, sp0TargetPos, 0.050f); //smoothly move to target position
							float toTargetPosX = sp0TargetPos.X - npc.position.X;
							float toTargetPosY = sp0TargetPos.Y - npc.position.Y;
							float distanceToTargetPos = (float)Math.Sqrt((double)(toTargetPosX * toTargetPosX + toTargetPosY * toTargetPosY));
							if (distanceToTargetPos <= 25f || (Main.expertMode && distanceToTargetPos <= 60f))
							{
								subphase = 1;
							}
							npc.netUpdate = true;
						}
					}
				}
				else if(subphase == 1)
				{
					sp1Timer++;
					sp1ShootDelay++;
					if(sp1ShootDelay >= 20)
					{
						float downVel = 8f;
						sp1ShootDelay = 0;
						if (Main.expertMode)
						{
							sp1ShootDelay = 5;
							downVel = 12f;
						}
						if (net)
						{
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 20f, 0, downVel, mod.ProjectileType("ProtoDownLaser"), 10, 0, Main.myPlayer, 0f, 0f);
							Main.PlaySound(SoundID.Item91, npc.Center);
						}
					}
					if(prdSelected == false)
					{
						if(target.position.X >= npc.position.X)
						{
							playerRelativeDir = true;
							npc.netUpdate = true;
						}
						else
						{
							playerRelativeDir = false;
							npc.netUpdate = true;
						}
						prdSelected = true;
					}
					if(playerRelativeDir == false)
					{
						npc.velocity.X -= 0.3f;
						if (npc.velocity.X < -sp1MaxVel)
						{
							npc.velocity.X = -sp1MaxVel;
						}
					}
					else
					{
						npc.velocity.X += 0.3f;
						if (npc.velocity.X > sp1MaxVel)
						{
							npc.velocity.X = sp1MaxVel;
						}
					}
					if (npc.position.Y > target.position.Y - 100 && !sp1Cond1)
					{
						npc.velocity.Y -= 0.4f;
						if (npc.velocity.X < -4f)
						{
							npc.velocity.X = -4f;
						}
					}
					else
					{
						sp1Cond1 = true;
						npc.velocity.Y = 0;
					}
					if (sp1Timer >= 120)
					{
						subphase = 2;
					}
				}
				else if(subphase == 2)
				{
					npc.velocity *= 0.9f;
					sp2Timer++;
					if(sp2Timer > 20 && !spawnedPortals)
					{
						if (NPC.AnyNPCs(mod.NPCType("ProtoMinion")))
						{
							if (!Main.expertMode && net)
							{
								for (int c = 0; c < 4; c++)
								{
									Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (Main.rand.NextFloat() * 8f - 4f), (Main.rand.NextFloat() * 8f - 4f), mod.ProjectileType("ProtoPortal"), 10, 0, Main.myPlayer, 0f, 0f);									}
								}
							else if (Main.expertMode && net)
							{
								for (int c2 = 0; c2 < 6; c2++)
								{
									Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (Main.rand.NextFloat() * 12f - 6f), (Main.rand.NextFloat() * 12f - 6f), mod.ProjectileType("ProtoPortal"), 10, 0, Main.myPlayer, 0f, 0f);
								}
							}
							Main.PlaySound(SoundID.Item92, npc.position);
						}
						else if (net)
						{
							for (int s = 0; s < 2; s++)
							{
								int n = NPC.NewNPC((int)npc.Center.X + Main.rand.Next(3), (int)npc.Center.Y + Main.rand.Next(3), mod.NPCType("ProtoMinion"));
								Main.npc[n].velocity = new Vector2(Main.rand.NextFloat() * 4 - 2, Main.rand.NextFloat() * 4 - 2);
							}
							Main.PlaySound(SoundID.DD2_DefenseTowerSpawn, npc.position);
						}
						int numDusts = 36;
						for (int k = 0; k < numDusts; k++)
						{
							Vector2 position = (Vector2.Normalize(npc.velocity) * new Vector2((float)npc.width / 2f, (float)npc.height) * 0.75f * 0.5f).RotatedBy((double)((float)(k - (numDusts / 2 - 1)) * 6.28318548f / (float)numDusts), default(Vector2)) + npc.Center;
							Vector2 velocity = position - npc.Center;
							int d = Dust.NewDust(position + velocity, 0, 0, 182, velocity.X * 2f, velocity.Y * 2f, 100, default(Color), 1f);
							Main.dust[d].noGravity = true;
							Main.dust[d].noLight = true;
							Main.dust[d].velocity = Vector2.Normalize(velocity) * 9f;
						}
						spawnedPortals = true;
					}
					if(sp2Timer > 60)
					{
						subphase = 3;
					}
				}
				else if(subphase == 3)
				{
					sp0PosSelected = false;
					prdSelected = false;
					sp1Cond1 = false;
					spawnedPortals = false;
					subphase = 0;
					sp1ShootDelay = 0;
					sp1Timer = 0;
					sp2Timer = 0;
				}
				#endregion
			}
		}

		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.LesserHealingPotion;
		}

		public override void NPCLoot()
		{
			STAANOWorld.downedProto = true;
			if (Main.expertMode)
			{
				Item.NewItem(npc.position, mod.ItemType("BoltSwarm"));
				Item.NewItem(npc.position, mod.ItemType("DarkScrap"), Main.rand.Next(5, 10));
			}
			int d = Main.rand.Next(3);
			if(d == 0)
			{
				Item.NewItem(npc.position, mod.ItemType("ScrapLobber"));
			}
			else if (d == 1)
			{
				Item.NewItem(npc.position, mod.ItemType("ProtoPulsar"));
			}
			else if (d == 2)
			{
				Item.NewItem(npc.position, mod.ItemType("PortalCore"));
			}
			Item.NewItem(npc.position, mod.ItemType("DarkScrap"), Main.rand.Next(15, 25));
			if(Main.rand.Next(10) == 0)
			{
				Item.NewItem(npc.position, mod.ItemType("ProtoTrophyItem"));
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				int g = Gore.NewGore(new Vector2(npc.position.X, npc.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[g].velocity *= 0.4f;
				Gore gore85 = Main.gore[g];
				gore85.velocity.X = gore85.velocity.X + 1f;
				Gore gore86 = Main.gore[g];
				gore86.velocity.Y = gore86.velocity.Y + 1f;
				g = Gore.NewGore(new Vector2(npc.position.X, npc.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[g].velocity *= 0.4f;
				Gore gore87 = Main.gore[g];
				gore87.velocity.X = gore87.velocity.X - 1f;
				Gore gore88 = Main.gore[g];
				gore88.velocity.Y = gore88.velocity.Y + 1f;
				g = Gore.NewGore(new Vector2(npc.position.X, npc.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[g].velocity *= 0.4f;
				Gore gore89 = Main.gore[g];
				gore89.velocity.X = gore89.velocity.X + 1f;
				Gore gore90 = Main.gore[g];
				gore90.velocity.Y = gore90.velocity.Y - 1f;
				g = Gore.NewGore(new Vector2(npc.position.X, npc.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[g].velocity *= 0.4f;
				Gore gore91 = Main.gore[g];
				gore91.velocity.X = gore91.velocity.X - 1f;
				Gore gore92 = Main.gore[g];
				gore92.velocity.Y = gore92.velocity.Y - 1f;

				for (int dn = 0; dn < 8; dn++)
				{
					int d = Dust.NewDust(npc.position, npc.width, npc.height, 6, 0, 0, 0, default(Color), 3f);
					Main.dust[d].velocity *= 2f;
					Main.dust[d].noGravity = true;

					int d2 = Dust.NewDust(npc.position, npc.width, npc.height, 182, 0, 0, 0, default(Color), 3f);
					Main.dust[d2].velocity *= 2f;
					Main.dust[d2].noGravity = true;
				}
			}
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.629f * bossLifeScale);
		}
	}
}
