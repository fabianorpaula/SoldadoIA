using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visao : MonoBehaviour
{
    public Soldado Soldadinho;
    public int MaisVisao;
    private int DistanciaVisao = 400;
    // Start is called before the first frame update
    void Start()
    {
        DistanciaVisao = DistanciaVisao + MaisVisao;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 frente= transform.TransformDirection(Vector3.forward) * DistanciaVisao;
        if (Physics.Raycast(transform.position, frente, out hit, DistanciaVisao))
        {
            Debug.Log(hit.collider.gameObject.name);
            if(hit.collider.gameObject.tag == "Inimigo")
            {
                //Debug TIRAR NA VERSÃO FINAL//
                
                Soldadinho.Enxerguei();
                Soldadinho.DestinoAtual = hit.collider.gameObject;
            }
            
        }
        Vector3 forward = transform.TransformDirection(Vector3.forward) * DistanciaVisao;
        Debug.DrawRay(transform.position, forward, Color.green);
    }
}

