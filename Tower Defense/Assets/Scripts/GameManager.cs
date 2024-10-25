using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections.Generic; // Importante para usar List
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<Transform> marks; // Lista de Marks no mapa
    public List<GameObject> inimigosPrefab; // Lista de prefabs dos inimigos
    public Transform pontoSpawn; // Ponto de spawn dos inimigos
    public int numeroDeInimigosPorHorda = 8;
    public int ouro = 50;
    public int VidaJogador = 10;

    private int hordaAtual = 1;

    void Awake()
    {
        // Singleton pattern para garantir que só haja um GameManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Inicia a primeira horda
        InvokeRepeating("IniciarHorda", 2f, 10f);
    }

    void IniciarHorda()
    {
        for (int i = 0; i < numeroDeInimigosPorHorda; i++)
        {
            SpawnarInimigo();
        }

        // Aumenta o número de inimigos na próxima horda
        numeroDeInimigosPorHorda++;
    }

    void SpawnarInimigo()
    {
        // Escolhe um inimigo aleatório da lista e instancia
        int rand = Random.Range(0, inimigosPrefab.Count);
        Instantiate(inimigosPrefab[rand], pontoSpawn.position, Quaternion.identity);
    }

    public void AdicionarOuro(int quantidade)
    {
        ouro += quantidade;
        UIManager.Instance.AtualizarUI();
    }
}
