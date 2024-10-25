using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float alcance = 5f;
    public float taxaDeAtaque = 1f;
    public GameObject projetilPrefab;
    private float tempoParaProximoAtaque = 0f;

    void Update()
    {
        if (Time.time >= tempoParaProximoAtaque)
        {
            Enemy alvo = EncontrarInimigo();
            if (alvo != null)
            {
                Disparar(alvo);
                tempoParaProximoAtaque = Time.time + 1f / taxaDeAtaque;
            }
        }
    }

}