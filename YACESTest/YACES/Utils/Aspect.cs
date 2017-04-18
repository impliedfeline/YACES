using System;
using System.Collections.Generic;

namespace YACESTest
{
	public class Aspect
	{
		private HashSet<Type> types;

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

		public bool SubsetOf (Aspect that)
		{
			bool flag = true;
			foreach (Type t in types) {
				if (!that.types.Contains (t))
					flag = false;
			}
			return flag;
		}
	}
}

