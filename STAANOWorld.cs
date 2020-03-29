using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace MayhemmSTAANO
{
	public class STAANOWorld : ModWorld
	{
		public Mod STAANO
		{
			get;
			internal set;
		}

		public static bool downedProto = false;

		public override void Initialize()
		{
			downedProto = false;
		}

		public override TagCompound Save()
		{
			var downed = new List<string>();
			if (downedProto)
			{
				downed.Add("prototype");
			}

			return new TagCompound
			{
				["downed"] = downed
			};
		}
		public override void Load(TagCompound tag)
		{
			var downed = tag.GetList<string>("downed");
			downedProto = downed.Contains("prototype");
		}

		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				downedProto = flags[0];
			}
			else
			{
				mod.Logger.WarnFormat("MayhemmSTAANO: Unknown loadVersion: {0}", loadVersion);
			}
		}

		public override void NetSend(BinaryWriter writer)
		{
			var flags = new BitsByte();
			flags[0] = downedProto;
			writer.Write(flags);
		}

		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			downedProto = flags[0];
		}
	}
}
