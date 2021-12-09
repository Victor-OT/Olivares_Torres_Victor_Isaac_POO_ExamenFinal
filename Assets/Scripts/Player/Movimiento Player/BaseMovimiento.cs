/*
Nombre completo: Olivares Torres Victor Isaac
Asignatura: Programacion Orientada a Objetos
Profesor: Josue Israel Rivas Diaz.
Fuentes en la que bas� el script: Canal de Youtube "Anima el Robin", canal de Youtube "Profe TIC", Clases impartidas por el profesor
Descripci�n general del script: Este Script se encarga de contener los m�todos necesarios para el movimiento del
player
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovimiento : MonoBehaviour
{
    //variables para doble salto
    public Rigidbody body;
    public float saltoVel;
    public bool enSuelo = true;
    public int maxSaltos = 2;
    public int saltoActual = 0; 



    Animator animPlayer;
    public float velocidadMovimiento;
    public float velocidadRotacion;
    Vector3 direccion;
    // Start is called before the first frame update
    void Start()
    {
        animPlayer = GetComponent<Animator>();
        body = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Metodo para Movimiento del jugador
    public void Movimiento()
    {
        float movimientoVertical = Input.GetAxis("Vertical");
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        bool moviendoseAdelante;
        bool moviendoseAtras;
        bool moviendoseIzquierda;
        bool moviendoseDerecha;
        
        //Condiciones para reconocer la direcci�n en la que se traslada el player y dependiendo de eso ser� el booleano
        //que se activar� o desactivar�.
        if (direccion.z > 0)
        {
            moviendoseAdelante = true;
        }
        else
        {
            moviendoseAdelante = false;
        }

        if (direccion.z < 0)
        {
            moviendoseAtras = true;
        }
        else
        {
            moviendoseAtras = false;
        }

        if (direccion.x > 0)
        {
            moviendoseDerecha = true;
        }
        else
        {
            moviendoseDerecha = false;
        }

        if (direccion.x < 0)
        {
            moviendoseIzquierda = true;
        }
        else
        {
            moviendoseIzquierda = false;
        }

        //vector para la direcci�n del player
        direccion = new Vector3(movimientoHorizontal, 0, movimientoVertical);
        //linea que estabiliza el valor del vector de dicrecci�n
        direccion.Normalize();

        //C�digo para realizar la operaci�n que permitir� el traslado, as� como la activaci�n de las animaciones 
        //correspondientes
        this.transform.Translate(direccion * velocidadMovimiento * Time.deltaTime);
        animPlayer.SetBool("running", moviendoseAdelante);
        animPlayer.SetBool("runBack", moviendoseAtras);
        animPlayer.SetBool("runLeft", moviendoseIzquierda);
        animPlayer.SetBool("runRight", moviendoseDerecha);
    }

    //Metodo para la rotaci�n del jugador
    public void Rotacion()
    {
        //Codigo para almacenar los axis del mouse en una variable y para crear un vector que almacene
        //la direcci�n hacia la que se pretende rotar con base en los axis
        float h_Rotacion = Input.GetAxisRaw("Mouse X");
        Vector3 rotacion_H = new Vector3(0, h_Rotacion, 0);

        //se realiza la operaci�n de rotaci�n para despues llevarla a cabo en el jugador
        rotacion_H *= Time.deltaTime * velocidadRotacion;
        this.transform.Rotate(rotacion_H);
    }

    //Metodo para doble salto
    public void Salto()
    {
        //esta condicion comprobar� que el personaje est� en el suelo, y limitar� la cantidad de saltos que pueda dar
        //cuando este deje de pisar el suelo.
        if (Input.GetKeyDown(KeyCode.Space) &&(enSuelo || maxSaltos > saltoActual))
        {
            body.velocity = new Vector3(0f, saltoVel, 0f * Time.deltaTime);
            enSuelo = false;
            saltoActual++;
            animPlayer.Play("Jumping");
        }
    }

    //Metodo para registrar colisiones del jugador y devolver la cantidad de saltos disponibles a 0
    private void OnCollisionEnter(Collision collision)
    {
        enSuelo = true;
        saltoActual = 0;
    }

    //Metodo para realizar el ataque
    public void Ataque()
    {
        //el ataque se resuelve por medio de una animacion.
        if (Input.GetMouseButtonDown(0))
        {
            animPlayer.SetTrigger("ataque");
        }
    }
}
