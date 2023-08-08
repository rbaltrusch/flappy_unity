using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidPipe : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("side collision");
        other.GetComponent<Player>()?.Kill();
    }
}
