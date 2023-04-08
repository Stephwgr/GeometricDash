using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private float _jumpForce;
    private Rigidbody2D _rb;
    private BoxCollider2D _coll;

    [Header("Dash")]
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;
    private bool canDash = true;
    private bool isDashing;
    public TrailRenderer _trail;

    [Header("Rotation Cube")]
    public float _duration;
    public float _angle;

    [Header("Ground Check")]
    public float _hitDistance;
    public Vector3 _hitPoint;
    [SerializeField] LayerMask _groundMask;

    [Header("Particles System")]
    public GameObject _sparkGroundPrefab;
    public ParticleSystem _dashPS;
    public bool hasLanded = false;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _coll = GetComponent<BoxCollider2D>();
        _trail = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        Jump();
        Dashing();
        Landing();


        if (isDashing)
        {
            return;
        }

        //Draw Gizmo
        Debug.DrawRay(transform.position, Vector2.down * _hitDistance, Color.red);
    }

    public void Landing()
    {
        if (IsGrounded() && !hasLanded)
        {
            GameObject landingPS = Instantiate(_sparkGroundPrefab, _hitPoint, Quaternion.identity);
            Destroy(landingPS, 2f);

            hasLanded = true;
        }

        if (!IsGrounded())
        {
            hasLanded = false;
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
            return;
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

    public void Dashing()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
            

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

    private IEnumerator Dash()
    {

        canDash = false;
        isDashing = true;
        float originalGravity = _rb.gravityScale;
        _rb.gravityScale = 0f;
        _rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);  
        _trail.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        _trail.emitting = false;
        _rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }


}
