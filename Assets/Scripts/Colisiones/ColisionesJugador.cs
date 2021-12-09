/*
Nombre completo: Olivares Torres Victor Isaac
Asignatura: Programacion Orientada a Objetos
Profesor: Josue Israel Rivas Diaz.
Fuente en la que basé el script: Clases impartidas por el profesor
Descripción general del script: Script encargado de registrar colision con las monedas y los enemigos
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionesJugador : MonoBehaviour
{
    //variavles para restar al contador de vidas y sumar al contador de monedas
    int daño = 1;
    int incrementoMonedas = 1;
    //Script de donde se heredan los valores de los contadores de vida y monedas
    Contadores registros;

    // Start is called before the first frame update
    void Start()
    {
        registros = GetComponent<Contadores>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Daño()
    {
        //Realiza la operacion de restar vida cuando el jugador colisione con el enemigo,
        //si el contador de vida llega a 0, el jugador se destruye.
        registros.contadorVidas -= daño;
        Debug.Log(registros.contadorVidas);

        if (registros.contadorVidas <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //Metodo para sumar al contador de monedas cuando el jugador colisione con una de ellas
    public void SumaMonedas()
    {
        registros.contadorMonedas += incrementoMonedas;
        //Condicion para sumar una vida cuando el contador de monedas llegue a 10, y este a su vez se reestablece a 0
        if (registros.contadorMonedas == 10)
        {
            registros.contadorVidas++;
            registros.contadorMonedas = 0;
        }
    }
}