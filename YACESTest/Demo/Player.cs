﻿using System;

using Microsoft.Xna.Framework.Graphics;

namespace YACES
{
	public class Player : GameObject
	{
		public static Texture2D Sprite { get; set; }

		public Player (Transform transform) : base (transform)
		{
			AddGameComponent (new Render2D (Sprite, 0));
		}
	}
}

