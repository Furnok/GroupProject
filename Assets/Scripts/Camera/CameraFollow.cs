using UnityEngine;
using static RSO_PlayerForm;

public class CameraFollow : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSO_PlayerForm playerForm;
    [SerializeField] private RSO_PlayerPos playerPos;

    [Header("Parameters")]
    [SerializeField] private Vector3 offsetTopDown;
    [SerializeField] private Vector3 rotationTopDown;
    [SerializeField] private Vector3 offsetThirdPerson;
    [SerializeField] private Vector3 rotationThirdPerson;
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
        Vector3 targetPosition = Vector3.zero;
        Quaternion targetRotation = Quaternion.identity;

        if (playerForm.Value == Forms.Human || playerForm.Value == Forms.Mouse)
        {
            targetPosition = new Vector3(playerPos.Value.x + offsetTopDown.x, playerPos.Value.y + offsetTopDown.y, playerPos.Value.z + offsetTopDown.z);
            targetRotation = Quaternion.Euler(rotationTopDown);
        }
        else if (playerForm.Value == Forms.Bird)
        {
            targetPosition = new Vector3(playerPos.Value.x + offsetThirdPerson.x, playerPos.Value.y + offsetThirdPerson.y, playerPos.Value.z + offsetThirdPerson.z);
            targetRotation = Quaternion.Euler(rotationThirdPerson);
        }

        transform.position = targetPosition;
        transform.rotation = targetRotation;
    }
}
