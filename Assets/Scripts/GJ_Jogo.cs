using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GJ_Jogo : MonoBehaviour
{

    public List<GameObject> Jogadores;
    public List<GameObject> Posicoes;
    public int indice;
    public int indiceJ = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 5;
        indice = Posicoes.Count;
        Sortear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Sortear()
    {
        while (indice > 0)
        {
            int indiceAtual = Random.Range(0, Posicoes.Count);
            Jogadores[indiceJ].transform.position = Posicoes[indiceAtual].transform.position;
            Posicoes.Remove(Posicoes[indiceAtual]);
            indiceJ++;
            indice--;
        }
    }
}
