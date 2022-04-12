using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed=10f;
    Rigidbody rb;
    public bool Explosive;
    public GameObject ExplosionPS;
    float DamageMultiplier;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        DamageMultiplier = FindObjectOfType<GameManager>().CurrentLevelConfig.DamageMultiplier;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time>30f)
        {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Y)&& Explosive)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.position += transform.forward*Speed*Time.deltaTime;
    }

    private void OnDestroy()
    {
        Destroy(Instantiate(ExplosionPS, transform.position, Quaternion.identity), 2f);

        if (!Explosive)
        {
            return;
        }
        var colliders = Physics.OverlapSphere(transform.position, 10);

        foreach (var item in colliders)
        {
            var enemy = item.GetComponentInParent<Enemy>();
            if (enemy != null)
            {
                enemy.ApplyDamage((DamageMultiplier * 100) / Vector3.Distance(transform.position, enemy.transform.position));
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var enemy = collision.collider.GetComponentInParent<Enemy>();
        if (enemy==null)
        {
            return;
        }

        enemy.ApplyDamage((DamageMultiplier * 5));
        Destroy(gameObject);
    }
}
