using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSphereEnemy : MonoBehaviour,IEnemyBehaviour
{
    public void OnDamage()
    {
        Debug.Log("Big sphere: spheres slowed down");

        var smallSpheres = FindObjectsOfType<SmallSphereEnemy>();
        var bigSpheres = FindObjectsOfType<BigSphereEnemy>();

        foreach (var item in smallSpheres)
        {
            var enemy = item.GetComponent<Enemy>();
            enemy.Speed *= 0.9f;
        }

        foreach (var item in bigSpheres)
        {
            var enemy = item.GetComponent<Enemy>();
            enemy.Speed *= 0.9f;
        }
    }

    public void OnDeath()
    {
    }

    public void OnLineReached()
    {
    }
}
