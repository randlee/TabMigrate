using System.Collections.Generic;

/// <summary>
/// Object Allows the setting of the Data Connections
/// </summary>
interface IEditDataConnectionsSet
{
    void SetDataConnections(IEnumerable<SiteConnection> connections);
}