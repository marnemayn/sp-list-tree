using System.Collections;
using System.Web.UI;

namespace SPHierarchyBase
{
	public class SharePointListHierarchicalEnumerable : ArrayList, IHierarchicalEnumerable
	{
		public IHierarchyData GetHierarchyData(object enumeratedItem)
		{
			return enumeratedItem as IHierarchyData;
		}
	}
}