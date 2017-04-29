using System;
using System.Collections.Generic;

namespace YACES
{
	public class GameSystemSortedSet
	{

		private List<GameSystem> gameSystems;
		private Dictionary<Type, GameSystem> gameSystemsDict;

		public IReadOnlyList<GameSystem> GameSystemSortedList {
			get { return gameSystems; }
		}

		public IReadOnlyDictionary<Type,GameSystem> GameSystemsDict {
			get { return gameSystemsDict; }
		}

		public GameSystemSortedSet ()
		{
			this.gameSystems = new List<GameSystem> ();
			this.gameSystemsDict = new Dictionary<Type, GameSystem> ();
		}

		public void AddGameSystem (GameSystem gameSystem)
		{
			if (!gameSystemsDict.ContainsKey (gameSystem.GetType ())) {
				gameSystems.Add (gameSystem);
				gameSystems.Sort ();
				gameSystemsDict.Add (gameSystem.GetType (), gameSystem);
			}
		}

		public void RemoveGameSystem<T> () where T : GameSystem
		{
			if (gameSystemsDict.ContainsKey (typeof(T))) {
				gameSystems.Remove (gameSystemsDict [typeof(T)]);
				gameSystems.Sort ();
				gameSystemsDict.Remove (typeof(T));
			}
		}

		public T GetGameSystem<T> () where T : GameSystem
		{
			if (gameSystemsDict.ContainsKey (typeof(T))) {
				return gameSystemsDict [typeof(T)] as T;
			}
			return null;
		}
	}
}

