using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaGirlController : MonoBehaviour
{
    public float velocityX;
    public float JumpForce; 
    
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;

    private const int Run = 0;
    private const int Jump = 1;
    private const int Dead = 2;

    private bool estaMuerto = false; 
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!estaMuerto)
        {
            rb.velocity = new Vector2(7, rb.velocity.y);
            animator.SetInteger("Estado",0);
        
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rb.AddForce(Vector2.up*JumpForce, ForceMode2D.Impulse);
                changeAnimation(Jump);
            } 
        }
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Caminar") || collision.gameObject.CompareTag("Saltando") ){ 
            estaMuerto = true;
            changeAnimation(Dead);
        
        }
     
    }
    
    
    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
    

}
