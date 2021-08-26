using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Slider speedSlider;
    [SerializeField] private TextMeshProUGUI deleteButtonText;

    private void Awake()
    {
        speedSlider.value = PlayerPrefs.GetFloat("Speed");
        Time.timeScale = 1;
    }
    private void Start()
    {
        deleteButtonText.text = "Delete Highscore (" + PlayerPrefs.GetInt("HS").ToString() + ")";
    }
    private void Update()
    {
        PlayerPrefs.SetFloat("Speed", speedSlider.value);        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void CloseGame()
    {
        Application.Quit();
    }

    public void DeleteHighscore()
    {
        PlayerPrefs.DeleteKey("HS");
        deleteButtonText.text = "Delete Highscore (0)";
    }
}
