using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Deer,
    Dog,
    Horse,
    Cow
}

public class EnemyController : MonoBehaviour
{
    public EnemyType enemyType;
    private float speed;
    private int health;
    private int score;
    private bool animationIsRun;
    

    void Start()
    {
        switch (enemyType)
        {
            case EnemyType.Deer:
                animationIsRun = false;
                speed = 250;
                health = 200;
                score = 1;
                break;
            case EnemyType.Dog:
                animationIsRun = true;
                speed = 300;
                health = 100;
                score = 2;
                break;
            case EnemyType.Horse:
                animationIsRun = true;
                speed = 300;
                health = 200;
                score = 5;
                break;
            case EnemyType.Cow:
                animationIsRun = false;
                speed = 150;
                health = 300;
                score = 5;
                break;
        }
    }
    void Update()
    {
        transform.position += Vector3.back * speed * 0.2f * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit " + other.tag);
        if (other.CompareTag("Projectile"))
        {
            Debug.Log("Hit " + health);
            health -= 25;
            if (health <= 0)
            {
                Destroy(gameObject);
                GameManager.instance.AddScore(score);
            }
        }

        if (other.CompareTag("Despawner"))
        {
            Destroy(gameObject);
        }
    }
}
