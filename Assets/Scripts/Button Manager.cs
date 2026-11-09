using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    string MainMenu_Scene = "Main Menu Scene";

    string Combat_Scene = "Combat Scene";
    
    string Plinko_Scene = "Plinko Scene";
    
    string Soccer_Scene = "Soccer Scene";


    public void GoToMainMenu()
    {
        Debug.Log("Main Menu Scene");
        SceneManager.LoadScene(MainMenu_Scene);
    }

    public void GoToCombat()
    {
        Debug.Log("Combat Scene");
        SceneManager.LoadScene(Combat_Scene);
    }

    public void GoToPlinko()
    {
        Debug.Log("Plinko Scene");
        SceneManager.LoadScene(Plinko_Scene);
    }

    public void GoToSoccer()
    {
        Debug.Log("Soccer Scene");
        SceneManager.LoadScene(Soccer_Scene);
    }

    public void ExitApplication()
    {
        Debug.Log("Exit");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
