using UnityEngine;
using TMPro;
using UnityEngine.UI;  
using System.Collections.Generic; 

public class PanelControl : MonoBehaviour
{
    public Button nextButton;
    public Button backButton;
    public TextMeshProUGUI messageText;  
    public Image displayImage;

    public Transform userCamera;

    private int step = 0;
    private Stack<Vector3> teleportHistory = new Stack<Vector3>(); 
    public Vector3 teleportMinRange; 
    public Vector3 teleportMaxRange; 

    void Start()
    {
        displayImage.gameObject.SetActive(false);

        nextButton.onClick.AddListener(HandleNext);
        backButton.onClick.AddListener(HandleBack);
    }

    void HandleNext()
    {
        
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
                    step = 2; 
                    break;
            }
        }
        else
        {
         
            messageText.text = "Teleporting...";
            displayImage.gameObject.SetActive(false);
            TeleportUserToRandomLocation();
        }
    }

    void HandleBack()
    {
      
        if (teleportHistory.Count > 1)
        {
           
            teleportHistory.Pop();
          
            Vector3 lastLocation = teleportHistory.Peek();
            TeleportUserToLocation(lastLocation);
        }
        else if (teleportHistory.Count == 1)
        {
            Vector3 initialPosition = teleportHistory.Peek();
            TeleportUserToLocation(initialPosition);
        }
        else
        {
            messageText.text = "No previous location to return to.";
        }
    }

    void TeleportUserToRandomLocation()
    {
        float randomX = Random.Range(teleportMinRange.x, teleportMaxRange.x);
        float randomY = Random.Range(teleportMinRange.y, teleportMaxRange.y);
        float randomZ = Random.Range(teleportMinRange.z, teleportMaxRange.z);

        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

        teleportHistory.Push(userCamera.position);

        userCamera.position = randomPosition;
        messageText.text = $"Teleported to: X = {randomX:F2}, Y = {randomY:F2}, Z = {randomZ:F2}";
    }

    void TeleportUserToLocation(Vector3 location)
    {
        userCamera.position = location;
        messageText.text = $"Teleported to: X = {location.x:F2}, Y = {location.y:F2}, Z = {location.z:F2}";
    }
}
