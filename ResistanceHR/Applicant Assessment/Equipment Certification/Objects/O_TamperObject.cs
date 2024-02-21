using System.Collections.Generic;

namespace RHR.Tampering
{
	public abstract class O_TamperObject
	{
		public abstract List<string> ObjectTypes { get; }
		public abstract List<string> UsableItems { get; }
	}
}