using UnityEngine;
using TMPro;
using UnityEngine.UI;  // Add this namespace for TextMeshPro

public class PanelControl : MonoBehaviour
{
    public Button nextButton;
    public Button backButton;
    public TextMeshProUGUI messageText;  // Use TextMeshProUGUI for UI text
    public Image displayImage;

    public Transform userCamera; // Camera for teleporting and repositioning

    private int step = 0;
    private Vector3 lastLocation; // Variable to store the user's last location

    // Define the range for random teleportation (e.g., a box with min and max values)
    public Vector3 teleportMinRange; // Minimum bounds of teleportation area
    public Vector3 teleportMaxRange; // Maximum bounds of teleportation area

    void Start()
    {
       
        displayImage.gameObject.SetActive(false);

       
        lastLocation = userCamera.position;


        nextButton.onClick.AddListener(HandleNext);
        backButton.onClick.AddListener(HandleBack);
    }

    void HandleNext()
    {
        // Only proceed to teleportation once the user reaches step 2 (after showing image)
        if (step < 2)
        {
            step++;

            switch (step)
            {
                case 1:
                    messageText.text = "Welcome!";
                    messageText.gameObject.SetActive(true);
                    break;

                case 2:
                    messageText.text = "Image";
                    displayImage.gameObject.SetActive(true);
                    break;

                default:
                    step = 2; // Prevent exceeding the last step of the initial flow
                    break;
            }
        }
        else
        {
            // After the second step, focus on teleportation
            messageText.text = "Teleporting...";
            displayImage.gameObject.SetActive(false);
            TeleportUserToRandomLocation();
        }
    }

    void HandleBack()
    {
        // If already in teleport mode, go back to the previous location
        if (step >= 2)
        {
            TeleportUserToLastLocation();
        }
        else
        {
            // If not in teleport mode, return to the previous flow steps
            if (step > 0)
            {
                step--;
            }

            switch (step)
            {
                case 0:
                    messageText.text = "Welcome!";
                    break;

                case 1:
                    messageText.text = "Here is the next step!";
                    break;

                case 2:
                    messageText.text = "Here is the text with an image!";
                    displayImage.gameObject.SetActive(true);
                    break;
            }
        }
    }

    void TeleportUserToRandomLocation()
    {
        // last location
        lastLocation = userCamera.position;

        float randomX = Random.Range(teleportMinRange.x, teleportMaxRange.x);
        float randomY = Random.Range(teleportMinRange.y, teleportMaxRange.y);
        float randomZ = Random.Range(teleportMinRange.z, teleportMaxRange.z);

        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

       
        userCamera.position = randomPosition;
        messageText.text = $"Teleported to: X = {randomX:F2}, Y = {randomY:F2}, Z = {randomZ:F2}";

    }

    void TeleportUserToLastLocation()
    {
        // Teleport user back to the last location
        userCamera.position = lastLocation;
        messageText.text = $"Teleported to: X = {lastLocation.x:F2}, Y = {lastLocation.y:F2}, Z = {lastLocation.z:F2}";

    }
}
