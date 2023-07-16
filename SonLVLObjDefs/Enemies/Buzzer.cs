using SonicRetro.SonLVL.API;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace S2ObjectDefinitions.Enemies
{
	class Buzzer : ObjectDefinition
	{
		private readonly Sprite[] sprites = new Sprite[2];
		private PropertySpec[] properties = new PropertySpec[2];

		public override void Init(ObjectData data)
		{
			Sprite[] frames = new Sprite[2];
			
			if (LevelData.StageInfo.folder.EndsWith("Zone01"))
			{
				BitmapBits sheet = LevelData.GetSpriteSheet("EHZ/Objects.gif");
				frames[0] = new Sprite(sheet.GetSection(1, 1, 48, 16), -24, -8);
				frames[1] = new Sprite(sheet.GetSection(19, 50, 6, 5), 5, -8);
			}
			else
			{
				BitmapBits sheet = LevelData.GetSpriteSheet("MBZ/Objects.gif");
				frames[0] = new Sprite(sheet.GetSection(1, 256, 48, 16), -24, -8);
				frames[1] = new Sprite(sheet.GetSection(137, 331, 6, 5), 5, -8);
			}
			
			sprites[0] = new Sprite(frames);
			sprites[1] = new Sprite(sprites[0], true, false);
			
			properties[0] = new PropertySpec("Direction", typeof(int), "Extended",
				"The direction the Buzzer will be facing initially.", null, new Dictionary<string, int>
				{
					{ "Left", 0 },
					{ "Right", 1 }
				},
				(obj) => obj.PropertyValue & 1,
				(obj, value) => obj.PropertyValue = (byte)((obj.PropertyValue & ~1) | (byte)((int)value)));
			
			properties[1] = new PropertySpec("Static", typeof(bool), "Extended",
				"If the Buzzer should stay in one place, rather than hover around a spot. Only has effect in Origins' Mission Mode.", null,
				(obj) => obj.PropertyValue & 2,
				(obj, value) => obj.PropertyValue = (byte)((obj.PropertyValue & ~2) | ((bool)value ? 2 : 0)));
		}

		public override ReadOnlyCollection<byte> Subtypes
		{
			get { return new ReadOnlyCollection<byte>(new List<byte>()); }
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
			return subtype + "";
		}

		public override Sprite Image
		{
			get { return sprites[0]; }
		}

		public override Sprite SubtypeImage(byte subtype)
		{
			return sprites[subtype & 1];
		}

		public override Sprite GetSprite(ObjectEntry obj)
		{
			return sprites[obj.PropertyValue & 1];
		}
	}
}