using System;
using System.Linq;
using System.Collections.Generic;

namespace YACES
{
	public class GameObjectMap
	{
		private Dictionary<uint,GameObject> gameObjectsByID;

		private Dictionary<Aspect,HashSet<GameObject>> gameObjectsByAspect;

		private Dictionary<Type,HashSet<GameObject>> gameObjectsByType;

		public GameObjectMap ()
		{
			gameObjectsByID = new Dictionary<uint,GameObject> ();
			gameObjectsByAspect = new Dictionary<Aspect,HashSet<GameObject>> ();
			gameObjectsByType = new Dictionary<Type,HashSet<GameObject>> ();
		}

		/// <summary>
		/// Returns a readonly-list of GameObjects by Aspect.
		/// </summary>
		/// <returns>The game objects by aspect.</returns>
		/// <param name="aspect">Aspect.</param>
		public IReadOnlyList<GameObject> GetGameObjectsByAspect (Aspect aspect)
		{
			List<GameObject> gameObjects = new List<GameObject> ();
			foreach (Aspect item in gameObjectsByAspect.Keys) {
				if (aspect.IsSubsetOf (item)) {
					gameObjects.AddRange (gameObjectsByAspect [item]);
				}
			}

			return gameObjects.AsReadOnly ();
		}

		/// <summary>
		/// Return a readonly-list of GameObjects by contained GameComponents.
		/// </summary>
		/// <returns>The game objects by component.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public IReadOnlyList<GameObject> GetGameObjectsByComponent<T> () where T : GameComponent
		{
			Aspect aspect = new Aspect (typeof(T));
			List<GameObject> gameObjects = new List<GameObject> ();
			foreach (Aspect item in gameObjectsByAspect.Keys) {
				if (aspect.IsSubsetOf (item)) {
					gameObjects.AddRange (gameObjectsByAspect [item]);
				}
			}
			return gameObjects.AsReadOnly ();
		}

		/// <summary>
		/// Returns a GameObject by it's unique ID.
		/// </summary>
		/// <returns>The game object by ID.</returns>
		/// <param name="id">Identifier.</param>
		public GameObject GetGameObjectByID (uint id)
		{
			return gameObjectsByID [id];
		}

		/// <summary>
		/// Returns a readonly-list of GameObjects by type.
		/// </summary>
		/// <returns>The game objects by type.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public IReadOnlyList<T> GetGameObjectsByType<T> () where T : GameObject
		{
			if (!gameObjectsByType.ContainsKey (typeof(T))) {
				return new List<T> ();
			}
			return gameObjectsByType [typeof(T)].Cast<T> ().ToList ().AsReadOnly ();
		}

		/// <summary>
		/// Adds a new GameObject to the GameMap.
		/// </summary>
		/// <param name="go">Go.</param>
		public void AddGameObject (GameObject go)
		{
			if (!gameObjectsByAspect.ContainsKey (go.Aspect)) {
				gameObjectsByAspect.Add (go.Aspect, new HashSet<GameObject> ());
			}
			if (!gameObjectsByType.ContainsKey (go.GetType ())) {
				gameObjectsByType.Add (go.GetType (), new HashSet<GameObject> ());
			}
			gameObjectsByID.Add (go.ID, go);
			gameObjectsByAspect [go.Aspect].Add (go);
			gameObjectsByType [go.GetType ()].Add (go);
		}

		/// <summary>
		/// Removes a GameObject from the GameMap.
		/// </summary>
		/// <param name="go">Go.</param>
		public void RemoveGameObject (GameObject go)
		{
			if (!gameObjectsByID.ContainsKey (go.ID)) {
				return;
			}
			gameObjectsByID.Remove (go.ID);
			gameObjectsByAspect [go.Aspect].Remove (go);
			gameObjectsByType [go.GetType ()].Remove (go);
		}
	}
}
