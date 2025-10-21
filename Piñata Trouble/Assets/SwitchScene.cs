using UnityEngine;
using UnityEngine.SceneManagement; // Nodig om scenes te laden

public class SceneSwitcher : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}