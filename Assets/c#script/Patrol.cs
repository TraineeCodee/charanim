using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] float speed = 2f;

    [Header("Patrol Range (World X)")]
    [SerializeField] float leftPoint = -3f;
    [SerializeField] float rightPoint = 1f;

    bool movingRight = true;

    void Update()
    {
        float moveDir = movingRight ? 1f : -1f;
        transform.Translate(Vector2.right * moveDir * speed * Time.deltaTime, Space.World);

        // Reach right limit
        if (transform.position.x >= rightPoint)
        {
            movingRight = false;
            Flip();
        }
        // Reach left limit
        else if (transform.position.x <= leftPoint)
        {
            movingRight = true;
            Flip();
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (movingRight ? 1 : -1);
        transform.localScale = scale;
    }
}
