using System;
using System.Linq;
using System.Collections.Generic;

namespace YACESTest
{
	public class GameObjectMap
	{
		private Dictionary<uint,GameObject> gameObjectsByID;
		private Dictionary<Aspect,HashSet<GameObject>> gameObjectsByAspect;
		private Dictionary<Type,List<GameObject>> gameObjectsByType;

		public GameObjectMap ()
		{
			gameObjectsByID = new Dictionary<uint,GameObject> ();
			gameObjectsByAspect = new Dictionary<Aspect,HashSet<GameObject>> ();
			gameObjectsByType = new Dictionary<Type,List<GameObject>> ();
		}

		public List<GameObject> GetGameObjectsByAspect (Aspect aspect)
		{
			List<GameObject> gameObjects = new List<GameObject> ();
			foreach (Aspect item in gameObjectsByAspect.Keys) {
				if (aspect.IsSubsetOf (item))
					gameObjects.AddRange (gameObjectsByAspect [item]);
			}
			return gameObjects;
		}

		public GameObject GetGameObjectByID (uint id)
		{
			return gameObjectsByID [id];
		}

		public List<T> GetGameObjectsByType<T> () where T : GameObject
		{
			if (!gameObjectsByType.ContainsKey (typeof(T))) {
				return null;
			}
			return gameObjectsByType [typeof(T)].Cast<T> ().ToList ();
		}

		public void AddGameObject<T> (T gameObject) where T : GameObject
		{
			if (!gameObjectsByAspect.ContainsKey (gameObject.Aspect)) {
				gameObjectsByAspect.Add (gameObject.Aspect, new HashSet<GameObject> ());
			}
			if (!gameObjectsByType.ContainsKey (typeof(T))) {
				gameObjectsByType.Add (typeof(T), new List<GameObject> ());
			}
			gameObjectsByID.Add (gameObject.ID, gameObject);
			gameObjectsByAspect [gameObject.Aspect].Add (gameObject);
			gameObjectsByType [typeof(T)].Add (gameObject);
		}

		public void RemoveGameObject<T> (T gameObject) where T : GameObject
		{
			if (!gameObjectsByID.ContainsKey (gameObject.ID)) {
				return;
			}
			gameObjectsByID.Remove (gameObject.ID);
			gameObjectsByAspect [gameObject.Aspect].Remove (gameObject);
			gameObjectsByType [typeof(T)].Remove (gameObject);
		}
	}
}
