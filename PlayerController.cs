using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private float timeBtwAttack;
    [SerializeField] private GameObject hitbox;

    private float attackTime = .25f;
    private float attackCounter = .25f;
    private bool isAttacking;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveVelocity.x = Input.GetAxis("Horizontal");
        moveVelocity.y = Input.GetAxis("Vertical");

        if (isAttacking)
        {
            rb.velocity = Vector2.zero;
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                isAttacking = false;
            }
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            attackCounter = attackTime;
            isAttacking = true;
            hitbox.SetActive(true);
        }
        if (Input.GetMouseButtonUp(0))
            hitbox.SetActive(false);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * speed * Time.fixedDeltaTime);
    }
}
