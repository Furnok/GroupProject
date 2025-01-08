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
    [SerializeField] private float jumpForce;

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
        if(form == Forms.Human || form == Forms.Bird)
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
    }

    /// <summary>
    /// The Reload Time Before Change
    /// </summary>
    /// <returns></returns>
    private IEnumerator ChangeFormReload()
    {
        canChangeForm = false;

        yield return new WaitForSeconds(changeFormCooldown);

        canChangeForm = true;
    }

    /// <summary>
    /// Change the Form of the Player
    /// </summary>
    /// <param name="newForm"></param>
    /// <param name="newScale"></param>
    /// <param name="newPosition"></param>
    private void ChangeForm(Forms newForm, Vector3 newScale, Vector3 newPosition)
    {
        form = newForm;
        transform.localScale = newScale;
        transform.position = transform.position + newPosition;

        StartCoroutine(ChangeFormReload());
    }

    /// <summary>
    /// Form Human Call by the Player Input on this gameObject
    /// </summary>
    /// <param name="ctx"></param>
    public void FormHuman(InputAction.CallbackContext ctx)
    {
        if (ctx.started && form != Forms.Human && canChangeForm)
        {
            ChangeForm(Forms.Human, new Vector3(1f, 1f, 1f), new Vector3(transform.position.x, 1.5f, transform.position.z));
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
            ChangeForm(Forms.Bird, new Vector3(0.5f, 0.5f, 0.5f), new Vector3(transform.position.x, 1.5f, transform.position.z));
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
            ChangeForm(Forms.Mouse, new Vector3(0.2f, 0.2f, 0.2f), new Vector3(transform.position.x, 1.5f, transform.position.z));
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
            Vector3 velocity = rb.linearVelocity;
            velocity.y = 0f;
            rb.linearVelocity = velocity;

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
