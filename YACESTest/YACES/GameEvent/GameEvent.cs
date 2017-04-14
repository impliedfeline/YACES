using System;

namespace YACESTest
{
	public abstract class GameEvent
	{
		// public int Priority { get; set; } Do I need this?
		public string HashID { get; protected set; }

		public GameEvent () {
		}
	}
}

