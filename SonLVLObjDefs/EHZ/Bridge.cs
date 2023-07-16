using SonicRetro.SonLVL.API;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace S2ObjectDefinitions.EHZ
{
	class Bridge : ObjectDefinition
	{
		private Sprite sprite;
		private PropertySpec[] properties = new PropertySpec[1];
		
		public override void Init(ObjectData data)
		{
			if (LevelData.StageInfo.folder.EndsWith("Zone01"))
			{
				sprite = new Sprite(LevelData.GetSpriteSheet("EHZ/Objects.gif").GetSection(82, 78, 16, 16), -8, -8);
			}
			else
			{
				sprite = new Sprite(LevelData.GetSpriteSheet("MBZ/Objects.gif").GetSection(137, 313, 16, 16), -8, -8);
			}
			
			properties[0] = new PropertySpec("Length", typeof(int), "Extended",
				"How long this Bridge will be.", null,
				(obj) => obj.PropertyValue,
				(obj, value) => obj.PropertyValue = (byte)((int)value));
		}

		public override ReadOnlyCollection<byte> Subtypes
		{
			get { return new ReadOnlyCollection<byte>(new List<byte>()); }
		}
		
		public override byte DefaultSubtype
		{
			get { return 8; }
		}

		public override string SubtypeName(byte subtype)
		{
			return (subtype) + " logs";
		}
		
		public override PropertySpec[] CustomProperties
		{
			get { return properties; }
		}

		public override Sprite Image
		{
			get { return sprite; }
		}

		public override Sprite SubtypeImage(byte subtype)
		{
			return sprite;
		}

		public override Sprite GetSprite(ObjectEntry obj)
		{
			if (obj.PropertyValue == 0)
				return sprite;
			
			int st = -(((obj.PropertyValue) * 16) / 2) + 8;
			List<Sprite> sprs = new List<Sprite>();
			for (int i = 0; i < obj.PropertyValue; i++)
			{
				sprs.Add(new Sprite(sprite, st + (i * 16), 0));
			}
			return new Sprite(sprs.ToArray());
		}
	}
}