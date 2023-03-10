using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpheight;
    public float movespeed;
    private bool jumpable;
    public int hascoins;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
    		{
    			rb.transform.Translate(Vector2.right * movespeed);
    		}
    	if (Input.GetKey(KeyCode.LeftArrow))
    		{
    			rb.transform.Translate(Vector2.left * movespeed);
    		}
    	if (Input.GetKeyDown(KeyCode.UpArrow) && jumpable == true)
    		{
            	rb.AddForce(Vector2.up * jumpheight, ForceMode2D.Impulse);
    		}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            jumpable = true;
        }
        if (collision.gameObject.CompareTag("coin"))
        {
        	collision.gameObject.SetActive(false);
        	hascoins += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("coin"))
        {
        	trigger.gameObject.SetActive(false);
        	hascoins += 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            jumpable = false;
        }
    }

}

