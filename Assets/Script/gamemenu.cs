using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class gamemenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI menuScoreText;
    [SerializeField] TextMeshProUGUI gameScoreText;
    private void Update()
    {
        menuScoreText.text = gameScoreText.text;
    }
    public void retryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SimpleNaturePack");
    }
    public void returnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
