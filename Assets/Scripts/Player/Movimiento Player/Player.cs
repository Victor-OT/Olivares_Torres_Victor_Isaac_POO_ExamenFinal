/*
Nombre completo: Olivares Torres Victor Isaac
Asignatura: Programacion Orientada a Objetos
Profesor: Josue Israel Rivas Diaz.
Fuente en la que basé el script: Clases Impartidas por el profesor.
Descripción general del script: Script que hereda los metodos de Base Movimiento.
*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ //se almacena e inicializa el Script Base Movimiento
    BaseMovimiento controlPlayer;
    // Start is called before the first frame update
    void Start()
    {
        controlPlayer = GetComponent<BaseMovimiento>();
    }

    // Update is called once per frame
    void Update()
    {
        //Se inicializan los metodos creados en Base Movimiento
        controlPlayer.Movimiento();
        controlPlayer.Rotacion();
        controlPlayer.Salto();
        controlPlayer.Ataque();
    }

}
