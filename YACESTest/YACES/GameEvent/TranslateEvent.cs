using System;
using Microsoft.Xna.Framework;

namespace YACESTest
{
	public class TranslateEvent : GameEvent
	{
		private static readonly string TRANSLATE_EVENT_ID = "TRANSLATE";
		public override string HashID { get { return TRANSLATE_EVENT_ID; } }
		public Vector2 Translation { get; private set; }

		public TranslateEvent (Vector2 translation) {
			this.Translation = translation;
		}
	}
}

