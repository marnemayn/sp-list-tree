using System.Web.UI;
using Microsoft.SharePoint;

namespace SPHierarchyBase
{
	public class SharePointListHierarchyData : IHierarchyData
	{
		private readonly SPListItem _item;

		public SharePointListHierarchyData(SPListItem item)
		{
			_item = item;
		}

		public IHierarchicalEnumerable GetChildren()
		{
			SharePointListHierarchicalEnumerable children = new SharePointListHierarchicalEnumerable();
			var allitems = GetChildItems();
			if (allitems != null)
			{
				foreach (SPListItem spListItem in allitems)
				{
					children.Add(new SharePointListHierarchyData(spListItem));
				}
			}
			return children;

		}

		private SPListItemCollection GetChildItems()
		{
			if (_item.Folder != null)
			{
				SPQuery query = new SPQuery
				{
					Folder = _item.Folder,
				};

				SPListItemCollection allitems = _item.ParentList.GetItems(query);
				return allitems;
			}
			return null;
		}


		public IHierarchyData GetParent()
		{
			return new SharePointListHierarchyData(_item.GetParentFolder().Item);
		}

		public bool HasChildren
		{
			get
			{
				var spListItemCollection = GetChildItems();
				if (spListItemCollection != null)
				{
					return spListItemCollection.Count > 0;
				}
				return false;
			}
		}

		public override string ToString()
		{
			return _item.Title;
		}

		public string Path
		{
			get
			{
				return _item.Folder == null ? _item.GetDisplayUrl() : string.Empty;
			}
		}

		public object Item { get { return _item; } }
		public string Type { get { return "SharePointListHierarchyData"; } }
		public string Title { get { return string.IsNullOrWhiteSpace(_item.Title) ? "No title" : _item.Title; } }

		public string ImageUrl
		{
			get
			{
				var url = _item.Folder != null ? "/_layouts/15/images/openfold.gif" : "/_layouts/15/images/NMW16.gif";
				url = _item.Web.Url + url;
				return url;
			}
		}
	}
}