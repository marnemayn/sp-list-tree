using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace SPHierarchyBase
{
	public static class Extensions
	{
		public static SPFolder GetParentFolder(this SPListItem item)
		{
			string dirPath = SPUtility.GetUrlDirectory(item.Url);
			return item.Web.GetFolder(dirPath);
		}

		public static string GetDisplayUrl(this SPListItem item)
		{
			string diplayForm = string.Concat(item.Web.Url, "/", item.ParentList.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url, "?id=", item.ID.ToString());
			return diplayForm;
		}

		public static string GetEditUrl(this SPListItem item, string source)
		{
			string editUrl = string.Format("{0}/{1}?ID={2}&Source={3}", item.Web.Url,
					item.ParentList.Forms[PAGETYPE.PAGE_EDITFORM].Url, item.ID.ToString(), source);
			return editUrl;
		}

		public static bool MoveToFolder(this SPListItem item, SPListItem destinationItem)
		{
			string destPath = destinationItem.Folder != null ? destinationItem.Url : destinationItem.GetParentFolder().Url;
			SPFile file = item.Web.GetFile(item.Url);
			string NewDestinationUrl = file.Url.Replace(item.ID + "_.000", destPath + "/" + item.ID + "_.000");
			file.MoveTo(NewDestinationUrl);
			return true;
		}
	}
}