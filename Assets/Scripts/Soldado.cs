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

    public GameObject MinhaArma;

    public enum Estados { Ronda, Parado, Perseguir, Atacar};
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
        if(meuEstado == Estados.Perseguir)
        {
            PerseguirInimigo();
        }
        else
        {
            AtivarGatilho();
        }



        if (meuEstado == Estados.Atacar)
        {
            Agente.speed = 0;
            GetComponent<Animator>().SetBool("Aiming", true);
            GetComponent<Animator>().SetTrigger("Attack");
            transform.LookAt(DestinoAtual.transform.position);
        }
        else
        {
            GetComponent<Animator>().SetBool("Aiming", false);
        }



        if (meuEstado == Estados.Ronda)
        {
            FazeRonda();
            tempo++;
        }
        if (meuEstado == Estados.Parado)
        {
            Parar();
            tempo--;
        }

        GetComponent<Animator>().SetFloat("Speed", Agente.speed);

    }

    void PerseguirInimigo()
    {
        Agente.speed = 12;
        if(DestinoAtual != null)
        {
            //Estar Perseguindo
            Agente.SetDestination(DestinoAtual.transform.position);
            if(Vector3.Distance(transform.position, DestinoAtual.transform.position) < 10)
            {
                meuEstado = Estados.Atacar;
            }
            
        }
        else
        {
            if (DestinoAtual == null)
            {
                meuEstado = Estados.Ronda;

                DestinoAtual = DestinoA;
            }
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

    private void Atacar()
    {
        if (Vector3.Distance(DestinoAtual.transform.position, transform.position) < 3)
        {
            Destroy(DestinoAtual);
           
        }
    }
    /*
    private void OnTriggerEnter(Collider colidiu)
    {
        if(colidiu.gameObject.tag == "Inimigo")
        {
            
            DestinoAtual = colidiu.gameObject;
        }
    }*/

    public void Enxerguei()
    {
        if(meuEstado != Estados.Atacar)
        {
            meuEstado = Estados.Perseguir;
        }
        
    }

    
    //Atacar
    public void Ataque()
    {
        Debug.Log("Chamei Arma");
        MinhaArma.SetActive(true);
    }

    public void DesativaAtaque()
    {
        MinhaArma.SetActive(false);
    }

}
