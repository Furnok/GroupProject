using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CaracterController : MonoBehaviour
{
    [SerializeField] private RSO_PlayerPos playerPos;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private float speed;
    [SerializeField] private Forms form;
    [SerializeField] private float changeFormCooldown;

    private bool isDead;
    private bool isMoving;
    private bool canChangeForm;

    private Coroutine courotineMove;

    private enum Forms
    {
        Human,
        Bird,
        Mouse,
    }

    private void Start()
    {
        playerPos.Value = transform.position;
        canChangeForm = true;
    }

    private void FixedUpdate()
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
            Vector3 movement = new Vector3(touchPress.x, 0f, touchPress.y).normalized * speed;
            rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);

            yield return null;
        }

        rb.linearVelocity = Vector3.zero;
    }

    /// <summary>
    /// Arrow Key Call by the Player Input on this gameObject
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

            if (courotineMove != null)
            {
                StopCoroutine(courotineMove);
                rb.linearVelocity = Vector3.zero;
            }
        }
    }

    private IEnumerator ChangeFormReload()
    {
        canChangeForm = false;

        yield return new WaitForSeconds(changeFormCooldown);

        canChangeForm = true;
    }

    /// <summary>
    /// Form Human Call by the Player Input on this gameObject
    /// </summary>
    /// <param name="ctx"></param>
    public void FormHuman(InputAction.CallbackContext ctx)
    {
        if (ctx.started && form != Forms.Human && canChangeForm)
        {
            form = Forms.Human;
            transform.localScale = Vector3.one;
            transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);

            StartCoroutine(ChangeFormReload());
        }
    }

    /// <summary>
    /// Form Bird Call by the Player Input on this gameObject
    /// </summary>
    /// <param name="ctx"></param>
    public void FormBird(InputAction.CallbackContext ctx)
    {
        if (ctx.started && form != Forms.Bird && canChangeForm)
        {
            form = Forms.Bird;
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            transform.position = new Vector3(transform.position.x, 5f, transform.position.z);

            StartCoroutine(ChangeFormReload());
        }
    }

    /// <summary>
    /// Form Mouse Call by the Player Input on this gameObject
    /// </summary>
    /// <param name="ctx"></param>
    public void FormMouse(InputAction.CallbackContext ctx)
    {
        if (ctx.started && form != Forms.Mouse && canChangeForm)
        {
            form = Forms.Mouse;
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            transform.position = new Vector3(transform.position.x, 0.7f, transform.position.z);

            StartCoroutine(ChangeFormReload());
        }
    }

    /// <summary>
    /// Human Attack Call by the Player Input on this gameObject
    /// </summary>
    /// <param name="ctx"></param>
    public void Attack(InputAction.CallbackContext ctx)
    {
        if (ctx.started && form == Forms.Human)
        {
            Debug.Log("Attack");
        }
    }

    /// <summary>
    /// Bird Jump Call by the Player Input on this gameObject
    /// </summary>
    /// <param name="ctx"></param>
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.started && form == Forms.Bird)
        {
            Debug.Log("Jump");
        }
    }
}
