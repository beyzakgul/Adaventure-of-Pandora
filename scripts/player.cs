using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidbody;
    public float jumpspeed;
    public int life;
    public float damagedTime;
    public Color normalColor;
    public Color damageColor;
    public Text LifeText;

    void Start()
    {
        normalColor = gameObject.GetComponent<SpriteRenderer>().color;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameObject.transform.Find("foot").GetComponent<GroundCheck>().isGrounded)
        {
            rigidbody.AddForce(new Vector2(0, jumpspeed));
        }
        if(damagedTime > 0)
        {
            damagedTime-=Time.deltaTime;
            if (gameObject.GetComponent<SpriteRenderer>().color == normalColor)
            {
                gameObject.GetComponent<SpriteRenderer>().color = damageColor;
            }
        }
        else
        {
           if( gameObject.GetComponent<SpriteRenderer>().color == damageColor)
            {
                gameObject.GetComponent<SpriteRenderer>().color = normalColor;
            }
        }

    }
    void FixedUpdate()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = new Vector2(hor * speed, rigidbody.velocity.y);
        if (hor > 0.1f)
        {
            gameObject.transform.localScale = new Vector3(Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, 0);
        }
        else if (hor < -0.1f)
        {
            gameObject.transform.localScale = new Vector3(-Mathf.Abs(gameObject.transform.localScale.x),gameObject.transform.localScale.y, 0);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="enemy"&& damagedTime<=0)
        {
            hit();
        }
    }

        private void onCollisionstay2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="enemy"&& damagedTime<=0)
        {
            hit();
        }
    }
     void hit() 
    {
        life--;
        LifeText.text = life.ToString(); 
        damagedTime = 0.7f;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.4f, gameObject.transform.position.z);
        if (life <= 0)
            SceneManager.LoadScene("oyun");
    }



}