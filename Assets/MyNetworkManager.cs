using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkRoomManager
{

    public override void OnClientConnect()
    {

        base.OnClientConnect();
        Debug.Log("Me conecte al servidor " + numPlayers);

    }

    public override void OnRoomClientSceneChanged()
    {
        base.OnRoomClientSceneChanged();
        Debug.Log("Scene changed");
        // Obtén una lista de las conexiones de clientes
        var connections = NetworkServer.connections;
        var i = 1;
        foreach (var connection in connections.Values)
        {
            if (connection.identity != null)
            {
                // Accede al componente SyncVars y actualiza el nombre del jugador
                var component = connection.identity.GetComponent<SyncVars>();
                if (component != null)
                {
                    component.SetPlayerName("Dinosaurito " + i);
                    Debug.Log("Nombre Dinosaurito actualizado para " + connection.identity.name);
                    i += 1;
                }
            }
        }
    }

    public override void OnServerSceneChanged(string sceneName)
    {
        base.OnServerSceneChanged(sceneName);

        // Obtén una lista de las conexiones de clientes
        var connections = NetworkServer.connections;

        foreach (var connection in connections.Values)
        {
            if (connection.identity != null)
            {
                // Accede al componente SyncVars y actualiza el nombre del jugador
                var component = connection.identity.GetComponent<SyncVars>();
                if (component != null)
                {
                    component.SetPlayerName("Dinosaurito");
                    Debug.Log("Nombre Dinosaurito actualizado para " + connection.identity.name);
                }
            }
        }
    }


}
