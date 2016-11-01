using System;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using SPHierarchyBase;

namespace SPListTreeView.Webparts.SPListTreeViewWebPart
{
	[ToolboxItemAttribute(false)]
	public partial class SPListTreeViewWebPart : WebPart
	{
		// Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
		// using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
		// for production. Because the SecurityPermission attribute bypasses the security check for callers of
		// your constructor, it's not recommended for production purposes.
		// [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
		public SPListTreeViewWebPart()
		{
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			InitializeControl();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			SPList list = SPContext.Current.Web.Lists["Dokumenter"];
			var datasource = new SharePointListDataSource(list);
			lblTitle.Text = list.Title;
			theTree.DataSource = datasource;
			theTree.DataBindings.Add(new TreeNodeBinding() { ImageUrlField = "ImageUrl", NavigateUrlField = "Path", TextField = "Title"});
			theTree.DataBind();
		}
	}
}
