using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGirlController : MonoBehaviour
{
    private Rigidbody2D rb; 
    private SpriteRenderer sr;
    private int estaEnSuelo = 0; 
    public float JumpForceZombie=1; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
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
