using SonicRetro.SonLVL.API;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace SCDObjectDefinitions.TAttack
{
	class RoundIcon : ObjectDefinition
	{
		private readonly Sprite[] sprites = new Sprite[14];
		private PropertySpec[] properties;

		public override void Init(ObjectData data)
		{
			BitmapBits sheet = LevelData.GetSpriteSheet("TAttack/TimeAttack.gif");
			sprites[0] = new Sprite(sheet.GetSection(1, 609, 68, 90), -34, -45);
			sprites[1] = new Sprite(sheet.GetSection(70, 577, 64, 16), -32, 15);
			sprites[2] = new Sprite(sheet.GetSection(135, 577, 64, 16), -32, 15);
			sprites[3] = new Sprite(sheet.GetSection(200, 577, 64, 16), -32, 15);
			sprites[4] = new Sprite(sheet.GetSection(265, 577, 64, 16), -32, 15);
			sprites[5] = new Sprite(sheet.GetSection(70, 593, 64, 16), -32, 15);
			sprites[6] = new Sprite(sheet.GetSection(135, 593, 64, 16), -32, 15);
			sprites[7] = new Sprite(sheet.GetSection(200, 593, 64, 16), -32, 15);
			sprites[8] = new Sprite(sheet.GetSection(265, 593, 64, 16), -32, 15);
			sprites[9] = new Sprite(sheet.GetSection(70, 638, 64, 13), -32, 31);
			sprites[10] = new Sprite(sheet.GetSection(70, 652, 64, 13), -32, 31);
			sprites[11] = new Sprite(sheet.GetSection(441, 860, 70, 92), -35, -46);
			sprites[12] = new Sprite(sheet.GetSection(223, 679, 56, 21), -29, -22);
			sprites[13] = new Sprite(sheet.GetSection(330, 604, 8, 13), 20, 16);
			
			properties = new PropertySpec[1];
			properties[0] = new PropertySpec("Round ID", typeof(int), "Extended",
                "Which Round this Icon is for.", null, new Dictionary<string, int>
				{
					{ "Palmtree Panic", 0 },
					{ "Collision Chaos", 1 },
					{ "Tidal Tempest", 2 },
					{ "Quartz Quadrant", 3 },
					{ "Wacky Workbench", 4 },
					{ "Stardust Speedway", 5 },
					{ "Metallic Madness", 6 },
					{ "Total Time", 7 }
				},
                (obj) => obj.PropertyValue & 15,
                (obj, value) => obj.PropertyValue = ((byte)((int)value)));
		}

		public override ReadOnlyCollection<byte> Subtypes
		{
			get { return new ReadOnlyCollection<byte>(new List<byte>()); }
		}
		
		public override byte DefaultSubtype
		{
			get { return 7; }
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
					return "Palmtree Panic";
				case 1:
					return "Collision Chaos";
				case 2:
					return "Tidal Tempest";
				case 3:	
					return "Quartz Quadrant";
				case 4:
					return "Wacky Workbench";
				case 5:
					return "Stardust Speedway";
				case 6:
					return "Metallic Madness";
				case 7:
					return "Total Time";
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
			List<Sprite> sprs = new List<Sprite>();
			Sprite sprite = new Sprite(sprites[0]);
			sprs.Add(sprite);
			
			if (subtype < 7)
			{
				sprite = new Sprite(sprites[10]);
				sprs.Add(sprite);
			}
			else
			{
				sprite = new Sprite(sprites[11]);
				sprs.Add(sprite);
				sprite = new Sprite(sprites[13]);
				sprs.Add(sprite);
			}
			sprite = new Sprite(sprites[subtype+1]);
			sprs.Add(sprite);
			return new Sprite(sprs.ToArray());
		}

		public override Sprite GetSprite(ObjectEntry obj)
		{
			return SubtypeImage(obj.PropertyValue);
		}
	}
}