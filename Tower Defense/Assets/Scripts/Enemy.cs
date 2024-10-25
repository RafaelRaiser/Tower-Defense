using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidade;
    public int vida;
    public int recompensaOuro;

    private int vidaAtual;

    void Start()
    {
        vidaAtual = vida;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        // Movimento básico do inimigo
        transform.Translate(Vector3.left * velocidade * Time.deltaTime);
    }

    public void ReceberDano(int dano)
    {
        vidaAtual -= dano;
        if (vidaAtual <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Adicionar ouro ao jogador
        GameManager.Instance.AdicionarOuro(recompensaOuro);
        Destroy(gameObject);
    }
}