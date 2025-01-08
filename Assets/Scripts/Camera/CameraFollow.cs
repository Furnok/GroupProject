using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private RSO_PlayerPos playerPos;

    [SerializeField] private Vector3 offset;
    [SerializeField] private float speed;

    private void Update()
    {
        Move();
    }

    /// <summary>
    /// Move the Camera to the Player
    /// </summary>
    private void Move()
    {
        Vector3 targetPosition = new Vector3(playerPos.Value.x + offset.x, playerPos.Value.y + offset.y, playerPos.Value.z + offset.z);
        transform.position = targetPosition;
    }
}
