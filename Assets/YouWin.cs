using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Mirror;

public class YouWin : NetworkBehaviour
{
    private bool sceneActivated = false;
    public string playerWinName;

    // void Update()
    // {
    //     if (sceneActivated)
    //     {
    //         Debug.Log("The winner is" + playerWinName);
    //     }
    // }

    // Este método se llama cuando un objeto entra en el colisionador
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si este script se está ejecutando en el servidor y si es el jugador local
        if (!isServer)
            return;

        // Asegúrate de que el objeto que está chocando tiene un componente NetworkIdentity
        NetworkIdentity otherNetworkIdentity = other.GetComponent<NetworkIdentity>();
        if (otherNetworkIdentity == null)
            return;

        if (sceneActivated || !other.CompareTag("Player"))
            return;

        // Marca la escena como activada para evitar que otros clientes la activen
        sceneActivated = true;

        Debug.Log("" + otherNetworkIdentity.netId);

        var connections = NetworkServer.connections;

        foreach (var connection in connections.Values)
        {
            if (connection.identity != null)
            {
                // Accede al componente SyncVars y actualiza el nombre del jugador
                var component = connection.identity.GetComponent<SyncVars>();
                if (component != null)
                {
                    if (otherNetworkIdentity.netId == connection.identity.netId)
                    {
                        component.SetPlayerName("Ganaste Capo!");
                         StartCoroutine(CountdownThenGoToFirstSceneRoutine());
                    }
                    else
                    {
                        component.SetPlayerName("Perdiste!");
                    }

                }
            }
        }

    }


    IEnumerator CountdownThenGoToFirstSceneRoutine() {
        yield return new WaitForSeconds(5f);
        //TODO: destroy this gameobject
        RpcLoadSceneInit();
    }

    // [ClientRpc]
    // private void TargetRpcLoadSceneWin()
    // {
    //     // Carga la escena "Win" en todos los clientes
    //     SceneManager.LoadScene("WinScene");
    // }

    [ClientRpc]
    private void RpcLoadSceneInit()
    {
        SceneManager.LoadScene("IntroMenu 1");
    }
}