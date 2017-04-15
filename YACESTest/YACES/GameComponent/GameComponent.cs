using System;

namespace YACESTest
{
	public abstract class GameComponent
	{
		public abstract string[] EventHashIDs { get; }
		public abstract GameEvent OnEvent(GameEvent ge);
	}
}

