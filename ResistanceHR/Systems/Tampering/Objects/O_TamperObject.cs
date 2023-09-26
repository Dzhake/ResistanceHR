using System.Collections.Generic;

namespace ResistanceHR.Tampering
{
	internal abstract class O_TamperObject
	{
		internal abstract List<string> ObjectTypes { get; }
		internal abstract List<string> UsableItems { get; }
	}
}