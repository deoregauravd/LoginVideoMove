using UnityEngine;
using TMPro;

public class AuthManager : MonoBehaviour
{

    private IPanelController panelController; 

    public TMP_InputField usernameInputSignup;
    public TMP_InputField passwordInputSignup;
    public TMP_InputField confirmPasswordInputSignup;

    public TMP_InputField usernameInputLogin;
    public TMP_InputField passwordInputLogin;

    public TextMeshProUGUI feedbackText;

   
    public void SetPanelController(IPanelController panelController)
    {
        this.panelController = panelController;
    }
    

    public void SignUp()
    {
        string username = usernameInputSignup.text;
        string password = passwordInputSignup.text;
        string confirmPassword = confirmPasswordInputSignup.text;

        // Validate input fields
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
        {
            feedbackText.text = "Please fill in all fields.";
            return;
        }

        // Check if passwords match
        if (password != confirmPassword)
        {
            feedbackText.text = "Passwords do not match.";
            return;
        }

        // Check if the username already exists
        if (PlayerPrefs.HasKey(username))
        {
            feedbackText.text = "Username already exists.";
            return;
        }

       
        PlayerPrefs.SetString(username, password);
        PlayerPrefs.Save();
        feedbackText.text = "User signed up successfully!";

     
        panelController.HidePanel();
        panelController.ShowLoginPanl();
    }

    public void Login()
    {
        string username = usernameInputLogin.text;
        string password = passwordInputLogin.text;

        // Validate input fields
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            feedbackText.text = "Please fill in all fields.";
            return;
        }

        // Check if the username exists
        if (PlayerPrefs.HasKey(username))
        {
            // Retrieve the stored password
            string storedPassword = PlayerPrefs.GetString(username);

            if (storedPassword == password)
            {
                feedbackText.text = $"Welcome, {username}!";
                panelController.HideLoginPanel();
            }
            else
            {
                feedbackText.text = "Invalid password.";
            }
        }
        else
        {
            feedbackText.text = "User not found.";
        }
    }


  
    private void ClearAllData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        feedbackText.text = "All user data cleared.";
    }
}
