Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports DevExpress.Xpo.DB

Namespace Demo
	#Region "For demo purposes only!!!"
	Public Class CodeCentralExampleInMemoryDataStoreProvider
		Private Shared ReadOnly fConnectionString As String
		Private Shared ReadOnly fdataSet As DataSet
		Public Shared ReadOnly Property ConnectionString() As String
			Get
				Return fConnectionString
			End Get
		End Property
		Shared Sub New()
			Dim providerKey As String = Guid.NewGuid().ToString()
			fConnectionString = String.Format("XpoProvider={0}", providerKey)
			fdataSet = New DataSet()
			DataStoreBase.RegisterDataStoreProvider(providerKey, AddressOf CreateProviderFromString)
		End Sub
		Public Shared Function CreateProviderFromString(ByVal connectionString As String, ByVal autoCreateOption As AutoCreateOption, <System.Runtime.InteropServices.Out()> ByRef objectsToDisposeOnDisconnect() As IDisposable) As IDataStore
			objectsToDisposeOnDisconnect = New IDisposable() { }
			Return New DataSetDataStore(fdataSet, autoCreateOption)
		End Function
	End Class
	Public Class DataHelper
		Public Shared Function GetData() As DataTable
			Dim dt As New DataTable()
			dt.Columns.Add("ID", GetType(Integer))
			dt.Columns.Add("Category", GetType(String))
			dt.Columns.Add("Product", GetType(String))
			dt.Columns.Add("Price", GetType(Single))
			dt.Columns.Add("Quantity", GetType(Single))
			dt.Rows.Add(New Object() { 0, "Beverages", "Chai", 1.6, 319 })
			dt.Rows.Add(New Object() { 1, "Beverages", "Chai", 6295.5, 399 })
			dt.Rows.Add(New Object() { 2, "Beverages", "Ipoh Coffee", 10034.9, 228 })
			dt.Rows.Add(New Object() { 3, "Confections", "Chocolade", 1282.1, 130 })
			dt.Rows.Add(New Object() { 4, "Confections", "Chocolade", 86.7, 8 })
			dt.Rows.Add(New Object() { 5, "Confections", "Scottish Longbreads", 3909.0, 380 })
			Return dt
		End Function
	End Class
	#End Region
End Namespace