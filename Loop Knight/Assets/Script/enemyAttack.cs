using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    private Animator enemy;

    //Get the player sword object
    private GameObject sword;

    // Start is called before the first frame update
    void Start()
    {
        enemy.GetComponent<Animator>();
        sword = GameObject.FindWithTag("Sword");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void enemyGetHit()
    {

    }
}
