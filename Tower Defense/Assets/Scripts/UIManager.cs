using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text ouroText;
    public Text vidaText;

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
        AtualizarUI();
    }

    public void AtualizarUI()
    {
        ouroText.text = "Ouro: " + GameManager.Instance.ouro.ToString();
        vidaText.text = "Vida: " + GameManager.Instance.VidaJogador.ToString();
    }
}