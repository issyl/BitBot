﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    private PlayerMovement move;
    private PlayerStates ps;
    private AudioManager am;
    private AnimationScript anim;
    public bool contact = false;
    public float x = 3;
    public float y = 1;
    void Start()
    {
        move = GetComponentInParent<PlayerMovement>();
        ps = GetComponentInParent<PlayerStates>();
        anim = FindObjectOfType<AnimationScript>();
        am = FindObjectOfType<AudioManager>();
    }

    void FixedUpdate()
    {
        if(contact)
        {
            move.canMove = false;
            StartCoroutine(Pause());
            ps.DecreaseCurrentHealth(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy Projectile"))
        {
            contact = true;
        }
    }

    IEnumerator Pause()
    {
        contact = false;
        am.PlaySound("Player Hit");
        anim.TriggerAnim("Hurt");
        
        move.Knockback(x, y);
        Time.timeScale = 0.01f;
        yield return new WaitForSecondsRealtime(0.15f);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.35f);
        move.canMove = true;
    }
}
