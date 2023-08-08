using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float despawnX;

    private void Update()
    {
        Vector2 moved = Vector2.left * speed * Time.deltaTime;
        transform.position += new Vector3(moved.x, moved.y, 0);
        if (transform.position.x < despawnX)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("middle collision");
        other.GetComponent<Player>()?.AddPoints(1);
    }
}
