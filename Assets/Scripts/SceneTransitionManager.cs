using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    private static SceneTransitionManager instance;

    private void Awake()
    {
      
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

    public static void LoadScene(string sceneName)
    {
        if (instance == null)
        {
           
            return;
        }

        SceneManager.LoadScene(sceneName);
    }
}
