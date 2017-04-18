using System;
using System.Collections.Generic;

namespace YACESTest
{
	public static class BlockFactory
	{
		public static GameObject CreateBlock (Transform2D transform, Render2D render)
		{
			Dictionary<Type, List<GameComponent>> dict = new Dictionary<Type, List<GameComponent>> ();

			List<GameComponent> listT = new List<GameComponent> ();
			listT.Add (transform);
			dict [typeof(Transform2D)] = listT;

			List<GameComponent> listR = new List<GameComponent> ();
			listR.Add (render);
			dict [typeof(Render2D)] = listR;

			List<Type> listA = new List<Type> ();
			listA.Add (typeof(Transform2D));
			listA.Add (typeof(Render2D));
			Aspect aspect = new Aspect (listA);

			return new GameObject (dict, aspect);
		}
	}
}

