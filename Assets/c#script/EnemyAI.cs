using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;          // player reference
    public Transform pointA, pointB;  // patrol points
    public float moveSpeed = 2f;      // enemy movement speed
    public float chaseRange = 5f;     // how close player must be to trigger chase
    public float stopRange = 7f;      // when to stop chasing

    private Transform targetPoint;    // current patrol target
    private bool chasing = false;

    void Start()
    {
        targetPoint = pointA; // start by going to point A
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // --- Chase logic ---
        if (distanceToPlayer < chaseRange)
        {
            chasing = true;
        }
        else if (distanceToPlayer > stopRange)
        {
            chasing = false;
        }

        if (chasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

        // Switch direction when reached a patrol point
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            targetPoint = targetPoint == pointA ? pointB : pointA;
        }

        FaceDirection(targetPoint.position);
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * 1.5f * Time.deltaTime);
        FaceDirection(player.position);
    }

    void FaceDirection(Vector3 target)
    {
        if (target.x > transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }
}