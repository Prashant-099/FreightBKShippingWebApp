using DevExpress.DataAccess.Json;
using DevExpress.DataAccess.Web;
using DevExpress.DataAccess.Wizard.Services;

public class CustomDataSourceWizardJsonDataConnectionStorage : IDataSourceWizardJsonConnectionStorage
{
    public static JsonDataConnection GetDefaultConnection()
    {
        var uriJsonSource = new UriJsonSource()
        {
            Uri = new Uri(@"https://raw.githubusercontent.com/DevExpress-Examples/DataSources/master/JSON/customers.json"),
        };
        return new JsonDataConnection(uriJsonSource) { StoreConnectionNameOnly = true, Name = "JsonConnection1" };
    }
    public static List<JsonDataConnection> GetConnections()
    {
        var connections = new List<JsonDataConnection> {
                GetDefaultConnection()
            };
        return connections;
    }

    bool IJsonConnectionStorageService.CanSaveConnection => false;
    bool IJsonConnectionStorageService.ContainsConnection(string connectionName)
    {
        return GetConnections().Any(x => x.Name == connectionName);
    }

    IEnumerable<JsonDataConnection> IJsonConnectionStorageService.GetConnections()
    {
        return GetConnections();
    }

    JsonDataConnection IJsonDataConnectionProviderService.GetJsonDataConnection(string name)
    {
        var connection = GetConnections().FirstOrDefault(x => x.Name == name);
        if (connection == null)
            throw new InvalidOperationException();
        return connection;
    }

    void IJsonConnectionStorageService.SaveConnection(string connectionName, JsonDataConnection connection, bool saveCredentials) { }
}