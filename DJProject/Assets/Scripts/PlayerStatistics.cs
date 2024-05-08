using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    public int powerUpCount = 0, abilityCount = 0;
    public float gameTime = 0f;
    // Update is called once per frame
    void Update()
    {
        Debug.Log("PowerUp Count: " + abilityCount);
    }
}
