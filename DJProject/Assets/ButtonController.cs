using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    // Reference to the PowerUpSpawn script
    public PowerUpSpawn powerUpSpawnScript;
    private static GameObject[] objects;
    public static GameObject[] positions;

    void Start()
    {
        powerUpSpawnScript = FindObjectOfType<PowerUpSpawn>();
        objects = powerUpSpawnScript.objects;
        positions = powerUpSpawnScript.positions;
    }

    // Method to be called when the button is clicked
    public void OnButtonClick()
    {
        powerUpSpawnScript.CreateSpawnPowerUps(objects, positions);
    }
}
