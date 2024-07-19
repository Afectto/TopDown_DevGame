using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Player playerPrefab;

    private void Awake()
    {
        Instantiate(playerPrefab);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
