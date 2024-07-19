using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public void PauseGame()
    {
        _panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        _panel.SetActive(false);
        Time.timeScale = 1;
    }
}
