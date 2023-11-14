using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class YouWin : NetworkBehaviour
{
    private bool sceneActivated = false;
    public string playerWinName;

    void Update()
    {
        if (sceneActivated)
        {
            Debug.Log("The winner is" + playerWinName);
        }
    }

    // Este método se llama cuando un objeto entra en el colisionador
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("" + other.gameObject.name);
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

        //TODO: obtener el nombre del jugador de SyncVars y asignarlo a this.playerWinName
        

    }

    // [ClientRpc]
    // private void RpcLoadSceneWin()
    // {
    //     // Carga la escena "Win" en todos los clientes
    //     SceneManager.LoadScene("WinScene");
    // }

    // [ClientRpc]
    // private void RpcLoadSceneLose()
    // {
    //     // Carga la escena "Lose" en todos los clientes excepto en el que activó la escena
    //     if (!isLocalPlayer && !isServer)
    //     {
    //         SceneManager.LoadScene("LoseScene");
    //     }
    // }
}