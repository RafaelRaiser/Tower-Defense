using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text playerHealthText;  // Exibe a vida do jogador
    public Text playerGoldText;    // Exibe o ouro do jogador
    public Text waveText;          // Exibe a onda atual

    public GameObject towerButtonPrefab; // Prefab do botão de construir torres
    public Transform towerButtonPanel;   // Local na UI para os botões de torres

    void OnEnable()
    {
        GameManager.onPlayerStatsChanged += UpdateUI;
    }

    void OnDisable()
    {
        GameManager.onPlayerStatsChanged -= UpdateUI;
    }
}