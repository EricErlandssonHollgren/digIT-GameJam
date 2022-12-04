using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    public float timer;
    public Volume vol; 
    public LensDistortion lensDistortion;
    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    public GameObject dim1;
    public GameObject dim2;
    public int activeCheckpointIndex;
    public List<GameObject> checkpoints;
    private bool inAir;
    public int health;
    [SerializeField] private AudioSource _warpSound;
    [SerializeField] private AudioSource _jumpSound;
    
    void Start()
    {
        //URP
        vol.profile.TryGet<LensDistortion>(out lensDistortion);

        health = 200;
        activeCheckpointIndex = 0; 
        checkpoints.AddRange(GameObject.FindGameObjectsWithTag("Tjackis"));
        dim1.SetActive(true);
        dim2.SetActive(false);
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    }

    public void setActiveCheckpoint(GameObject g)
    {
        activeCheckpointIndex = checkpoints.IndexOf(g);
    }

    public void removeHP(int hp)
    {
        health -= hp;
    }

    // Update is called once per frame
    void Update()
    {
        //Health
        if(health <= 0)
        {
            gameObject.transform.position = checkpoints[activeCheckpointIndex].transform.position;
            health = 200;
        }
        
        //Movement
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            jump = true;
            
            animator.SetBool("jump", true);
            if (!inAir)
            {
                _jumpSound.Play();
            }
            inAir = true;
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            crouch = true;
        } else if (Input.GetKeyUp(KeyCode.S)) {
            crouch = false;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            _warpSound.Play();
            StartCoroutine(wait());
            // vol.GetComponent<Animator>().SetTrigger("StopTransition");
        }
    }

    IEnumerator wait()
    {
        vol.GetComponent<Animator>().SetTrigger("StartTransition");
        yield return new WaitForSeconds(0.3f);
        if (dim1.activeSelf)
        {
            dim1.SetActive(false);
            dim2.SetActive(true);
        }
        else
        {
            dim1.SetActive(true);
            dim2.SetActive(false);
        }
       
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void OnLand() 
    {
        animator.SetBool("jump", false);
        inAir = false;
    }

    
}
