using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SyncVars : NetworkBehaviour
{
    [SyncVar]
    [SerializeField] private string PlayerName;

    [Server]
    public void SetPlayerName(string name)
    {
        this.PlayerName = name;
    }
}
