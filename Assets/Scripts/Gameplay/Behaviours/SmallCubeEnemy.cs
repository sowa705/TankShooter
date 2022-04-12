using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCubeEnemy : MonoBehaviour,IEnemyBehaviour
{
    public void OnDamage()
    {
    }

    public void OnDeath()
    {
    }

    public void OnLineReached()
    {
        Debug.Log("Small cube: health replenished for cubes");

        var smallCubes = FindObjectsOfType<SmallCubeEnemy>();
        var bigCubes = FindObjectsOfType<BigCubeEnemy>();

        foreach (var item in smallCubes)
        {
            var enemy = item.GetComponent<Enemy>();
            enemy.AddHealth(enemy.MaxHealth * 0.1f);
        }
        foreach (var item in bigCubes)
        {
            var enemy = item.GetComponent<Enemy>();
            enemy.AddHealth(enemy.MaxHealth * 0.1f);
        }
    }
}
