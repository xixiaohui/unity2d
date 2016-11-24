using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float moveForce = 365f;			// Amount of force added to move the player left and right.
    public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        // Cache the horizontal input.
        float h = Input.GetAxis("Horizontal");

        //anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

        // If the player's horizontal velocity is greater than the maxSpeed...
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
            // ... set the player's velocity to the maxSpeed in the x axis.
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        float v = Input.GetAxis("Vertical");

        if (v * GetComponent<Rigidbody2D>().velocity.y < maxSpeed)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * v * moveForce);
        }

        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) > maxSpeed)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,Mathf.Sign(GetComponent<Rigidbody2D>().velocity.y)*maxSpeed);
        }
        


    }

    void OnGUI()
    {
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y,transform.position.z);
        //}
        //else if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);
        //}

        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        //}
        //else if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
        //}
        
    }
}
