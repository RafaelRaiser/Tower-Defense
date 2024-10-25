using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorrePadrao : MonoBehaviour, ITorre
{
    public GameObject projetilPrefab;
    public Transform pontoDisparo;
    public float tempoEntreDisparos = 1f;
    public int dano = 10;
    private float tempoDisparoRestante = 0f;

    void Update()
    {
        if (tempoDisparoRestante <= 0f)
        {
            Atirar();
            tempoDisparoRestante = tempoEntreDisparos;
        }

        tempoDisparoRestante -= Time.deltaTime;
    }

    public virtual void Atirar()
    {
        // Instancia o projetil
        GameObject projetil = Instantiate(projetilPrefab, pontoDisparo.position, pontoDisparo.rotation);
        projetil.GetComponent<Projetil>().Iniciar(dano);
    }

    public virtual void FazerUpgrade()
    {
        // Exemplo de upgrade, aumentando o dano e reduzindo o tempo de disparo
        dano += 5;
        tempoEntreDisparos -= 0.2f;
    }
}
