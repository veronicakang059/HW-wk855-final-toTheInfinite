using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{
    
    //make ship an singleton
    public static ShipController instance;
    Rigidbody2D rb2d;
    public float forceAMT = 5f;
    public KeyCode defense;
    public KeyCode absorb;

    public float healthAmt=100;
    public float scoreAmt=0;

    public TextMesh HealthText;
    
    BaseShield shield;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        shield = GetComponent<BaseShield>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddForce(Vector2.left*forceAMT);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddForce(Vector2.right*forceAMT);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Destroy(shield);
            shield = gameObject.AddComponent<BaseShield>();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Destroy(shield);
            shield = gameObject.AddComponent<AborbShield>();
        }

        if (healthAmt < 0)
        {
            Reset();
        } else if (scoreAmt > 10 && healthAmt>50)
        {
            //youWIN = true;
            Debug.Log("you win");
        }

    }

    public void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.name.Contains("enermy"))
        {
            Destroy(other.gameObject);
            Destroy(shield);
            TakeDamage(50);
            Debug.Log("hit");
            
        } else if (other.gameObject.name.Contains("StarBuff"))
        {
            Destroy(other.gameObject);
            Destroy(shield);
            GainStar(10);
            //TakeDamage(-10);
        }
    }
    

    public void TakeDamage(float damageAMT)
    {
        if (shield != null)
        {
            damageAMT = shield.AdjustDamage(damageAMT);
        }
        healthAmt -= damageAMT;
        scoreAmt -= 1;
        HealthText.text = "Health:" + healthAmt + "\nScore" + scoreAmt;

    }

    public void GainStar(float amt)
    {
        
        healthAmt += amt;
        scoreAmt += 1;
        HealthText.text = "Health:" + healthAmt + "\nScore" + scoreAmt;
    }

    public void Reset()
    {
        SceneManager.LoadScene(1);
        healthAmt = 100;
        scoreAmt = 0;

    }
}
