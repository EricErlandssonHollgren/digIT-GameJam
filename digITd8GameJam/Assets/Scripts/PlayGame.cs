using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{

    [ContextMenu("Open")]
    public void LoadGame()
    {
        SceneManager.LoadScene(0);
    }
}
