using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public float forceAmount = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveDir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        moveDir = new Vector2(moveX, moveY);
        

        animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("yVelocity", Mathf.Abs(rb.linearVelocity.y));

        if(moveDir.sqrMagnitude > 0.01f)
        {
           float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
           transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    void FixedUpdate()
    {
        rb.linearVelocity = moveDir * forceAmount;
    }
}


