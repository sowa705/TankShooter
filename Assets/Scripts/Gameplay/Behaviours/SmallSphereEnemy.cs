using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSphereEnemy :MonoBehaviour, IEnemyBehaviour
{
    public void OnDamage()
    {
        Debug.Log("Big sphere: small spheres speeded up");
        var spheres = FindObjectsOfType<SmallSphereEnemy>();

        foreach (var item in spheres)
        {
            var enemy = item.GetComponent<Enemy>();
            enemy.Speed *= 1.1f;
        }
    }

    public void OnDeath()
    {
    }

    public void OnLineReached()
    {
    }
}
