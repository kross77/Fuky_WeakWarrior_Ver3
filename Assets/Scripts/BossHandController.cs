﻿using UnityEngine;
using System.Collections;

public class BossHandController : MonoBehaviour {

    [Range(0.0f, 2.0f)]
    public float speedAttack;
    public bool isAttacked;
    public bool colPlayer;
    private Rigidbody2D rb2dHandLeft;
    private Rigidbody2D rb2dHandRight;
    //private Rigidbody2D rb2dHand;
    //public Rigidbody2D Rb2dHand
    //{
    //    get { return rb2dHand; }
    //    set { rb2dHand = value; }
    //}
    public PlayerController playerController;
    bool check;

    public BossController bossController;

    void Start()
    {
        rb2dHandLeft = GameObject.Find("BossLeftHand").GetComponent<Rigidbody2D>();
        rb2dHandRight = GameObject.Find("BossRightHand").GetComponent<Rigidbody2D>();
        //rb2dHand.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        TurnBack(check);        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            colPlayer = true;
            TouchPlayer(check);
            //TouchPlayer();
        }
        if (col.tag == "DeathArea" || col.tag == "DeathAreaSkill")
        {
            TouchPlayerAttack(check);
            //TouchPlayerAttack();
            bossController.HurtEnemy();
        }
    }

    public void AttackHand(bool left)
    {
        if (left)
        {
            rb2dHandLeft.velocity = new Vector2(speedAttack, 0f);
            check = true;
        }
        else
        {
            rb2dHandRight.velocity = new Vector2(-speedAttack, 0f);
            check = false;
        }
    }

    //public void AttackHand()
    //{
    //        rb2dHand.velocity = new Vector2(speedAttack, 0f);
    //}

    void TouchPlayerAttack(bool left)
    {
        if (left)
        {
            isAttacked = true;
            rb2dHandLeft.velocity = new Vector2(-speedAttack / 2, 0f);
            playerController.notMiss = true;
        }
        else
        {
            isAttacked = true;
            rb2dHandRight.velocity = new Vector2(speedAttack / 2, 0f);
            playerController.notMiss = true;
        }
    }

    //public void TouchPlayerAttack()
    //{
    //    rb2dHand.velocity = new Vector2(-speedAttack / 2, 0f);
    //    playerController.notMiss = true;
    //}

    void TouchPlayer(bool left)
    {
        if (left)
        {
            rb2dHandLeft.velocity = new Vector2(-speedAttack / 2, 0f);
            playerController.state--;
            playerController.UpdateState(playerController.state);
        }
        else
        {
            rb2dHandRight.velocity = new Vector2(speedAttack / 2, 0f);
            playerController.state--;
            playerController.UpdateState(playerController.state);
        }
    }  

    //public void TouchPlayer()
    //{
    //    rb2dHand.velocity = new Vector2(-speedAttack / 2, 0f);
    //    playerController.state--;
    //    playerController.UpdateState(playerController.state);
    //}

    void TurnBack(bool left)
    {
        if (left)
        {
            if ((colPlayer == true && transform.position.x <= -3f)
                || (isAttacked == true && transform.position.x <= -3f))
            {
                rb2dHandLeft.velocity = Vector2.zero;
                colPlayer = false;
                isAttacked = false;
            }
        }
        else
        {
            if ((colPlayer == true && transform.position.x >= 3f)
                || (isAttacked == true && transform.position.x >= 3f))
            {
                rb2dHandRight.velocity = Vector2.zero;
                colPlayer = false;
                isAttacked = false;
            }
        }
    }
    //public void TurnBack()
    //{
    //    if ((colPlayer == true && transform.position.x <= -3f)
    //        || (isAttacked == true && transform.position.x <= -3f)
    //        || (colPlayer == true && transform.position.x >= 3f)
    //        || (isAttacked == true && transform.position.x >= 3f))
    //    {
    //        rb2dHand.velocity = Vector2.zero;
    //        colPlayer = false;
    //        isAttacked = false;
    //    }
    //}
	
}
