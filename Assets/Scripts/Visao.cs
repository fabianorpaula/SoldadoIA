using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visao : MonoBehaviour
{
    public Soldado Soldadinho;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 frente= transform.TransformDirection(Vector3.forward) * 400;
        if (Physics.Raycast(transform.position, frente, out hit, 400))
        {
            Debug.Log(hit.collider.gameObject.name);
            if(hit.collider.gameObject.tag == "Inimigo")
            {
                //Debug TIRAR NA VERSÃO FINAL//
                
                Soldadinho.Enxerguei();
                Soldadinho.DestinoAtual = hit.collider.gameObject;
            }
            
        }
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 400;
        Debug.DrawRay(transform.position, forward, Color.green);
    }
}

