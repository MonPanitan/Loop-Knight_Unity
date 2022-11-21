using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    private GameObject player;
    private Animator enemyAction;
    private Rigidbody enemyRb;

    private float speed = 2.0f;

    //Player Position
    private Vector3 playerPos;

    //Attack player
    private float attackDistance = 3.0f;
    public float attackTimer; // Cooldown time after attack //TEST
    private float coolDown; // Cooldown time to set to be able to attack //


    //Check the distance
    public float distanceBetween;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyAction = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody>();
        attackTimer = 0;
        coolDown = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Keep updating player position
        playerPos = player.transform.position; // get a player position

        distanceBetween = Vector3.Distance(transform.position, playerPos);

        //Looking at player
        Vector3 lookDirection = (playerPos - transform.position).normalized;
        transform.LookAt(playerPos);

        if (distanceBetween < 20)
        {
            playerPos.y = 0; //Ignore height
            
            if(distanceBetween > 2)
            {
                moveToPlayer();
                if(distanceBetween < 2)
                {
                    enemyAction.SetTrigger("Idle");

                }
            }
            if (distanceBetween <= attackDistance)
            {
                if (attackTimer > 0) // Check if timer more than 0
                {
                    attackTimer -= Time.deltaTime; // will reduce timer every 1 unit per frame
                }
                if (attackTimer < 0)// Check if timer == 0. Will to allow to attack
                {
                    attackTimer = 0;
                }
                if (attackTimer == 0)
                {
                    enemyAction.SetLayerWeight(1, 1);
                    attack();
                    Debug.Log("Playet Got A HIT!!!");
                    attackTimer = coolDown;
                }
                

            }
        }
    }
    private void moveToPlayer()
    {
        //move enemy to player
        enemyAction.SetTrigger("Running");
        transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime); // move towards player position
        /*transform.rotation = player.transform.rotation;*/
        //transform.forward = playerPos - transform.position;//turn(facing) towards player // This make enemy glichy when near player
        
        

        
    }

    private void attack()
    {
        enemyAction.SetTrigger("attack1");
        
    }
}
