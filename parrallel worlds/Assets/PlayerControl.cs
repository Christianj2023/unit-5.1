using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpheight;
    public float movespeed;
    public float dirX;
    private bool jumpable;
    public int hascoins;
    public Animator animator;
    public bool isFacingRight = true;
    private Vector3 localScale;
    private int portalCooldown = 0;
    public float portalOneX;
    public float portalOneY;
    public float portalTwoX;
    public float portalTwoY;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        localScale = transform.localScale;
    }

   
    // Update is called once per frame
    void Update()
    {   
        dirX = Input.GetAxisRaw("Horizontal") * movespeed;
        if (portalCooldown > 0)
        {
        	portalCooldown = portalCooldown - 1;
        }

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
        if(Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
           animator.SetBool("Running", true);
        else
            animator.SetBool("Running", false);

        if(rb.velocity.y == 0)
        {
            animator.SetBool("jumping", false);
        }
        if(rb.velocity.y > 0)
        {
            animator.SetBool("jumping", true);
        }
        
        if(isFacingRight && movespeed < 0)
        {
            Flip();
    	}

    void Fixedupdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }
    void Flip()
    {
        if (dirX > 0)
            isFacingRight = true;
        else if (dirX < 0)
            isFacingRight = false;
        if (((isFacingRight) && (localScale.x < 0)) || ((!isFacingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
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
        if (trigger.gameObject.CompareTag("portal") && portalCooldown == 0)
        {
            portalCooldown = 300;
            transform.position = new Vector3(portalOneX,portalOneY,0f);
        }
        if (trigger.gameObject.CompareTag("portal 2") && portalCooldown == 0)
        {
            portalCooldown = 300;
            transform.position = new Vector3(portalTwoX,portalTwoY,0f);
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

