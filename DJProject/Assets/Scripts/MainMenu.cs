using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    // Start is called before the first frame update
    public void StartGam()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }
}
