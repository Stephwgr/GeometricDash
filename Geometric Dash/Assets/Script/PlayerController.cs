using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private Rigidbody2D _rb;
    private BoxCollider2D _coll;

    [Header("Rotation Cube")]
    public float _duration;
    public float _angle;

    [Header("Ground Check")]
    public float _hitDistance;
    [SerializeField] LayerMask _groundMask;

    [Header("Particles System")]
    public ParticleSystem ps_SparkGround;
    public float particleOffsetX;
    public float particleOffsetY;
    



    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _coll = GetComponent<BoxCollider2D>();

        
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, Vector2.down * _hitDistance, Color.red);

        Jump();
    }

    public void Move()
    {
        transform.position += new Vector3(_speed * Time.deltaTime, 0, 0);

    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {

            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

            //DoTween Rotation
            transform.DORotate(new Vector3(0f, 0f, transform.rotation.eulerAngles.z - _angle), _duration);
        }

        if (IsGrounded())
        {

            ps_SparkGround.Play();

        }
        else
        {
            ps_SparkGround.Stop();


        }
    }

    public bool IsGrounded()
    {

        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, Vector2.down, _hitDistance, _groundMask);    



        return hit;
    }
}
