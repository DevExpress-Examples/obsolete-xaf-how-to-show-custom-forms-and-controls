using System;
using System.Data;
using DevExpress.Xpo.DB;

namespace Demo {
    #region For demo purposes only!!!
    public class CodeCentralExampleInMemoryDataStoreProvider {
        private static readonly string fConnectionString;
        private static readonly DataSet fdataSet;
        public static string ConnectionString { get { return fConnectionString; } }
        static CodeCentralExampleInMemoryDataStoreProvider() {
            string providerKey = Guid.NewGuid().ToString();
            fConnectionString = String.Format("XpoProvider={0}", providerKey);
            fdataSet = new DataSet();
            DataStoreBase.RegisterDataStoreProvider(providerKey, CreateProviderFromString);
        }
        public static IDataStore CreateProviderFromString(string connectionString, AutoCreateOption autoCreateOption, out IDisposable[] objectsToDisposeOnDisconnect) {
            objectsToDisposeOnDisconnect = new IDisposable[] { };
            return new DataSetDataStore(fdataSet, autoCreateOption);
        }
    }
    public class DataHelper {
        public static DataTable GetData() {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Product", typeof(string));
            dt.Columns.Add("Price", typeof(float));
            dt.Columns.Add("Quantity", typeof(float));
            dt.Rows.Add(new object[] { 0, "Beverages", "Chai", 1.6, 319 });
            dt.Rows.Add(new object[] { 1, "Beverages", "Chai", 6295.5, 399 });
            dt.Rows.Add(new object[] { 2, "Beverages", "Ipoh Coffee", 10034.9, 228 });
            dt.Rows.Add(new object[] { 3, "Confections", "Chocolade", 1282.1, 130 });
            dt.Rows.Add(new object[] { 4, "Confections", "Chocolade", 86.7, 8 });
            dt.Rows.Add(new object[] { 5, "Confections", "Scottish Longbreads", 3909.0, 380 });
            return dt;
        }
    }
    #endregion
}