using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpObjects : MonoBehaviour
{
    public enum PowerUpTypes
    {
        Godmode,
        Meat,
    }
    public PowerUpTypes type;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            if (type == PowerUpTypes.Godmode)
                ;//player.addGodmodeCharge()
            else if (type == PowerUpTypes.Meat)
                ;//player.addMeatCharge()
            //audioManager.PlaySFX(audioManager.coin);
        }
    }
}
