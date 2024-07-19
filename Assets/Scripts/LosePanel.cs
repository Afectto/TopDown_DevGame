using TMPro;
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private TextMeshProUGUI isNewRecordText;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    void Start()
    {
        gameObject.SetActive(false);
        isNewRecordText.gameObject.SetActive(false);
        score.OnScoreUpdate += OnShowPanel;
    }

    private void OnShowPanel(float value, bool isNewRecord)
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        var scoreTextString = !isNewRecord ? "Current Score: " : "";
        scoreText.text = scoreTextString + value.ToString();
        isNewRecordText.gameObject.SetActive(isNewRecord);
        score.gameObject.SetActive(false);
    }

    public void OnHidePanel()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        score.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        score.OnScoreUpdate -= OnShowPanel;
    }
}
