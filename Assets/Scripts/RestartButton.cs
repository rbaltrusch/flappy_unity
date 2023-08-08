using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{


    private void Start()
    {
        this.GetComponent<Button>()?.onClick.AddListener(
            () => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex)
        );
    }
}
