using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    public float horizontalInput;
    public float verticalInput;
    public float turnSpeed = 10;
    public float walkSpeed = 10f;
    private Animator ac;
  
    // Start is called before the first frame update
    void Start()
    {
        ac = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

      if (Input.GetKeyDown("space"))
        {
            ac.SetTrigger("jump");
        }

        if (verticalInput>0)
        {
            ac.SetBool("walk",true);
        }
         else {
             ac.SetBool("walk", false);
         }



        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * walkSpeed);
        //transform.Translate(-Vector3.left * Time.deltaTime * horizontalInput);
        transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime); 
        

    }
}
