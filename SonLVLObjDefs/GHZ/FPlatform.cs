using SonicRetro.SonLVL.API;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace S1ObjectDefinitions.GHZ
{
	class FPlatform : ObjectDefinition
	{
		private PropertySpec[] properties = new PropertySpec[1];
		private Sprite sprite;
		private Sprite debug;
		
		public override void Init(ObjectData data)
		{
			sprite = new Sprite(LevelData.GetSpriteSheet("GHZ/Objects.gif").GetSection(50, 18, 64, 32), -32, -14);
			
			// tagging this area with LevelData.ColorWhite
			BitmapBits bitmap = new BitmapBits(1, 0x1C);
			bitmap.DrawLine(6, 0, 0x00, 0, 0x03);
			bitmap.DrawLine(6, 0, 0x08, 0, 0x0B);
			bitmap.DrawLine(6, 0, 0x10, 0, 0x13);
			bitmap.DrawLine(6, 0, 0x18, 0, 0x1B);
			debug = new Sprite(bitmap, 0, 14);
			
			properties[0] = new PropertySpec("Behaviour", typeof(int), "Extended",
				"How this Platform should act upon player contact.", null, new Dictionary<string, int>
				{
					{ "Fall", 0 },
					{ "Static", 1 }
				},
				(obj) => (obj.PropertyValue == 0) ? 0 : 1,
				(obj, value) => obj.PropertyValue = (byte)(int)value);
		}
		
		public override ReadOnlyCollection<byte> Subtypes
		{
			get { return new ReadOnlyCollection<byte>(new byte[] { 0, 1 }); }
		}
		
		public override byte DefaultSubtype
		{
			get { return 1; }
		}
		
		public override PropertySpec[] CustomProperties
		{
			get { return properties; }
		}

		public override string SubtypeName(byte subtype)
		{
			return (subtype == 1) ? "Static Platform" : "Falling Platform";
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
			return sprite;
		}
		
		public override Sprite GetDebugOverlay(ObjectEntry obj)
		{
			return (obj.PropertyValue == 0) ? debug : null;
		}
	}
}