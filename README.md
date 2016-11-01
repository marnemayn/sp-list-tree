# sp-list-tree
A way to use the ASP.NET TreeView control with SharePoint 2013

The SPHierarchBase project enables you to give a SharePoint list as datasource for a standard ASP.NET TreeView control.
The datasource is read-only, so it can only be used for representation of data. "Why?", you ask. Because the datasource control inherits the 
HierarchicalDataSourceControl which in turn relies on the HierarchicalDataSourceView class which "does not currently support Insert, Update or Delete operations".
See https://msdn.microsoft.com/en-us/library/system.web.ui.hierarchicaldatasourceview(v=vs.110).aspx for documentation.
While on the subject of documentation, the implementation is based on the example given in this article on MSDN:
https://msdn.microsoft.com/en-us/library/system.web.ui.hierarchicaldatasourcecontrol(v=vs.110).aspx
 
I've implemented a sample web part that can be used, but I strongly suggest that you roll your own.
