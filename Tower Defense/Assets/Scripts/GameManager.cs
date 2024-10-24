using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
 GameManager
    public static GameManager Instance;  // Singleton para f�cil acesso global

    public List<Transform> spawnPoints;  // Pontos de spawn dos inimigos
    public GameObject[] enemyPrefabs;    // Prefabs dos inimigos
    public int totalWaves = 5;           // N�mero total de ondas
    public float timeBetweenWaves = 10f; // Tempo entre as ondas
    private int currentWave = 0;

    public int playerHealth = 20;        // Vida do jogador
    public int playerGold = 100;         // Ouro para comprar torres

    private bool isGameOver = false;

    // Evento para alertar o UIManager sobre a mudan�a no ouro ou vida
    public delegate void OnPlayerStatsChanged();
    public static event OnPlayerStatsChanged onPlayerStatsChanged;

    void Awake()
    {
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
        StartCoroutine(StartGame());
    }

    // Controla o ciclo das ondas de inimigos
    IEnumerator StartGame()
    {
        while (!isGameOver && currentWave < totalWaves)
        {
            currentWave++;
            SpawnEnemies();
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    // M�todo para spawnar os inimigos de acordo com a onda
    void SpawnEnemies()
    {
        int numberOfEnemies = currentWave * 5; // Exemplo: n�mero de inimigos cresce a cada onda
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Escolhe um spawn point aleat�rio
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

            // Escolhe um inimigo aleat�rio (pode ser ajustado para inimigos mais fortes a cada onda)
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }

    // Chamado quando o jogador perde vida
    public void TakeDamage(int damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0)
        {
            GameOver();
        }

        if (onPlayerStatsChanged != null)
        {
            onPlayerStatsChanged();  // Atualiza a UI com a nova vida
        }
    }

    // M�todo para adicionar ouro
    public void AddGold(int amount)
    {
        playerGold += amount;

        if (onPlayerStatsChanged != null)
        {
            onPlayerStatsChanged();  // Atualiza a UI com o novo ouro
        }
    }

    // Condi��o de fim de jogo
    void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over!");
        // Chamar o UIManager para mostrar a tela de derrota
    }
}
=======
  
    public static GameManager instance;
    public Transform[] path;
    public Transform startPoint;

    #region Singleton
    private void Awake()
    {
        instance = this;
    }
    #endregion

}