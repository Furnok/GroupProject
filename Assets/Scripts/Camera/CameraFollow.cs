using UnityEngine;
using static RSO_PlayerForm;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSO_PlayerForm playerForm;
    [SerializeField] private RSO_PlayerPos playerPos;

    [Header("Parameters")]
    [SerializeField] private Vector3 offsetHuman;
    [SerializeField] private Vector3 rotationHuman;
    [SerializeField] private Vector3 offsetBird;
    [SerializeField] private Vector3 rotationBird;
    [SerializeField] private Vector3 offsetMouse;
    [SerializeField] private Vector3 rotationMouse;
    [SerializeField] private float speed;

    private Vector3 refVelocity;
    private Vector3 refVelocity2;

    private void LateUpdate()
    {
        Move();
    }

    /// <summary>
    /// Move the Camera to the Player
    /// </summary>
    private void Move()
    {
        Vector3 targetPosition = Vector3.zero;
        Quaternion targetRotation = Quaternion.identity;

        if (playerForm.Value == Forms.Human)
        {
            targetPosition = new Vector3(playerPos.Value.x + offsetHuman.x, playerPos.Value.y + offsetHuman.y, playerPos.Value.z + offsetHuman.z);
            targetRotation = Quaternion.Euler(rotationHuman);
        }
        else if (playerForm.Value == Forms.Bird)
        {
            targetPosition = new Vector3(playerPos.Value.x + offsetBird.x, playerPos.Value.y + offsetBird.y, playerPos.Value.z + offsetBird.z);
            targetRotation = Quaternion.Euler(rotationBird);
        }

        else if (playerForm.Value == Forms.Mouse)
        {
            targetPosition = new Vector3(playerPos.Value.x + offsetMouse.x, playerPos.Value.y + offsetMouse.y, playerPos.Value.z + offsetMouse.z);
            targetRotation = Quaternion.Euler(rotationMouse);
        }

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref refVelocity, speed);
        transform.rotation = targetRotation;
    }
}
