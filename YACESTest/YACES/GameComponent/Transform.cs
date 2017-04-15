using System;
using Microsoft.Xna.Framework;

namespace YACESTest
{
	public class Transform : GameComponent
	{
		private readonly static string[] TRANSFORM_EVENTS = { "TRANSLATE" };
		public override string[] EventHashIDs { get { return TRANSFORM_EVENTS; } }
		private Vector2 transform;

		public Transform (Vector2 transform) {
			this.transform = transform;
		}

		public override GameEvent OnEvent (GameEvent ge) {
			if (ge is TranslateEvent) {
				TranslateEvent te = (TranslateEvent) ge;
				transform += te.Translation;
			}
			return null;
		}
	}
}

