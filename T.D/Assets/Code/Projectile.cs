using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target;
    public float speed = 10f;


    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) < 0.5f)
            {
                Destroy(target.gameObject);

                Destroy(gameObject);
            }
        }
    }
}
