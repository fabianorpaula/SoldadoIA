using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    public GameObject Destino;
    private NavMeshAgent Agente;
    public PlayerController Arma;
    // Start is called before the first frame update
    void Start()
    {
        Arma.SetArsenal("Rifle");
        Agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Agente.SetDestination(Destino.transform.position);
    }
}
