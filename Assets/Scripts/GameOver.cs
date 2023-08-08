using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    [SerializeField] private GameObject canvas;
    [SerializeField] private Player player;

    private void Start()
    {
        canvas.SetActive(false);
        RegisterDeathHandler();
    }

    private void RegisterDeathHandler()
    {
        player.DeathEvent += (sender, args) => { OnDeathEvent(); };
    }

    private void OnDeathEvent()
    {
        canvas.SetActive(true);
        Debug.Log("received on death event");
    }
}
