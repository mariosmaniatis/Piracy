using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P_Movement : MonoBehaviour {

    public float speed;
    private float speed_fixed;
    private Rigidbody rigid;
    private Vector3 moveDirection;
    public bool crouch;
    public bool run;
    public float sound_making;
    public float jumpForce = 10;
    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        speed_fixed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (horizontal != 0 || vertical != 0)
        {
            //gameObject.GetComponent<AudioSource>().volume = 0.2f;
        } else
        {
            //gameObject.GetComponent<AudioSource>().volume = 0;

        }
        sound_making = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("mainmenu", LoadSceneMode.Single);
        }
        //moveDirection = (horizontal * transform.right + vertical * transform.forward).normalized;
        moveDirection = new Vector3(horizontal, 0f, vertical);
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0.0f;
        if (Input.GetKeyDown(KeyCode.C))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump() == true)
            {
                // player_object.GetComponent<Animator>().SetBool("Jumping", true);
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {

        Move();
        if (crouch)
        {
            speed = speed_fixed / 3;
            gameObject.GetComponent<CapsuleCollider>().height = 1;
        }
        else
        {
            speed = speed_fixed;
            gameObject.GetComponent<CapsuleCollider>().height = 2;
        }
    }

    void Move()
    {
        Vector3 yVelFix = new Vector3(0, rigid.velocity.y, 0);
        rigid.velocity = moveDirection * speed * Time.deltaTime;
        rigid.velocity += yVelFix;
    }

    void Crouch()
    {
        if (crouch)
        {
            crouch = false;
        }
        else
        {
            crouch = true;
        }
    }

    bool canJump()
    {
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), -Vector3.up, 1))
        {
            return true;
        }

        return false;
    }

    void Jump()
    {
        //Vector3 tmp = rigid.velocity;
        //tmp.y += jumpForce;
        //rigid.velocity = tmp;
        rigid.AddForce(Vector3.up * jumpForce);
    }
}
