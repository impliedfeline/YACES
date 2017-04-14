using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace YACESTest
{
	public class GameObjectRuntime
	{
		private List<GameSystem> gameSystems;

		public GameObjectRuntime () {
			gameSystems = new List<GameSystem> ();
		}

		public void AddSystem (GameSystem gs) {
			gameSystems.Add (gs);
		}

		public void Initialize () {
			gameSystems.Sort ();
		}
		
		public void Update (GameTime gameTime) {

		}
	}
}