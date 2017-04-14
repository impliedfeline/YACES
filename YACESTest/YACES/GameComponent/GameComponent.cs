using System;

namespace YACESTest
{
	public abstract class GameComponent
	{
		public string[] EventHashIDs { get; protected set; }

		public GameComponent () {
		}

		public abstract void OnEvent(GameEvent e);
	}
}

