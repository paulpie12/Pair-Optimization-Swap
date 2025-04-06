using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{


    private void Start()
    {
    }

    void Update()
    {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    Application.LoadLevel(0);
                }
    }
}