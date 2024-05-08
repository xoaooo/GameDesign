using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpObjects : MonoBehaviour
{
    private PlayerStatistics statistics;

    void Start()
    {
        statistics = FindObjectOfType<PlayerStatistics>();
    }
    public enum PowerUpTypes
    {
        Godmode,
        Meat,
        Health,
    }
    public PowerUpTypes type;
    private const float healthRestoreAmount = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            if (type == PowerUpTypes.Godmode)
            {
                GodMode player = collision.gameObject.GetComponent<GodMode>();
                player.AddGodModeCharge();
            }
            else if (type == PowerUpTypes.Meat)
            {
                DropFood player = collision.gameObject.GetComponent<DropFood>();
                player.AddMeatCharge();
            }
            else if (type == PowerUpTypes.Health)
            {
                CharacterHealth player = collision.gameObject.GetComponent<CharacterHealth>();
                player.RestoreHealth(healthRestoreAmount);
            }

            statistics.powerUpCount++;

        }
    }
}
