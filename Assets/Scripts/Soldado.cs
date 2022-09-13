using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soldado : MonoBehaviour
{
    private NavMeshAgent Agente;
    public GameObject DestinoA;
    public GameObject DestinoB;
    public GameObject DestinoAtual;
    public float tempo = 0;

    public enum Estados { Ronda, Parado};
    public Estados meuEstado;

    // Start is called before the first frame update
    void Start()
    {
        Agente = GetComponent<NavMeshAgent>();
        DestinoAtual = DestinoA;
    }

    // Update is called once per frame
    void Update()
    {
        //AtivadoraDeGatilho
        AtivarGatilho();
        if(meuEstado == Estados.Ronda)
        {
            FazeRonda();
            tempo++;
        }
        if (meuEstado == Estados.Parado)
        {
            Parar();
            tempo--;
        }


    }

    void FazeRonda()
    {
        Agente.speed = 12;
        Agente.SetDestination(DestinoAtual.transform.position);
        MudaDestino();
    }
    void MudaDestino()
    {
        if(Vector3.Distance(DestinoA.transform.position, transform.position) < 3)
        {
            DestinoAtual = DestinoB;
        }
        if (Vector3.Distance(DestinoB.transform.position, transform.position) < 3)
        {
            DestinoAtual = DestinoA;
        }

    }

    void Parar()
    {
        Agente.speed = 0;
    }

    void AtivarGatilho()
    {
        if(tempo > 300)
        {
            meuEstado = Estados.Parado;
        }

        if(tempo <= 0)
        {
            meuEstado = Estados.Ronda;
        }
    }
}
