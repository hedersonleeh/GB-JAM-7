using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Character player;
    [SerializeField] private float moveSpeed;
    [SerializeField, Range(0, 0.35f)] private float smoothDamp;
    private Vector2 velocity = Vector2.zero;
    Rigidbody2D rb;
    private int vertical;
    private int horizontal;
    private bool buttom_A;
    private bool buttom_B;
    private bool buttom_Start;
    private bool facingRight = false;

    public bool Buttom_A { get { return buttom_A; } }

    public bool Buttom_B { get { return buttom_B; } }

    public int Horizontal { get { return horizontal; } }

    public int Vertical { get { return vertical; } }

    public bool Buttom_Start { get { return buttom_Start; } }



    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        if (player.isAlive)
        {
            if (!player.Interacting)
            {
                Vector2 targetVelocity;
                targetVelocity = new Vector2(horizontal * moveSpeed * Time.deltaTime, rb.velocity.y);
                rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, smoothDamp);
                if (horizontal < 0 && facingRight) Flip();
                else if (horizontal > 0 && !facingRight) Flip();
            }
        }

    }

    void Update()
    {
        Inputs();
    }
    void Inputs()
    {
        horizontal = (int)Input.GetAxisRaw("Horizontal");
        vertical = (int)Input.GetAxisRaw("Vertical");
        buttom_A = Input.GetButtonDown("Jump");
        buttom_B = Input.GetButtonDown("Fire1");
        buttom_Start = Input.GetButtonDown("Submit");
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.localRotation = facingRight ? Quaternion.Euler(Vector2.up * 180) : Quaternion.Euler(Vector2.zero);
    }
}
