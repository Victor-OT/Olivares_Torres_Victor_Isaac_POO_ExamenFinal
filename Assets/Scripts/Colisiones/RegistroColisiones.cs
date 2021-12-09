using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegistroColisiones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemigo")
        {
            this.gameObject.GetComponent<ColisionesJugador>().Daño();
            Debug.Log("Me estás tocando");
        }

        if (collision.gameObject.tag == "Moneda")
        {
            Debug.Log("Una Moneda!");
            this.gameObject.GetComponent<ColisionesJugador>().SumaMonedas();
            Destroy(collision.gameObject);
        }
    }
}
