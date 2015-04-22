﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb2d;
    private Animator animatorEnemy;
    public int HPEnemy;

    private int attackEnemyState;

    //private Transform frontCheck;
    private bool attackEnemy;

    public GameObject attackArea;

    void Start()
    {
        animatorEnemy = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        //frontCheck = transform.Find("frontCheck").transform;
        attackEnemyState = Animator.StringToHash("attackEnemy");
    }

    //void FixedUpdate()
    //{
    //    Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position);
    //    foreach (Collider2D col in frontHits)
    //    {
    //        //Enemy1 chạm và đánh Player
    //        if (col.tag == "Player")
    //        {
    //            animatorEnemy.SetTrigger(attackEnemyState);
    //            rb2d.velocity = new UnityEngine.Vector2(0f, 0f);
    //        }
    //    }
    //    if (HP <= 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    void Update()
    {
        //Enemy1 bị chém trúng
        if (HPEnemy <= 0)
        {
            Destroy(gameObject);
        }
    }

    void HurtEnemy()
    {
        HPEnemy--;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            animatorEnemy.SetTrigger(attackEnemyState);
            rb2d.velocity = new Vector2(0f, 0f);
        }
        if (col.tag == "DeathArea")
        {
            HurtEnemy();
        }
    }

    public void SetVellocity(bool left)
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (left)
        {
            transform.localScale = new Vector2(1, 1);
            rb2d.velocity = new Vector2(speed, 0f);
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
            rb2d.velocity = new Vector2(-speed, 0f);
        }
    }
    public void AttackOff()
    {
        attackEnemy = false;
        attackArea.SetActive(false);
    }
    public void AttackOn()
    {
        attackEnemy = true;
        attackArea.SetActive(true);
    }

}
