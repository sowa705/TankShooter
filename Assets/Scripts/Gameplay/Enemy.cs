using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health;

    public float MaxHealth;
    public float Speed;
    public float SpawnProbability;
    public uint XPValue;
    public uint PointValue;

    public GameObject Obj;
    GameManager gameManager;

    IEnemyBehaviour behaviour;

    void Start()
    {
        gameManager=FindObjectOfType<GameManager>();
        behaviour = GetComponent<IEnemyBehaviour>();
        Health = MaxHealth;

        GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0,1);
    }


    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * Time.deltaTime * Speed;

        if (transform.position.z<-36)
        {
            behaviour.OnLineReached();
            gameManager.RemoveLife();
            Destroy(gameObject);
        }
    }

    public void ApplyDamage(float damagevalue)
    {
        Health -= damagevalue;
        behaviour.OnDamage();

        if (Health<=0)
        {
            gameManager.AddPoints(PointValue);
            gameManager.AddXp(XPValue);
            behaviour.OnDeath();
            Destroy(gameObject);
        }
    }
    public void AddHealth(float health)
    {
        Health += health;
        if (Health > MaxHealth)
        {
            health = MaxHealth;
        }
    }
}
