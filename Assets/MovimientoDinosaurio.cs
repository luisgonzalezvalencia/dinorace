using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MovimientoDinosaurio : NetworkBehaviour
{
    public float velocidadMovimiento = 5f; // Velocidad de movimiento del dinosaurio
    public float fuerzaSalto = 500f; // Fuerza del salto
    public float velocidadGiro = 100f; // Velocidad de giro
    public bool jump = false;

    private Rigidbody rb;

    public Animator animador;


    private void Start()
    {
        // Obtener el componente Rigidbody del objeto
        rb = GetComponent<Rigidbody>();
        animador = GetComponent<Animator>();
    }

    private void Update()
    {
        if (base.hasAuthority)
        {
            animador.SetBool("Walk", Input.GetAxis("Vertical") != 0);

            // Movimiento vertical (acelerar y desacelerar)
            float movimientoVertical = Input.GetAxis("Vertical");

            Vector3 pos = new Vector3(0f, 0f, movimientoVertical * velocidadMovimiento * Time.deltaTime);

            transform.Translate(pos, Space.Self);

            // Girar

            transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * velocidadGiro * Time.deltaTime);


            // Salto
            if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f)
            {
                // Vector3 posS = new Vector3(0f, fuerzaSalto * Time.deltaTime, 0f);
                // transform.Translate(posS, Space.Self);
                animador.SetBool("Jump", true);
                jump = true;
                rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
                Invoke("ChangeJumpFalse", 0.5f);
            }

            // if (jump)
            // {
            //     animador.SetBool("Jump", true);
            // }
        }
    }

    private void ChangeJumpFalse()
    {
        jump = false;
        animador.SetBool("Jump", false);
    }
}