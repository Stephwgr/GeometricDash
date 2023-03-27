using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private Rigidbody2D _rb;
    private BoxCollider2D _coll;

    [Header("Script")]
    private PlayerParticle _playerParticle;

    [Header("Rotation Cube")]
    public float _duration;
    public float _angle;

    [Header("Ground Check")]
    public float _hitDistance;
    public Vector3 _hitPoint;
    [SerializeField] LayerMask _groundMask;

    [Header("Particles System")]
    public GameObject _sparkGroundPrefab;
    public bool hasLanded = false;



    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, Vector2.down * _hitDistance, Color.red);

        Jump();

        if (IsGrounded() && !hasLanded)
        {
            GameObject landingPS = Instantiate(_sparkGroundPrefab, _hitPoint, Quaternion.identity);
            Destroy(landingPS, 2f);

            hasLanded = true;
        }

        if(!IsGrounded())
        {
            hasLanded = false;
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

            //DoTween Rotation
            transform.DORotate(new Vector3(0f, 0f, transform.rotation.eulerAngles.z - _angle), _duration);

        }
    }


    public bool IsGrounded()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, Vector2.down, _hitDistance, _groundMask);
        _hitPoint = hit.point;

        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
