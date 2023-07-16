using SonicRetro.SonLVL.API;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace S2ObjectDefinitions.EHZ
{
	class SpiralPath : ObjectDefinition
	{
		private Sprite sprite;
		private Sprite debug;

		public override void Init(ObjectData data)
		{
			sprite = new Sprite(LevelData.GetSpriteSheet("Global/Display.gif").GetSection(127, 113, 16, 16), -8, -8);
			
			// SpiralPath_offsetTable
			int[] offsetTable = { 
				 32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,
				 32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  31,  31,
				 31,  31,  31,  31,  31,  31,  31,  31,  31,  31,  31,  31,  31,  30,  30,  30,
				 30,  30,  30,  30,  30,  30,  29,  29,  29,  29,  29,  28,  28,  28,  28,  27,
				 27,  27,  27,  26,  26,  26,  25,  25,  25,  24,  24,  24,  23,  23,  22,  22,
				 21,  21,  20,  20,  19,  18,  18,  17,  16,  16,  15,  14,  14,  13,  12,  12,
				 11,  10,  10,   9,   8,   8,   7,   6,   6,   5,   4,   4,   3,   2,   2,   1,
				  0,  -1,  -2,  -2,  -3,  -4,  -4,  -5,  -6,  -7,  -7,  -8,  -9,  -9, -10, -10,
				-11, -11, -12, -12, -13, -14, -14, -15, -15, -16, -16, -17, -17, -18, -18, -19,
				-19, -19, -20, -21, -21, -22, -22, -23, -23, -24, -24, -25, -25, -26, -26, -27,
				-27, -28, -28, -28, -29, -29, -30, -30, -30, -31, -31, -31, -32, -32, -32, -33,
				-33, -33, -33, -34, -34, -34, -35, -35, -35, -35, -35, -35, -35, -35, -36, -36,
				-36, -36, -36, -36, -36, -36, -36, -37, -37, -37, -37, -37, -37, -37, -37, -37,
				-37, -37, -37, -37, -37, -37, -37, -37, -37, -37, -37, -37, -37, -37, -37, -37,
				-37, -37, -37, -37, -36, -36, -36, -36, -36, -36, -36, -35, -35, -35, -35, -35,
				-35, -35, -35, -34, -34, -34, -33, -33, -33, -33, -32, -32, -32, -31, -31, -31,
				-30, -30, -30, -29, -29, -28, -28, -28, -27, -27, -26, -26, -25, -25, -24, -24,
				-23, -23, -22, -22, -21, -21, -20, -19, -19, -18, -18, -17, -16, -16, -15, -14,
				-14, -13, -12, -11, -11, -10,  -9,  -8,  -7,  -7,  -6,  -5,  -4,  -3,  -2,  -1,
				 0,   1,    2,   3,   4,   5,   6,   7,   8,   8,   9,  10,  10,  11,  12,  13,
				 13,  14,  14,  15,  15,  16,  16,  17,  17,  18,  18,  19,  19,  20,  20,  21,
				 21,  22,  22,  23,  23,  24,  24,  24,  25,  25,  25,  25,  26,  26,  26,  26,
				 27,  27,  27,  27,  28,  28,  28,  28,  28,  28,  29,  29,  29,  29,  29,  29,
				 29,  30,  30,  30,  30,  30,  30,  30,  31,  31,  31,  31,  31,  31,  31,  31,
				 31,  31,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,
				 32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32,  32
			};
			
			BitmapBits bitmap = new BitmapBits(385, 70);
			for (int i = 0; i < 384; i++)
			{
				bitmap.SafeSetPixel(6, i, offsetTable[i] + 37); // LevelData.ColorWhite
			}
			debug = new Sprite(bitmap, -192, -32);
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
		
		public override Sprite GetDebugOverlay(ObjectEntry obj)
		{
			return debug;
		}
	}
}