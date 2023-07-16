using SonicRetro.SonLVL.API;
using System.Collections.Generic;
using System.Collections.ObjectModel;

// this file just hosts basic renders for single-sprite objects that just need zone folder checks

namespace S2ObjectDefinitions.MCZ
{
	class BossRock : MCZ.Generic
	{
		public override Sprite GetSprite()
		{
			if (LevelData.StageInfo.folder.EndsWith("Zone06"))
			{
				return new Sprite(LevelData.GetSpriteSheet("MCZ/Objects.gif").GetSection(131, 164, 8, 32), -4, -16);
			}
			else
			{
				return new Sprite(LevelData.GetSpriteSheet("MBZ/Objects.gif").GetSection(34, 191, 8, 32), -4, -16);
			}
		}
		
		public override bool Hidden { get { return true; } }
	}
	
	class Eggman : MCZ.Generic
	{
		public override Sprite GetSprite()
		{
			Sprite[] sprites = new Sprite[2];
			if (LevelData.StageInfo.folder.EndsWith("Zone06"))
			{
				BitmapBits sheet = LevelData.GetSpriteSheet("MCZ/Objects.gif");
				sprites[0] = new Sprite(sheet.GetSection(34, 48, 44, 16), -26, -24);
				sprites[1] = new Sprite(sheet.GetSection(74, 197, 70, 58), -38, -37);
			}
			else
			{
				BitmapBits sheet = LevelData.GetSpriteSheet("MBZ/Objects.gif");
				sprites[0] = new Sprite(sheet.GetSection(1, 5, 44, 16), -26, -24);
				sprites[1] = new Sprite(sheet.GetSection(182, 197, 70, 58), -38, -37);
			}
			
			return new Sprite(sprites);
		}
	}
	
	class EggmanDrill : MCZ.Generic
	{
		public override Sprite GetSprite()
		{
			if (LevelData.StageInfo.folder.EndsWith("Zone06"))
			{
				return new Sprite(LevelData.GetSpriteSheet("MCZ/Objects.gif").GetSection(1, 132, 24, 64), -12, -48);
			}
			else
			{
				return new Sprite(LevelData.GetSpriteSheet("MBZ/Objects.gif").GetSection(42, 191, 24, 64), -12, -48);
			}
		}
		
		public override bool Hidden { get { return true; } }
	}
	
	abstract class Generic : ObjectDefinition
	{
		private Sprite sprite;
		
		public override void Init(ObjectData data)
		{
			sprite = GetSprite();
		}
		
		public override ReadOnlyCollection<byte> Subtypes
		{
			get { return new ReadOnlyCollection<byte>(new List<byte>()); }
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
		
		public virtual Sprite GetSprite()
		{
			return (new Sprite(LevelData.GetSpriteSheet("Global/Display.gif").GetSection(1, 143, 32, 32), -16, -16));
		}
	}
}