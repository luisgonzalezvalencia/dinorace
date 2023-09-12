using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public float speed = 2;
void Update()
{
    // Moves an object forward, relative to its own rotation.
    transform.position += transform.forward * speed * Time.deltaTime;
}
}
