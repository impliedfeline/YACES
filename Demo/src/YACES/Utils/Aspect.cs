using System;
using System.Linq;
using System.Collections.Generic;

namespace YACES
{
	/// <summary>
	/// Wrapper class for a set of types.
	/// The GameMap utilizes this for mapping gameObjects by their contained components.
	/// New GameObjects store the types of their GameComponents as their Aspect.
	/// Thus, the user may fetch GameObjects from the GameMap by a combination of GameComponents,
	/// defines as an Aspect.
	/// </summary>
	public class Aspect
	{
		private HashSet<Type> types;

		public Aspect ()
		{
			types = new HashSet<Type> ();
		}

		public Aspect (params Type[] ts)
		{
			types = new HashSet<Type> ();
			foreach (Type t in ts) {
				types.Add (t);
			}
		}

		public bool IsSubsetOf (Aspect that)
		{
			return this.types.IsSubsetOf (that.types);
		}

		public void AddType (Type t)
		{
			types.Add (t);
		}

		public void RemoveType (Type t)
		{
			types.Remove (t);
		}

		public override bool Equals (object obj)
		{
			Aspect that = obj as Aspect;
			if (that == null)
				return false;
			return this.types.SetEquals (that.types);
		}

		public override int GetHashCode ()
		{
			int hashCode = 0;
			foreach (Type t in types)
				hashCode ^= t.GetHashCode ();
			return hashCode;
		}
	}
}

