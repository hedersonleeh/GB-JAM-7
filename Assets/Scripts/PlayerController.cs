using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Character player;
    [SerializeField] private float moveSpeed;
    [SerializeField, Range(0, 0.35f)] private float smoothDamp;
    private Vector2 velocity = Vector2.zero;
    Rigidbody2D rb;
   
    private bool facingRight = false;

    public bool Buttom_A { get; private set; }

    public bool Buttom_B { get; private set; }

    public int Horizontal { get; private set; }

    public int Vertical { get; private set; }

    public bool Buttom_Start { get; private set; }
    public bool Buttom_Select { get; private set; }

    public Rigidbody2D Rb
    {
        get
        {
            return rb;
        }

        set
        {
            rb = value;
        }
    }

    void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player != null && player.isAlive && !player.Interacting)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        Vector2 targetVelocity = new Vector2(Horizontal * moveSpeed * Time.deltaTime, Rb.velocity.y);
        Rb.velocity = Vector2.SmoothDamp(Rb.velocity, targetVelocity, ref velocity, smoothDamp);

        if (Horizontal < 0 && facingRight)
            Flip();
        else if (Horizontal > 0 && !facingRight)
            Flip();
    }

    void Update()
    {
        Inputs();
    }
    void Inputs()
    {
        Horizontal = (int)Input.GetAxisRaw("Horizontal");
        Vertical = (int)Input.GetAxisRaw("Vertical");
        Buttom_A = Input.GetButtonDown("Jump");
        Buttom_B = Input.GetButtonDown("Fire1");
        Buttom_Start = Input.GetButtonDown("Submit");
        Buttom_Select = Input.GetButtonDown("Select");
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.localRotation = facingRight ? Quaternion.Euler(Vector2.up * 180) : Quaternion.Euler(Vector2.zero);
    }
}
