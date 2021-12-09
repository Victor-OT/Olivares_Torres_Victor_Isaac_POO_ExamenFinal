/*
Nombre completo: Olivares Torres Victor Isaac
Asignatura: Programacion Orientada a Objetos
Profesor: Josue Israel Rivas Diaz.
Fuente en la que bas� el script: Clases Impartidas por el profesor
Descripci�n general del script: Script que genera una Inteligencia Artificial Basica para el enemigo
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lista con posibles estados que podr� tener el enemigo
public enum EstadosAI
{
    Idle,
    Persecucion
}

public class MoveIA : MonoBehaviour
{
    // Variables para localizar al objetivo al que se va a perseguir, la velocidad con la que se dar� la persecuci�n
    // y una variable para medir la distancia entre el jugador y el enemigo.
    public EstadosAI estadoActual;

    public Transform target;
    public float velocidad;
    public Animator animEnemigo;
    public float distanciaExacta;

    // Start is called before the first frame update
    void Start()
    {
        animEnemigo = GetComponent<Animator>();
        estadoActual = EstadosAI.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        // operacion para realizar la persecuci�n
        Vector3 direccion = target.position - transform.position;
        //Debug.Log(direccion.sqrMagnitude);
        transform.LookAt(target);
 
        //Maquinas de estado que se toman de la lista anteriormente declarada, y que cambiar�n entre uno y otro
        //dependiendo de la condicion dada.
        switch (estadoActual)
        {
            case EstadosAI.Idle:
                PlayAnimation("Zombie Idle");
                break;
            case EstadosAI.Persecucion:
                PlayAnimation("Zombie Running");
                Move(direccion);
                break;

            default:
                break;

        }
    }

    //Metodos para realizar la traslaci�n del enemigo hacia la posici�n del jugador
    public void Move(Vector3 direccion)
    {
        this.transform.Translate(direccion.normalized * velocidad * Time.deltaTime, Space.World);
    }

    //Metodo que activar� la animaci�n del enemigo alterando su estado de booleano.
    private void AnimacionBool(string nombreAnimacion, bool valor)
    {
        animEnemigo.SetBool(nombreAnimacion, valor);
    }


    //Metodo para reproducir animacion del enemigo, misma que se encuentra por su nombre.

    private void PlayAnimation(string nombreClip)
    {
        animEnemigo.Play(nombreClip);
    }
}
