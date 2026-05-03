using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Canvas Delay Settings")]
    [SerializeField] private Canvas canvasDelay;
    [SerializeField] private Text textDelay;
    [SerializeField] public TextMeshProUGUI textCoin;
    public int coinCount;
    public bool canDistance;

    [SerializeField] TextMeshProUGUI textDistance;

    [Header("Canvas Options")]
    [SerializeField] private Canvas canvasOptions;
    [SerializeField] private Button buttonOpenOptions;
    [SerializeField] private Button buttonCloseOptions;
    [SerializeField] private Button buttonGoMenu_Options;
    [SerializeField] private Button buttonRestart_Options;

    [Header("Canvas Death")]
    [SerializeField] private Canvas canvasDeath;
    [SerializeField] private Button buttonRestart_Death;
    [SerializeField] private Button buttonMenu_Death;

    [Header("Canvas Win")]
    [SerializeField] private Canvas canvasWin;
    [SerializeField] private Button buttonRestart_Win;
    [SerializeField] private Button buttonMenu_Win;

    void Start()
    {
        canDistance = false;
        coinCount = 0;
        textCoin.text = "Coins: " + coinCount;

        canvasDelay.enabled = true;
        canvasOptions.enabled = false;
        canvasDeath.enabled = false;
        canvasWin.enabled = false;

        // OPTIONS
        buttonOpenOptions.onClick.AddListener(OpenOptions);
        buttonCloseOptions.onClick.AddListener(CloseOptions);
        buttonGoMenu_Options.onClick.AddListener(GoToMenu);
        buttonRestart_Options.onClick.AddListener(RestartGame);

        // DEATH
        buttonRestart_Death.onClick.AddListener(RestartGame);
        buttonMenu_Death.onClick.AddListener(GoToMenu);

        // WIN
        buttonRestart_Win.onClick.AddListener(RestartGame);
        buttonMenu_Win.onClick.AddListener(GoToMenu);
    }

    void Update()
    {
        if (!GameManager.inGame)
        {
            textDelay.text = GameManager.delayStartGame.ToString();

            if (GameManager.delayStartGame == 0)
            {
                textDelay.text = "GO!";
                canDistance = true;
            }
        }
        else
        {
            canvasDelay.enabled = false;
        }

        textCoin.text = "Coins: " + coinCount;

        for (int i = 0; canDistance; i++) 
        {
            textDistance.text = "Total Distance: " + i.ToString();
        }
    }

    // ===================== OPTIONS =====================

    void OpenOptions()
    {
        canDistance = false;
        canvasOptions.enabled = true;
        Time.timeScale = 0f; 
    }

    void CloseOptions()
    {
        canDistance = true;
        canvasOptions.enabled = false;
        Time.timeScale = 1f;
    }

    // ===================== GAME STATES =====================

    public void ShowDeathCanvas()
    {
        canDistance = false;
        canvasDeath.enabled = true;
        Time.timeScale = 0f;
    }

    public void ShowWinCanvas()
    {
        canDistance = false;
        canvasWin.enabled = true;
        Time.timeScale = 0f;
    }

    // ===================== BUTTONS =====================

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); 
    }
}