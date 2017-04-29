using System;

namespace YACES
{
	/// <summary>
	/// An abstract base class for GameComponents.
	/// </summary>
	public abstract class GameComponent
	{
		/// <summary>
		/// Gets or sets the game object.
		/// </summary>
		/// <value>The game object.</value>
		public GameObject GameObject { get; set; }
	}
}

