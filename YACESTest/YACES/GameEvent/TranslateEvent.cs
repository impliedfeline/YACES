using System;
using Microsoft.Xna.Framework;

namespace YACESTest
{
	public class TranslateEvent : GameEvent
	{
		private Vector2 translation;

		public TranslateEvent (Vector2 translation) {
			this.HashID = "TRANSLATE";
			this.translation = translation;
		}
	}
}

