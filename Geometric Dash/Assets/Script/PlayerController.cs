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
    [SerializeField] private Transform _transformIntantiate;
    private float _particleSpawnTimer;
    private ParticleSystem _particleSystem;
    



    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _coll = GetComponent<BoxCollider2D>();

        _particleSpawnTimer = 0;

        
    }

    

    private void Update()
    {
        Debug.DrawRay(transform.position, Vector2.down * _hitDistance, Color.red);

        Jump();
    }

    

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {

            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

            //DoTween Rotation
            transform.DORotate(new Vector3(0f, 0f, transform.rotation.eulerAngles.z - _angle), _duration);
        }

        // if(IsGrounded() && _particleSystem == null)
        // {
        //     _particleSystem = Instantiate(ps_SparkGround, _transformIntantiate.position,Quaternion.Euler(new Vector3(-90,90,0.6f)));
        //     _particleSystem.transform.parent = _transformIntantiate;
        // }

        // if(!IsGrounded() && _particleSystem != null)
        // {
        //     Destroy(_particleSystem.gameObject);
        //     _particleSystem = null;
        // }

    }

    public bool IsGrounded()
    {

        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, Vector2.down, _hitDistance, _groundMask);    



        return hit;
    }
}
