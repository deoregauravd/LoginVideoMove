using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PanelControl : MonoBehaviour
{
    public Button nextButton;
    public Button backButton;
    public TextMeshProUGUI messageText;
    public Image displayImage;

    public Transform predefinedLocation; 
    public Transform userCamera;

    private int step = 0;
    private Vector3 lastLocation; 

    void Start()
    {
        displayImage.gameObject.SetActive(false);
        messageText.gameObject.SetActive(false); 
        lastLocation = userCamera.position; 

        nextButton.onClick.AddListener(HandleNext);
        backButton.onClick.AddListener(HandleBack);

        UpdateUI();
    }

    void HandleNext()
    {
        if (step < 3)
        {
            step++;
            if (step == 3)
            {
                TeleportUserToLocation();
            }
        }

        UpdateUI();
    }

    void HandleBack()
    {
        if (step > 0)
        {
            if (step == 3)
            {
                TeleportUserToLastLocation();
            }
            step--;
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        //messageText.gameObject.SetActive(true); 

        switch (step)
        {
            case 0:
                 messageText.gameObject.SetActive(false); 
                displayImage.gameObject.SetActive(false);
                break;

            case 1:
                messageText.gameObject.SetActive(true); 
                messageText.text = "Welcome!";
                displayImage.gameObject.SetActive(false);
                break;

            case 2:
                messageText.text = "Here is the text with an image!";
                displayImage.gameObject.SetActive(true);
                break;

            case 3:
                messageText.text = "You have been teleported!";
                displayImage.gameObject.SetActive(false);
                break;
        }
    }

    void TeleportUserToLocation()
    {
        if (predefinedLocation != null)
        {
            lastLocation = userCamera.position;
            userCamera.position = predefinedLocation.position;
            messageText.text = "Teleported to predefined location!";
        }
        else
        {
            messageText.text = "No predefined location set!";
        }
    }

    void TeleportUserToLastLocation()
    {
        userCamera.position = lastLocation; 
        messageText.text = "Returned to the last location!";
    }
}
