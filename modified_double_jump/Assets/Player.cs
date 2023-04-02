using UnityEngine;

public class Player : MonoBehaviour
{
    public bool grounded = true;
    private Rigidbody2D rb2d;
    public float jumpPower;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask platformsLayerMask;

    public float speed = 10f;
    private int jumpCount;
    //public int jumpCountMax;

    void Start()
    {
        rb2d = rb2d = GetComponent<Rigidbody2D> ();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        //jumpCountMax = 2;
    }

    void Update()
    {
        Vector3 pos = transform.position;

        // "d" can be replaced with any key
        // this section moves the character right
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }

        // "a" can be replaced with any key
        // this section moves the character left
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }

        if (IsGrounded()) {
            jumpCount = 1;
        }

        if(Input.GetKey(KeyCode.Space)) {
            if (IsGrounded()) {
                rb2d.velocity = Vector2.up * jumpPower;

            } else {
                if(Input.GetKeyDown(KeyCode.Space)) {
                    rb2d.velocity = Vector2.up * jumpPower;
                    jumpCount++;
                }
            }
        }

        transform.position = pos;
    }

    private bool IsGrounded() {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, platformsLayerMask);
        return raycastHit2D.collider != null;
    }
}
