using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
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
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

    }
}