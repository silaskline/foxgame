using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{

    public float moveSpeed = 3.75f;

    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    Scene scene;


    void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Game")
        {
            Debug.Log("Starting " + scene.name + " at " + StaticVars.mainLocation);
            //RigidbodyInterpolation2D interpolation = rb.interpolation;
            //rb.interpolation = RigidbodyInterpolation2D.None;
            //rb.gameObject.SetActive(false);
            rb.position = StaticVars.mainLocation;
            //rb.gameObject.transform.position = StaticVars.mainLocation;
            //rb.gameObject.SetActive(true);
            //rb.interpolation = interpolation;
        }
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Vertical") < 0)
        {
            //this ignores centered / 0 values so the last direction used stays with idle
            animator.SetFloat("IdleHorizontal", movement.x);
            animator.SetFloat("IdleVertical", movement.y);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (scene.name == "Game")
        {
            StaticVars.mainLocation = rb.position;
        }

    }

}
