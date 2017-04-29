using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace YACES
{
	/// <summary>
	/// An abstract base class for GameSystems.
	/// When defining GameSystems for use in your games, derive from this base class.
	/// </summary>
	public abstract class GameSystem : IComparable<GameSystem>
	{
		public static readonly int LAST = Int32.MaxValue;
		public static readonly int FIRST = Int32.MinValue;

		/// <summary>
		/// Gets or sets the priority in the Update-phase in the game loop.
		/// </summary>
		/// <value>The priority.</value>
		public int Priority { get; protected set; }

		public GameSystem ()
		{
			this.Priority = FIRST;
		}

		public GameSystem (int priority)
		{
			this.Priority = priority;
		}

		public int CompareTo (GameSystem that)
		{
			return this.Priority - that.Priority;
		}

		/// <summary>
		/// Each GameSystem in the current scene is run as part of the Update-phase
		/// as defined in the GameRuntime.
		/// The end user should define their GameSystem-specific routines here.
		/// </summary>
		/// <param name="gameInstance">Game instance.</param>
		/// <param name="gameTime">Game time.</param>
		public abstract void Run (GameInstance gameInstance, GameTime gameTime);
	}
}

