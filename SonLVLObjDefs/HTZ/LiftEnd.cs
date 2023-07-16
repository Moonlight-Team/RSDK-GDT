using SonicRetro.SonLVL.API;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace S2ObjectDefinitions.HTZ
{
	class LiftEnd : ObjectDefinition
	{
		private readonly Sprite[] sprites = new Sprite[4];
		private PropertySpec[] properties = new PropertySpec[1];

		public override void Init(ObjectData data)
		{
			if (LevelData.StageInfo.folder.EndsWith("Zone05"))
			{
				BitmapBits sheet = LevelData.GetSpriteSheet("HTZ/Objects.gif");
				sprites[0] = new Sprite(sheet.GetSection(174, 96, 16, 80), -8, -56);
				sprites[1] = new Sprite(sheet.GetSection(174, 177, 16, 78), -8, -54);
				sprites[2] = new Sprite(sheet.GetSection(126, 123, 16, 16), -8, -24);
				sprites[3] = new Sprite(sheet.GetSection(108, 123, 16, 16), -9, -24);
			}
			else
			{
				BitmapBits sheet = LevelData.GetSpriteSheet("MBZ/Objects.gif");
				sprites[0] = new Sprite(sheet.GetSection(34, 867, 16, 80), -8, -56);
				sprites[1] = new Sprite(sheet.GetSection(51, 869, 16, 78), -8, -54);
				sprites[2] = new Sprite(sheet.GetSection(92, 888, 0, 0), -8, -24); // empty frame as in the game's scripts, can't use a fixed frame cuz one doesn't exist
				sprites[3] = new Sprite(sheet.GetSection(92, 888, 0, 0), -9, -24);
			}
			
			properties[0] = new PropertySpec("Sprite ID", typeof(int), "Extended",
				"What sprite this Lift End should use.", null, new Dictionary<string, int>
				{
					{ "Start Post", 0 },
					{ "End Post", 1 },
					{ "Start Ground", 2 },
					{ "End Ground", 3 }
				},
				(obj) => obj.PropertyValue & 3,
				(obj, value) => obj.PropertyValue = ((byte)((int)value)));
		}

		public override ReadOnlyCollection<byte> Subtypes
		{
			get { return new ReadOnlyCollection<byte>(new byte[] { 0, 1, 2, 3 }); }
		}

		public override byte DefaultSubtype
		{
			get { return 0; }
		}

		public override PropertySpec[] CustomProperties
		{
			get { return properties; }
		}

		public override string SubtypeName(byte subtype)
		{
			switch (subtype)
			{
				case 0:
					return "Start Post";
				case 1:
					return "End Post";
				case 2:
					return "Start Ground";
				case 3:
					return "End Ground";
				default:
					return "Unknown";
			}
		}

		public override Sprite Image
		{
			get { return sprites[0]; }
		}

		public override Sprite SubtypeImage(byte subtype)
		{
			return sprites[subtype & 3];
		}

		public override Sprite GetSprite(ObjectEntry obj)
		{
			return SubtypeImage(obj.PropertyValue);
		}
	}
}