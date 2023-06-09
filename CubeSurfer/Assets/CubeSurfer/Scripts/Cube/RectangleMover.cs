

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RectangleMover : MonoBehaviour
{
    public float speed = 5.0f;
    public float horizontalLimit = 5.0f;
    private int direction = 1;

    void Update()
    {
        float newPositionX = transform.position.x + (direction * speed * Time.deltaTime);
        if (newPositionX > horizontalLimit || newPositionX < -horizontalLimit)
        {
            direction *= -1;
        }
        else
        {
            transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
        }
    }
}