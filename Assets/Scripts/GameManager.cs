using UnityEngine;
public class GameManager : MonoBehaviour
{
    public AuthManager authManager; 
    public PanelController panelController; 

    private void Start()
    {
        if (authManager != null && panelController != null)
        {
            authManager.SetPanelController(panelController);
        }
    }
}
