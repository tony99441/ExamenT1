using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMenController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
   
    private int estaEnSuelo = 0; 
    public float JumpForceZombie=1;
    public int contador = 0; 
   
  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        sr.flipX = true;
        if (estaEnSuelo ==1 && tag =="Saltando")
        {
            rb.AddForce(Vector2.up*JumpForceZombie, ForceMode2D.Impulse);
            estaEnSuelo = 0;
        }

        if (tag =="Caminar")
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

        }

      

        if (estaEnSuelo ==1 && tag =="SaltaAmbosLados")
        { 
            sr.flipX = false;
            rb.velocity = new Vector2(2, rb.velocity.y);
            rb.AddForce(Vector2.up*JumpForceZombie, ForceMode2D.Impulse);
            estaEnSuelo = 0;
            
        }
        
        if (estaEnSuelo ==1 && tag =="SaltaAmbosLados")
        { 
            sr.flipX = true;
            rb.velocity = new Vector2(-2, rb.velocity.y);
            rb.AddForce(Vector2.up*JumpForceZombie, ForceMode2D.Impulse);
            estaEnSuelo = 0;
            
        }

        










    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            estaEnSuelo = 1;
           
        }
    }
    
}
