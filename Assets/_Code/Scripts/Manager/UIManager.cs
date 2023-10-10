using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;


    [SerializeField] private GameObject levelCompletedPanel;
    [SerializeField] private GameObject levelFailedPanel;

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        Time.timeScale = 1f;
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }

        Instance = this;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ShowLevelCompletedPanel()
    {
        Invoke("StopGame", 1f);
        levelFailedPanel.SetActive(false);
        levelCompletedPanel.SetActive(true);
    }

    public void ShowLevelFailedPanel()
    {
        Invoke("StopGame", 0.2f);

        levelCompletedPanel.SetActive(false);
        levelFailedPanel.SetActive(true);
    }


    public void OnClick_Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void StopGame()
    {
        Time.timeScale = 0f;
    }
}
