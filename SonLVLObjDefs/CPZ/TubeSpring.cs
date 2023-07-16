using SonicRetro.SonLVL.API;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace S2ObjectDefinitions.CPZ
{
	class TubeSpring : ObjectDefinition
	{
		private Sprite sprite;
		private PropertySpec[] properties = new PropertySpec[4];

		public override void Init(ObjectData data)
		{
			if (LevelData.StageInfo.folder.EndsWith("Zone02"))
			{
				sprite = new Sprite(LevelData.GetSpriteSheet("CPZ/Objects.gif").GetSection(191, 1, 32, 16), -16, -16);
			}
			else
			{
				sprite = new Sprite(LevelData.GetSpriteSheet("MBZ/Objects.gif").GetSection(99, 377, 32, 16), -16, -16);
			}
			
			properties[0] = new PropertySpec("Use Twirl Anim", typeof(bool), "Extended",
				"If this Spring should trigger the Twirling animation upon launch.", null,
				(obj) => (obj.PropertyValue & 1) == 1,
				(obj, value) => obj.PropertyValue = (byte)((obj.PropertyValue & ~1) | (byte)((bool)value ? 1 : 0)));
			
			properties[1] = new PropertySpec("Strength", typeof(bool), "Extended",
				"This Spring's launch velocity.", null, new Dictionary<string, int>
				{
					{ "Weak", 0 },
					{ "Strong", 2 }
				},
				(obj) => obj.PropertyValue & 2,
				(obj, value) => obj.PropertyValue = (byte)((obj.PropertyValue & ~2) | (byte)((int)value)));
			
			properties[2] = new PropertySpec("Collision Plane", typeof(bool), "Extended",
				"Which Collision Plane this Spring should set the Player too upon launch.", null, new Dictionary<string, int>
				{
					{ "Don't Set", 0 },
					{ "Plane A", 2 },
					{ "Plane B", 4 }
				},
				(obj) => (obj.PropertyValue >> 2),
				(obj, value) => obj.PropertyValue = (byte)((obj.PropertyValue & ~6) | (byte)((int)value)));
			
			properties[3] = new PropertySpec("Reset XVel", typeof(bool), "Extended",
				"If this Spring should reset the Player's X Velocity upon launch.", null,
				(obj) => (obj.PropertyValue & 0x80) == 0x80,
				(obj, value) => obj.PropertyValue = (byte)((obj.PropertyValue & ~0x80) | (byte)(((bool)value == true) ? 0x80 : 0x00)));
		}

		public override ReadOnlyCollection<byte> Subtypes
		{
			get { return new ReadOnlyCollection<byte>(new List<byte>()); }
		}
		
		public override PropertySpec[] CustomProperties
		{
			get { return properties; }
		}

		public override string SubtypeName(byte subtype)
		{
			return null;
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
	}
}