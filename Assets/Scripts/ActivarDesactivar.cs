/*
Nombre completo: Olivares Torres Victor Isaac
Asignatura: Programacion Orientada a Objetos
Profesor: Josue Israel Rivas Diaz.
Fuente en la que basé el script: Canal de Youtube "Daniel Vazquez" , video "Unity 3D - Activar objetos de manera random - Quick Tutorial"
Descripción general del script: Este Script se encarga activar y desactivar la plataforma switch
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarDesactivar : MonoBehaviour
{
    //Variables requeridas
    public float segundos = 0;
    public bool activo = true;
    public GameObject plataforma;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //codigo para recuperar el valor de Time delta time y almacenarlo en la variable segundos
        segundos += Time.deltaTime;
        Debug.Log(segundos);
        Debug.Log(activo);

        //Condiciones que permitirán intercambiar el valor del bool activo de true a false y viceversa
        // al mismo tiempo que cambia el bool de activar y desactivar el objeto plataforma switch
        if (segundos > 3 && activo == true)
        {
            segundos = 0;
            activo = false;
            plataforma.SetActive(false);
        }

        if (segundos > 3 && activo == false)
        {
            segundos = 0;
            activo = true;
            plataforma.SetActive(true);
        }
    }
}
