using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject BulletPrefab;
    public GameObject ExplosiveBulletPrefab;

    GameObject currentExplosiveBullet;

    public float SpecialCooldown;
    GameManager gameManager;
    void Start()
    {
        gameManager=FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Input.GetAxis("Horizontal")*Time.deltaTime*10;
        SpecialCooldown-=Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BulletPrefab,transform.position,Quaternion.identity);
        }
        if (SpecialCooldown<0&&currentExplosiveBullet == null&&Input.GetKeyDown(KeyCode.Y))
        {
            SpecialCooldown=gameManager.CurrentLevelConfig.SpecialCooldown;

            currentExplosiveBullet =Instantiate(ExplosiveBulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
