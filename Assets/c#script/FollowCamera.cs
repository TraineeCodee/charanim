using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public Vector3 offset;

    public float minX = -45f;   // 🔒 left camera limit

    void LateUpdate()
    {
        if (!target) return;

        // Follow target
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(
            transform.position,
            desiredPos,
            smoothSpeed * Time.deltaTime
        );

        // 🔒 Lock camera X
        if (smoothedPos.x < minX)
            smoothedPos.x = minX;

        transform.position = new Vector3(
            smoothedPos.x,
            smoothedPos.y,
            transform.position.z
        );
    }
}
