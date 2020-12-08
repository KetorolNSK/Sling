using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
     public void LoadScene(int Level)
    {
        SceneManager.LoadScene(Level);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
