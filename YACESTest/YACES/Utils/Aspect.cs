using System;
using System.Linq;
using System.Collections.Generic;

namespace YACESTest
{
	public class Aspect
	{
		private HashSet<Type> types;

		public Aspect ()
		{
			types = new HashSet<Type> ();
		}

		public Aspect (ICollection<Type> types)
		{
			this.types = new HashSet<Type> ();
			foreach (Type t in types) {
				this.types.Add (t);
			}
		}

		public Aspect (Type t)
		{
			types = new HashSet<Type> ();
			types.Add (t);
		}

		public bool IsSubsetOf (Aspect that)
		{
			return this.types.IsSubsetOf (that.types);
		}

		public void AddType<T> ()
		{
			types.Add (typeof(T));
		}

		public void RemoveType<T> ()
		{
			types.Remove (typeof(T));
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

