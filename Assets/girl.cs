using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class girl : MonoBehaviour
{
    public float jumpSpeed;
    Animator am;
    Rigidbody2D rb;
    int jump;

    public static girl instance;


    bool isGameover = false;
    [SerializeField] Image lifeFill;

    float life = 1;

    bool isDead = false;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        jump = 0;
        am = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
 
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Jump") && jump < 2)
        {
            jump++;
            am.SetBool("Jump", true);
            rb.velocity = new Vector2(rb.velocity.x, 5f);
        }

        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        am.SetBool("Jump", false);
        jump = 0;

        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "spike")
        {
            RemoveLife();
        }
        if (other.tag == "spikepop")
        {
            RemoveLife();
        }
        if (other.tag == "pipe")
        {
            RemoveLife();
        }
        
    }

    void RemoveLife()
    {
        if (life > 0f)
        {
            life -= 0.5f;
            lifeFill.fillAmount = life;
            gameObject.GetComponent<Animation>().Play("girl_redflash");
        }

        if (life <= 0f)
        {
            isGameover = true; 
            isDead = true;
            am.SetTrigger("isDead");
            StartCoroutine(DelayGame());
        }
    }
    IEnumerator DelayGame()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.9f);
            EditorApplication.isPaused = true;

        }
    }
    //Time.timeScale = 2;
    //Invoke("Restart", 0f);
}
        //EditorApplication.isPaused = true;
    
    //void Restart()
    //{
    //    SceneManager.LoadScene(5);
    //}

   






