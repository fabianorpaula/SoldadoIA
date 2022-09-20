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
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 100))
        {
            if(hit.collider.gameObject.tag == "Inimigo")
            {
                //Debug TIRAR NA VERSÃO FINAL//
                Debug.DrawLine(transform.position, hit.point, Color.white, 100);
                Debug.Log(hit.collider.gameObject.name);
                Soldadinho.Enxerguei();
                Soldadinho.DestinoAtual = hit.collider.gameObject;
            }
            
        }
        
    }
}

