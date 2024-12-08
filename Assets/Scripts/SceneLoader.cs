using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
 
    public void OnButtonClick(string sceneName)
    {
       
        SceneTransitionManager.LoadScene(sceneName);
    }
}

