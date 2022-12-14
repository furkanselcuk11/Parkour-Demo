using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController uicontrollerInstance;

    [Header("Game UI Controller")]
    [SerializeField] private GameObject GameStartPanel;
    [SerializeField] private GameObject GameRunTimePanel;
    [SerializeField] private GameObject GameFinishPanel;
    public TextMeshProUGUI rankingText;
    public TextMeshProUGUI finishRankText;
    public GameObject paintSuccessful;
    public Button nextLevel;

    private void Awake()
    {
        if (uicontrollerInstance == null)
        {
            uicontrollerInstance = this;
        }
    }
    void Start()
    {
        
    }
    
    void Update()
    {
        UpdatePanel();
    }
    public void UpdatePanel()
    {
        if (GameManager.gamemanagerInstance.startGame & !GameManager.gamemanagerInstance.isFinish)
        {
            // Eger Oyun baslamissa GameRunTimePanel aktif olur
            GameStartPanel.SetActive(false);
            GameRunTimePanel.SetActive(true);
            GameFinishPanel.SetActive(false);
        }
        else
        {
            // Eger startGame false ve Finih alanina gelinmisse GameFinishPanel aktif olur
            GameStartPanel.SetActive(false);
            GameRunTimePanel.SetActive(false);
            GameFinishPanel.SetActive(true);
        }
        if (!GameManager.gamemanagerInstance.startGame & !GameManager.gamemanagerInstance.isFinish)
        {
            // Eger startGame false ve Finih fase ise oyun baslamamissa GameStartPanel aktif olur
            GameStartPanel.SetActive(true);
            GameRunTimePanel.SetActive(false);
            GameFinishPanel.SetActive(false);
        }
    }
}
