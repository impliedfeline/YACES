using System;
using Microsoft.Xna.Framework;

namespace YACESTest
{
	public class Transform : GameComponent
	{
		private Vector2 transform;

		public Transform (Vector2 transform) {
			this.EventHashIDs = new int[1];
			this.EventHashIDs [0] = "TRANSLATE";
			this.transform = transform;
		}

		public void OnEvent (TranslateEvent e) {

		}
	}
}

