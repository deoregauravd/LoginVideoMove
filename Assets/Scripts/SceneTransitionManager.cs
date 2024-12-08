using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    private static SceneTransitionManager instance;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of the manager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Static method to load a scene by name
    public static void LoadScene(string sceneName)
    {
        if (instance == null)
        {
            Debug.LogError("SceneTransitionManager not initialized. Please add it to your scene.");
            return;
        }

        SceneManager.LoadScene(sceneName);
    }
}
