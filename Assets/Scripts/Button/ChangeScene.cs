using UnityEngine;
using UnityEngine.SceneManagement;

public static class Scenes
{
    public const string GAMEPLAY = "Gameplay";
    public const string MAIN_MENU = "MainMenu";
}
public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }
}
