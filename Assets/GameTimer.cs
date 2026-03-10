using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameTimer : MonoBehaviour
{
    private float timeLimit = 60f;
    public TextMeshProUGUI timerText;

    void Update()
    {
        if (timeLimit > 0)
        {
            timeLimit -= Time.deltaTime;
            if (timeLimit < 0)
            {
                timeLimit = 0;
            }
        }

        if (timerText != null)
        {
            timerText.text = "TIME: " + Mathf.CeilToInt(timeLimit).ToString();
        }

        if (timeLimit <= 0)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}