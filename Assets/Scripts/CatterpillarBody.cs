using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatterpillarBody : MonoBehaviour
{
    private Transform bodyPartner;
    private bool followingHead = false;
    private float moveSpeed;
     private SpriteRenderer spriteRenderer;

    public bool FollowingHead
    {
        get
        {
            return followingHead;
        }
        set 
        {
            followingHead = value;
        }
    }

    public Transform BodyPartner
    {
        get
        {
            return bodyPartner;
        }
        set 
        {
            bodyPartner = value;
        }
    }

    public float MoveSpeed
    {
        get {return moveSpeed;}
        set {moveSpeed = value;}
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    } 

    private void Update()
    {
        if(followingHead)
        {
            spriteRenderer.flipX = (bodyPartner.position - transform.position).normalized.x < 0 ? false : true;
            transform.position = Vector2.MoveTowards(transform.position, BodyPartner.position, moveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerHealth>().Die();
        }
    }
}
