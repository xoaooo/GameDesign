using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpObjects : MonoBehaviour
{
    public enum PowerUpTypes
    {
        Godmode,
        Meat,
        Health,
    }
    public PowerUpTypes type;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            if (type == PowerUpTypes.Godmode)
            {
                //player.addGodmodeCharge()
                GodMode player = collision.gameObject.GetComponent<GodMode>();
                player.AddGodModeCharge();
            }
            else if (type == PowerUpTypes.Meat)
            {
                DropBone player = collision.gameObject.GetComponent<DropBone>();
                player.AddMeatCharge();
                //player.addMeatCharge()
            }
        }
    }
}
