using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public int damage; //Unused for now
    public int points; 
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }
    public void removeHealth(int hp)
    {
        health -= hp;
        Debug.Log(health); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.tag);
    }
}
