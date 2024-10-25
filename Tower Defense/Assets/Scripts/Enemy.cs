using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidade;
    public int vida;
    public int recompensaOuro;

    private int vidaAtual;
    private Transform alvo;
    private int markIndex = 0;

    // Referência ao GameManager
    private GameManager gameManager;

    void Start()
    {
        vidaAtual = vida;
        // O GameManager gerencia os marks
        gameManager = GameManager.Instance;
        // Define o primeiro alvo como o primeiro mark
        alvo = gameManager.marks[0];
    }

    void Update()
    {
        Mover();
    }

    void Mover()
    {
        if (alvo == null)
            return;

        // Movimenta-se em direção ao mark atual
        Vector3 direcao = alvo.position - transform.position;
        transform.Translate(direcao.normalized * velocidade * Time.deltaTime, Space.World);

        // Verifica se atingiu o mark atual
        if (Vector3.Distance(transform.position, alvo.position) <= 0.2f)
        {
            GetProximoMark();
        }
    }

    void GetProximoMark()
    {
        if (markIndex >= gameManager.marks.Length - 1)
        {
            // Se chegou ao destino final, morre ou realiza outra ação
            AlcançarDestino();
        }
        else
        {
            markIndex++;
            alvo = gameManager.marks[markIndex];
        }
    }

    void AlcançarDestino()
    {
        // Dano ao jogador ou redução de vida se o inimigo chegar ao final
        gameManager.VidaJogador -= 1;
        Destroy(gameObject);
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
        // Adiciona ouro ao jogador quando o inimigo morre
        gameManager.AdicionarOuro(recompensaOuro);
        Destroy(gameObject);
    }
}