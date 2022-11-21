using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerMove;

    public float horizontalInput;
    public float verticalInput;
    
    public float speed = 10.0f; //set as public for now
    public float rotationSpeed = 220.0f;// how fast character turn when press A, D

    //click to attack
    public bool oneClick = false;
    private float lastClickTime; // capture last time click
    private const float doubleClickTime = 0.3f; // duration of time allows to double click


    // Start is called before the first frame update
    void Start()
    {
        
        playerMove = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * rotationSpeed);

        //Movement Action
        playerMovementCommand();

        //Attack command
        playerAttackCommand();


    }
    private void playerMovementCommand()
    {
        //Running command

        if (playerMove != null)
        {
            //running forward
            if (Input.GetKeyDown(KeyCode.W))
            {
                playerMove.Play("Run_SwordShield");

            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                playerMove.SetTrigger("Idle");
            }
            //running backward
            if (Input.GetKeyDown(KeyCode.S))
            {
                playerMove.Play("Run_SwordShield_Backward");
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                playerMove.SetTrigger("Idle");
            }
        }
    }
    private void playerAttackCommand()
    {
        //With click and couble click
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float timeSinceLastClick = Time.time - lastClickTime;
            if (timeSinceLastClick <= doubleClickTime)
            {
                playerMove.SetTrigger("doubleHit");
                playerMove.SetLayerWeight(1, 1);
                new WaitForSeconds(1.5f);
            }
            else
            {
                playerMove.SetTrigger("oneHit");
                playerMove.SetLayerWeight(1, 1);
                Debug.Log("OneHit!");
            }
            lastClickTime = Time.time;

        }
    }
}
