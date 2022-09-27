using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soldado : MonoBehaviour
{
    private NavMeshAgent Agente;
    
    public List<GameObject> Destinos;
    public int meuID_Destino;
    public GameObject DestinoAtual;
    public float tempo = 0;

    public GameObject MinhaArma;

    public enum Estados { Ronda, Parado, Perseguir, Atacar};
    public Estados meuEstado;


    private int meuHP = 10;
    private bool tomou_dano = false;
    private float tempo_dano = 0;

    // Start is called before the first frame update
    void Start()
    {

        Agente = GetComponent<NavMeshAgent>();
        meuID_Destino = Random.Range(0, Destinos.Count);
        DestinoAtual = Destinos[meuID_Destino];
        meuEstado = Estados.Ronda;
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
            Atacar();
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

        if(tomou_dano == true)
        {
            tempo += Time.deltaTime;
            if(tempo > 1)
            {
                tomou_dano = false;
            }
        }

    }

    void PerseguirInimigo()
    {
        Agente.speed = 35;
        if(DestinoAtual != null)
        {
            if(DestinoAtual == gameObject)
            {
                DestinoAtual = null;
            }
            else
            {
                //Estar Perseguindo
                Agente.SetDestination(DestinoAtual.transform.position);
                if (Vector3.Distance(transform.position, DestinoAtual.transform.position) < 10)
                {
                    meuEstado = Estados.Atacar;
                }
            }
            
            
        }
        else
        {
            if (DestinoAtual == null)
            {
                meuID_Destino = Random.Range(0, Destinos.Count);
                DestinoAtual = Destinos[meuID_Destino];
                meuEstado = Estados.Ronda;
            }
        }
    }
       


    void FazeRonda()
    {
        Agente.speed = 30;
        Agente.SetDestination(DestinoAtual.transform.position);
        MudaDestino();
    }
    void MudaDestino()
    {
        if(Vector3.Distance(DestinoAtual.transform.position, transform.position) < 3)
        {
            meuID_Destino = Random.Range(0, Destinos.Count);
            DestinoAtual = Destinos[meuID_Destino];
        }
        
        

    }

    void Parar()
    {
        Agente.speed = 0;
    }

    void AtivarGatilho()
    {
        /*if(tempo > 1)
        {
            meuEstado = Estados.Parado;
        }

        if(tempo <= 0)
        {
            meuEstado = Estados.Ronda;
        }*/
    }

    private void Atacar()
    {
        if (DestinoAtual != null)
        {


            Agente.speed = 0;
            GetComponent<Animator>().SetBool("Aiming", true);
            GetComponent<Animator>().SetTrigger("Attack");
            transform.LookAt(DestinoAtual.transform.position);
        }
        else
        {
            //Alguem Morreu
            meuEstado = Estados.Ronda;
            meuID_Destino = Random.Range(0, Destinos.Count);
            DestinoAtual = Destinos[meuID_Destino];

        }
    }
    

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
        
        MinhaArma.SetActive(true);
    }

    public void DesativaAtaque()
    {
        MinhaArma.SetActive(false);
    }


    public void RecebeuTiro()
    {
        if(tomou_dano == false)
        {
            tomou_dano = true;
            meuHP--;
            if(meuHP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
