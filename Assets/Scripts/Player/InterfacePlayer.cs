/*
Nombre completo: Olivares Torres Victor Isaac
Asignatura: Programacion Orientada a Objetos
Profesor: Josue Israel Rivas Diaz.
Fuente en la que bas� el script: Clases impartidas por el profesor.
Descripci�n general del script: Se encarga de heredar los datos del contador para posteriormente asignarlos a variables de texto
que aparecer�n en la interfaz del usuario.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InterfacePlayer : MonoBehaviour
{
    //Variables de text mesh pro
    [Header("Interface Jugador")]
    public TMP_Text vidaTMP;
    public TMP_Text monedasTMP;

    //script de donde se van a heredar los datos
    Contadores datos;
    // Start is called before the first frame update
    void Start()
    {
        datos = GetComponent<Contadores>();
        StartCoroutine(AsignarDatos(0.1f));
    }

    // Update is called once per frame
    void Update()
    {
        //Codigo para actualizar constantemente los valores de datos en la interfaz
        vidaTMP.text = "VIDAS: " + datos.contadorVidas;
        monedasTMP.text = "MONEDAS: " + datos.contadorMonedas;
    }

    //corrutina para asignar los datos a los text mesh pro que aparecer�n en la interfaz
    //despu�s de un periodo de tiempo asignado en la inicializaci�n
    IEnumerator AsignarDatos(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (vidaTMP != null)
        {
            vidaTMP.text = "VIDAS: " + datos.contadorVidas;
        }
        
        if (monedasTMP != null)
        {
            monedasTMP.text = "MONEDAS: " + datos.contadorMonedas;
        }
    }
}
