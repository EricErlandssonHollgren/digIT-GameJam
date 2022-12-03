using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPLayer : MonoBehaviour
{
    public GameObject playerPrefab;
    private void Start()
    {
        
        var player = GameObject.FindGameObjectWithTag("Player");
        
        if (player == null)
        {
            var player2 = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            var cam = GameObject.FindGameObjectWithTag("MainCamera");
            cam.GetComponent<PlayerCamera>().target = player2;
        }
        else
        {
            var cam = GameObject.FindGameObjectWithTag("MainCamera");
            cam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);

            cam.GetComponent<PlayerCamera>().target = player;
        }
    }
}
