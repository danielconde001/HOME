using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caterpillar : MonoBehaviour
{
    [SerializeField] private Transform[] moveAwaySpots;
    [SerializeField] private CatterpillarBody[] caterpillarBodies;
    [SerializeField] private float moveSpeed;
    
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool movingAway = false;
    private int moveAwaySpotIndex = 0;

    private void Awake()
    {
        // bodies = GetComponentsInChildren<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(12,12);
    }

    private void Update()
    {
        if (movingAway)
        {
            spriteRenderer.flipX = (moveAwaySpots[moveAwaySpotIndex].position - transform.position).normalized.x < 0 ? false : true;
            transform.position = Vector2.MoveTowards(transform.position, moveAwaySpots[moveAwaySpotIndex].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveAwaySpots[moveAwaySpotIndex].position) < 0.2f)
            {
                if (moveAwaySpotIndex >= moveAwaySpots.Length-1)
                {
                    gameObject.SetActive(false);
                    for (int i = 0; i < caterpillarBodies.Length; i++)
                    {
                        caterpillarBodies[i].gameObject.SetActive(false);
                    }
                }
                moveAwaySpotIndex++;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<ProjectileBehavior>())
        {
            Destroy(col.gameObject);
            animator.CrossFadeInFixedTime("CaterpillarHurt", 0.01f);
        }

        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerHealth>().Die();
        }
    }

    private void MoveAway()
    {
        movingAway = true;
        for (int i = 0; i < caterpillarBodies.Length; i++)
        {
            caterpillarBodies[i].FollowingHead = true;
            caterpillarBodies[i].MoveSpeed = moveSpeed;

            if (i == 0)
            {
                caterpillarBodies[i].BodyPartner = transform; 
            }
            else
            {   
                caterpillarBodies[i].BodyPartner = caterpillarBodies[i-1].transform; 
            }
        }
    }
}
