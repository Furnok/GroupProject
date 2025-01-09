using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static RSO_PlayerForm;

public class CaracterController : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSO_PlayerForm playerForm;
    [SerializeField] private RSO_PlayerPos playerPos;
    [SerializeField] private RSO_RespawnPoint respawnPoint;
    [SerializeField] private RSE_PlayerRespawn playerRespawn;

    [Header("References")]
    [SerializeField] private Rigidbody rb;

    [Header("Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float speedFly;
    [SerializeField] private float changeFormCooldown;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float jumpForce;

    private bool isDead;
    private bool isMoving;
    private bool canJump;
    private bool canChangeForm;

    private Coroutine courotineMove;
    private Coroutine courotineAutoMove;

    private void OnEnable()
    {
        playerRespawn.Fire += Respawn;
    }

    private void OnDisable()
    {
        playerRespawn.Fire -= Respawn;
    }

    private void Start()
    {
        playerPos.Value = transform.position;
        canChangeForm = true;
        canJump = true;
    }

    private void FixedUpdate()
    {
        playerPos.Value = transform.position;
    }

    /// <summary>
    /// Respawn the Player
    /// </summary>
    private void Respawn()
    {
        transform.position = respawnPoint.Value;
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
        if(playerForm.Value == Forms.Human)
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
        rb.linearVelocity = Vector3.zero;

        playerForm.Value = newForm;
        transform.localScale = newScale;
        transform.position = newPosition;

        StartCoroutine(ChangeFormReload());
    }

    /// <summary>
    /// Form Human Call by the Player Input on this gameObject
    /// </summary>
    /// <param name="ctx"></param>
    public void FormHuman(InputAction.CallbackContext ctx)
    {
        if (ctx.started && playerForm.Value != Forms.Human && canChangeForm)
        {
            if(courotineAutoMove != null)
            {
                StopCoroutine(courotineAutoMove);
            }

            ChangeForm(Forms.Human, new Vector3(1f, 1f, 1f), new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z));
        }
    }

    /// <summary>
    /// Form Bird Call by the Player Input on this gameObject
    /// </summary>
    /// <param name="ctx"></param>
    public void FormBird(InputAction.CallbackContext ctx)
    {
        if (ctx.started && playerForm.Value != Forms.Bird && canChangeForm)
        {
            ChangeForm(Forms.Bird, new Vector3(0.5f, 0.5f, 0.5f), new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z));

            courotineAutoMove = StartCoroutine(AutoMove());
        }
    }

    /// <summary>
    /// Form Mouse Call by the Player Input on this gameObject
    /// </summary>
    /// <param name="ctx"></param>
    public void FormMouse(InputAction.CallbackContext ctx)
    {
        if (ctx.started && playerForm.Value != Forms.Mouse && canChangeForm)
        {
            if (courotineAutoMove != null)
            {
                StopCoroutine(courotineAutoMove);
            }

            ChangeForm(Forms.Mouse, new Vector3(0.2f, 0.2f, 0.2f), new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z));
        }
    }

    /// <summary>
    /// Human Attack Call by the Player Input on this gameObject
    /// </summary>
    /// <param name="ctx"></param>
    public void Attack(InputAction.CallbackContext ctx)
    {
        if (ctx.started && playerForm.Value == Forms.Human)
        {
            Debug.Log("Attack");
        }
    }

    /// <summary>
    /// The Reload Time Before Change
    /// </summary>
    /// <returns></returns>
    private IEnumerator JumpReload()
    {
        canJump = false;

        yield return new WaitForSeconds(jumpCooldown);

        canJump = true;
    }

    /// <summary>
    /// Bird Jump Call by the Player Input on this gameObject
    /// </summary>
    /// <param name="ctx"></param>
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.started && playerForm.Value == Forms.Bird && canJump)
        {
            Vector3 velocity = rb.linearVelocity;
            velocity.y = 0f;
            rb.linearVelocity = velocity;

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            StartCoroutine(JumpReload());
        }
    }

    /// <summary>
    /// Auto move forward when the form is Bird
    /// </summary>
    private IEnumerator AutoMove()
    {
        rb.linearVelocity = Vector3.zero;

        yield return null;

        while (playerForm.Value == Forms.Bird)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, speedFly);

            yield return null;
        }   
    }
}
