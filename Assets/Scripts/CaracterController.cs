using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CaracterController : MonoBehaviour
{
    [SerializeField] private RSO_PlayerPos playerPos;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private float speed;

    private bool isDead;
    private bool isMoving;

    private Coroutine courotineMove;

    private void Start()
    {
        playerPos.Value = transform.position;
    }

    /// <summary>
    /// Move the Player
    /// </summary>
    /// <param name="touchPress"></param>
    /// <returns></returns>
    private IEnumerator MovePlayer(Vector2 touchPress)
    {
        while (isMoving && !isDead)
        {
            Vector3 movement = new Vector3(touchPress.x, 0f, touchPress.y) * speed;
            rb.MovePosition(rb.position + movement * Time.deltaTime);
            playerPos.Value = transform.position;

            yield return null;
        }
    }

    /// <summary>
    /// Arrow Key
    /// </summary>
    /// <param name="ctx"></param>
    public void Move(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && !isDead)
        {
            if (courotineMove != null)
            {
                StopCoroutine(courotineMove);
            }

            isMoving = true;

            Vector2 inputDirection = ctx.ReadValue<Vector2>();

            courotineMove = StartCoroutine(MovePlayer(inputDirection));
        }
        else if (ctx.canceled)
        {
            isMoving = false;
        }
    }
}
