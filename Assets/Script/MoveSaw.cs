using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSaw : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;

    }

    private void EnemyMove()
    {
        // mengecek jika kecepatan yang diberikan di inspector < 0 atau tidak
        if (speed < 0)
        {
            movingLeft = true; // jika iya maka saw object akan bergerak ke kiri
            speed *= -1; //  dan speed dikalikan dengan -1 agar rumus di bawah dapat bekerja dengan baik
            SoundManager.PlaySound("saw");
        }

        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = false;
            }
        }

        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }
}
