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

    public GameObject towerButtonPrefab; // Prefab do bot�o de construir torres
    public Transform towerButtonPanel;   // Local na UI para os bot�es de torres

    void OnEnable()
    {
        GameManager.onPlayerStatsChanged += UpdateUI;
    }

    void OnDisable()
    {
        GameManager.onPlayerStatsChanged -= UpdateUI;
    }
    void Start()
    {
        UpdateUI();  // Atualiza a UI inicialmente
        CreateTowerButtons();
    }

    // M�todo para atualizar a vida e ouro do jogador
    public void UpdateUI()
    {
        playerHealthText.text = "Health: " + GameManager.Instance.playerHealth.ToString();
        playerGoldText.text = "Gold: " + GameManager.Instance.playerGold.ToString();
    }
    // M�todo para criar os bot�es das torres na UI
    void CreateTowerButtons()
    {
        // Adicione seus tipos de torres aqui, esse � s� um exemplo
        string[] towerNames = { "Cannon Tower", "Laser Tower", "Missile Tower" };

        foreach (var towerName in towerNames)
        {
            GameObject button = Instantiate(towerButtonPrefab, towerButtonPanel);
            button.GetComponentInChildren<Text>().text = towerName;

            // Adiciona um evento de clique para criar a torre
            button.GetComponent<Button>().onClick.AddListener(() => OnTowerButtonClicked(towerName));
        }
    }

    // M�todo chamado quando o bot�o de construir torre � clicado
    void OnTowerButtonClicked(string towerName)
    {
        Debug.Log("Construindo " + towerName);

        // Aqui voc� chamaria o GameManager ou um script de constru��o para colocar a torre no mapa.
    }
}