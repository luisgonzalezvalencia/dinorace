using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class SyncVars : NetworkBehaviour
{

    [SerializeField] private TextMeshPro nameText;
    [SerializeField] private Renderer renderMaterial;

    [SyncVar(hook = nameof(WhenPlayerNameChange))]
    [SerializeField] private string PlayerName;

    [Server]
    public void SetPlayerName(string name)
    {
        this.PlayerName = name;
    }

    private void WhenPlayerNameChange(string oldName, string newName){
       nameText.text = newName;
    }
}
