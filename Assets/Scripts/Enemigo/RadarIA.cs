using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarIA : MonoBehaviour
{
    MoveIA estados;
    public float rangoPersecucion;
    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        estados = GetComponentInParent<MoveIA>();
    }

    // Update is called once per frame
    void Update()
    {
        bool radarBool = Physics.CheckSphere(transform.position, rangoPersecucion, layerMask);

        if (radarBool == true)
        {
            estados.estadoActual = EstadosAI.Persecucion;
            Debug.Log("Estás en la mira");
        }
        else
        {
            estados.estadoActual = EstadosAI.Idle;
            Debug.Log("No alcanzo a ver");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoPersecucion);
    }
}
