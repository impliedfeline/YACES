﻿using System;
using YACES;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
	public class TitleBanner : GameObject
	{
		public static Texture2D Sprite { get; set; }

		public TitleBanner (Transform transform) : base (transform)
		{
			AddGameComponent (new Render2D (Sprite, 0));
		}
	}
}

