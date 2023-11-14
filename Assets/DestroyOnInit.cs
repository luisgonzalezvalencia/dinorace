using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DestroyOnInit : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountdownThenStartRaceRoutine());
    }

     IEnumerator CountdownThenStartRaceRoutine() {
        yield return new WaitForSeconds(3f);
        //TODO: destroy this gameobject
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
