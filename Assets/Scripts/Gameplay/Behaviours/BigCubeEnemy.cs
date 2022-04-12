using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCubeEnemy : MonoBehaviour, IEnemyBehaviour
{
    public void OnDamage()
    {
    }

    public void OnDeath()
    {
        Debug.Log("Big cube: health replenished");
        var enemies = FindObjectsOfType<Enemy>();

        foreach (var item in enemies)
        {
            if (item.Health<item.MaxHealth*0.5f)
            {
                item.AddHealth(item.MaxHealth);
            }
        }
    }

    public void OnLineReached()
    {
    }
}
