//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float GroundDistance = 0.2f;
    public LayerMask Ground;

    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
    private bool _isGrounded = true;
    private Transform _groundChecker;

    void Start()
    {
        _body = this.GetComponent<Rigidbody>();
        _groundChecker = transform.GetChild(0);
    }

    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        //_inputs.y = Input.GetAxis("Vertical");
        if (_inputs != Vector3.zero)
            transform.right = _inputs;



        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            Debug.Log("Yep");
            _body.AddForce(Vector3.up * Mathf.Sqrt(-0.5f * Physics.gravity.y), ForceMode.Force);
        }


        //// Trying to Limit Speed
        //if (transform.InverseTransformDirection(_body.velocity).y > 3f)
        //{
        //    _body.velocity = Vector3.ClampMagnitude(_body.velocity, 3f);
        //}
    }


    void FixedUpdate()
    {
        _body.MovePosition(_body.position + _inputs * Speed * Time.fixedDeltaTime);


        //float yVel = transform.InverseTransformDirection(_body.velocity).y;
        //if (yVel >= 3f)
        //{
        //    Vector3 vel = _body.velocity;
        //    vel.y = 3f;
        //    _body.velocity = vel;
        //}
    }
















    //public float speed;                //Floating point variable to store the player's movement speed.

    //public GameObject player;

    //private Rigidbody rb;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    //Get and store a reference to the Rigidbody2D component so that we can access it.
    //    rb = player.GetComponent<Rigidbody>();

    //}

    //void Update()
    //{
    //    float h = Input.GetAxis("Horizontal");
    //    float v = Input.GetAxis("Vertical");

    //    player.transform.position = new Vector2(transform.position.x + (h * speed),
    //       transform.position.y + (v * speed));
    //}

    //    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    //    void FixedUpdate()
    //{
    //    //Store the current horizontal input in the float moveHorizontal.
    //    float moveHorizontal = Input.GetAxis("Horizontal");
    //    //Store the current vertical input in the float moveVertical.
    //    float moveVertical = Input.GetAxis("Vertical");

    //    //Use the two store floats to create a new Vector2 variable movement.
    //    Vector3 movement = new Vector3(moveHorizontal, 0, 0);

    //    //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
    //    //rb.AddForce(movement * speed);

    //}
}
