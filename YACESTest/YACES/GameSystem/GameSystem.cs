using System;

namespace YACESTest
{
	public abstract class GameSystem : IComparable<GameSystem>
	{
		public int Priority { get; protected set; }

		public GameSystem () {
		}

		public int CompareTo(GameSystem that) {
			return this.Priority - that.Priority;
		}
	}
}

