using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeObjects : MonoBehaviour
{
    public GameObject[] textObjects; // An array to hold your text objects
    private int currentIndex = 0; // Index to track the current text object

    public void Next()
    {
        if (currentIndex < textObjects.Length - 1)
        {
            textObjects[currentIndex++].SetActive(false);
            textObjects[currentIndex].SetActive(true);
        }
        else
        {
            if(GameObject.FindWithTag("Ending"))
                SceneManager.LoadScene("MainMenu");
            else
                SceneManager.LoadScene("MainScene");
        }
            
    }

    public void Back()
    {
        if (currentIndex > 0)
        {
            textObjects[currentIndex--].SetActive(false);
            textObjects[currentIndex].SetActive(true);
        }
        
    }
}
