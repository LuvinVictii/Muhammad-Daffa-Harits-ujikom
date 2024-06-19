using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 350f;
    public GameObject projectilePrefab;

    void Update()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }
        float movement = Input.GetAxis("Horizontal");

        transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Throw();
        }
    }

    void Throw()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Destroy(projectile, 3f);
    }
}
