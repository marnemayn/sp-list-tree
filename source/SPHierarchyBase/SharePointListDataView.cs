using System.Web.UI;
using Microsoft.SharePoint;

namespace SPHierarchyBase
{
	public class SharePointListDataView : HierarchicalDataSourceView
	{
		private string _viewPath;
		private SPList _list;
		private SPFolder _startingFolder;

		public SharePointListDataView(SPList list, string viewPath)
		{
			_list = list;
			_viewPath = viewPath;
		}

		public override IHierarchicalEnumerable Select()
		{
			_startingFolder = string.IsNullOrWhiteSpace(_viewPath) ? _list.RootFolder : _list.ParentWeb.GetFolder(_viewPath);
			SharePointListHierarchicalEnumerable splhi = new SharePointListHierarchicalEnumerable();
			SPQuery query = new SPQuery
			{
				Folder = _startingFolder
			};
			var spListItemCollection = _list.GetItems(query);
			foreach (SPListItem spListItem in spListItemCollection)
			{
				splhi.Add(new SharePointListHierarchyData(spListItem));
			}
			return splhi;
		}
	}
}