using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace YACES
{
	/// <summary>
	/// An abstract base class for GameObjects.
	/// When defining their own GameObjects, the end user should derive from this class.
	/// </summary>
	public abstract class GameObject
	{
		/// <summary>
		/// Gets or sets the parent GameObject.
		/// </summary>
		/// <value>The parent GameObject.</value>
		public GameObject Parent { get; set; }

		/// <summary>
		/// Gets the children GameObjects.
		/// </summary>
		/// <value>The children GameObjects.</value>
		public HashSet<GameObject> Children { get; private set; }

		private Dictionary<Type, List<GameComponent>> gameComponents;

		/// <summary>
		/// Gets the Aspect of the GameObject, containing the types of GameComponents
		/// that the GameObject consists of.
		/// </summary>
		/// <value>The aspect.</value>
		public Aspect Aspect { get; private set; }

		/// <summary>
		/// Gets the transform.
		/// </summary>
		/// <value>The transform.</value>
		public Transform Transform { get; private set; }

		/// <summary>
		/// Gets the unique GameObject ID.
		/// </summary>
		/// <value>The ID.</value>
		public uint ID { get; private set; }

		/// <summary>
		/// Gets the counter. (The total number of instantiated GameObjects)
		/// </summary>
		/// <value>The counter.</value>
		public static uint Counter { get; private set; }

		/// <summary>
		/// Initializes a new GameObject.
		/// </summary>
		/// <param name="transform">Transform.</param>
		public GameObject (Transform transform)
		{
			this.Children = new HashSet<GameObject> ();
			this.gameComponents = new Dictionary<Type, List<GameComponent>> ();
			this.Aspect = new Aspect ();
			this.Transform = transform;
			this.Transform.GameObject = this;
			ID = ++Counter;
		}

		/// <summary>
		/// Adds a new GameComponent to the GameObject.
		/// </summary>
		/// <param name="gameComponent">Game component.</param>
		public void AddGameComponent (GameComponent gameComponent)
		{
			if (!gameComponents.ContainsKey (gameComponent.GetType ())) {
				gameComponents [gameComponent.GetType ()] = new List<GameComponent> ();
			}
			gameComponent.GameObject = this;
			gameComponents [gameComponent.GetType ()].Add (gameComponent);
			Aspect.AddType (gameComponent.GetType ());
		}

		/// <summary>
		/// Removes a specified GameComponent from the GameObject.
		/// </summary>
		/// <param name="gameComponent">Game component.</param>
		public void RemoveGameComponent (GameComponent gameComponent)
		{
			if (!gameComponents.ContainsKey (gameComponent.GetType ()) || !gameComponents [gameComponent.GetType ()].Contains (gameComponent)) {
				return;
			}

			gameComponents [gameComponent.GetType ()].Remove (gameComponent);
			if (!gameComponents [gameComponent.GetType ()].Any ()) {
				Aspect.RemoveType (gameComponent.GetType ());
			}
		}

		/// <summary>
		/// Returns a readonly-list of GameComponents of a specified type contained in the GameObject.
		/// </summary>
		/// <returns>The game components by type.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public IReadOnlyList<T> GetGameComponentsByType<T> () where T : GameComponent
		{
			return gameComponents [typeof(T)].Cast<T> ().ToList ();
		}

		/// <summary>
		/// Attach this GameObject as a child to a given parent GameObject.
		/// </summary>
		/// <param name="parent">Parent.</param>
		public void AttachTo (GameObject parent)
		{
			this.Parent = parent;
			parent.Children.Add (this);
		}

		/// <summary>
		/// Detaches this GameObject from it's parent.
		/// </summary>
		public void DetachFromParent ()
		{
			Parent.Children.Remove (this);
			this.Parent = null;
		}
	}
}

