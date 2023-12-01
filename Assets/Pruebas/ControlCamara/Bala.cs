using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 targetPos;
    public Vector3 startingPos;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);

    }

    private void Update()
    {

        Vector3 move = (targetPos - startingPos).normalized;
        transform.position += (move * speed * Time.deltaTime);



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

    }
}
