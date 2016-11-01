using System.Web.UI;
using Microsoft.SharePoint;

namespace SPHierarchyBase
{
	public class SharePointListDataSource : HierarchicalDataSourceControl
	{
		private SharePointListDataView _view = null;
		private SPList _list;

		public SPList List
		{
			get { return _list; }
			set
			{
				if (value == null)
				{
					throw new SPException("Data source needs a list.");
				}
				_list = value;
			}
		}

		public SharePointListDataSource() { }

		public SharePointListDataSource(SPList list)
		{
			_list = list;
		}

		protected override HierarchicalDataSourceView GetHierarchicalView(string viewPath)
		{
			_view = new SharePointListDataView(List, viewPath);
			return _view;
		}

	}
}