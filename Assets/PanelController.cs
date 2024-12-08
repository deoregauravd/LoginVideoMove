using UnityEngine;

public class PanelController : MonoBehaviour, IPanelController
{
    [SerializeField] private GameObject panel;
    [SerializeField]  private GameObject loginPanel;
    public void ShowPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);
        }
    }

    public void HidePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    public void ShowLoginPanl()
    {
        if (loginPanel != null)
        {
            loginPanel.SetActive(true);
        }
    }

     public void HideLoginPanel()
    {
        if (loginPanel != null)
        {
            loginPanel.SetActive(false);
        }
    }
}
