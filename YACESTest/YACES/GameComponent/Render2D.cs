using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YACES
{
	public class Render2D : Render
	{
		public Texture2D Sprite { get; set; }

		public byte Layer { get; set; }

		public Render2D (Texture2D sprite, byte layer)
		{
			this.Sprite = sprite;
			this.Layer = layer;
		}
	}
}

