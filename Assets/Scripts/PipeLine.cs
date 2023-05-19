using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeLine : MonoBehaviour
{
    public float MoveSpeed = 2.0f;

    [SerializeField]
    private float destoryX = -4.5f;

    void Update()
    {
        transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);

        if (transform.position.x < destoryX)
            Destroy(gameObject);
    }
}
