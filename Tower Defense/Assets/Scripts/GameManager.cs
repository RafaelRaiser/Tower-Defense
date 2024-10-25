using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform[] marks; 
    public GameObject[] inimigosPrefab; 
    public Transform pontoSpawn; 
    public int numeroDeInimigosPorHorda = 8;
    public int ouro = 50;
    public int VidaJogador = 10;

    private int hordaAtual = 1;

    #region Singleton
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
    #endregion
    void Start()
    {
        // Começa a primeira horda
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
        // Escolhe um inimigo aleatório e instancia
        int rand = Random.Range(0, inimigosPrefab.Length);
        Instantiate(inimigosPrefab[rand], pontoSpawn.position, Quaternion.identity);
    }

    public void AdicionarOuro(int quantidade)
    {
        ouro += quantidade;
        UIManager.Instance.AtualizarUI();
    }
}