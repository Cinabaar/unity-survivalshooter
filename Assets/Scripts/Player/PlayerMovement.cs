using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float Speed = 6f;

    private Vector3 _movement;
    private Animator _animator;
    private Rigidbody _rigidBody;
    private int _floorMask;
    private float _camRayLength = 100f;

    void Awake()
    {
        _floorMask = LayerMask.GetMask("Floor");
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turn();
        Animate(h, v);
    }

    void Move(float h, float v)
    {
        _movement.Set(h, 0, v);
        _movement = _movement.normalized * Speed * Time.fixedDeltaTime;
        _rigidBody.MovePosition(transform.position + _movement);
    }

    void Turn()
    {
        var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, _camRayLength, _floorMask))
        {
            var playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0;

            var newRotation = Quaternion.LookRotation(playerToMouse);
            _rigidBody.MoveRotation(newRotation);
        }
    }

    void Animate(float h, float v)
    {
        var walking = h!=0.0f || v!=0.0f;
        _animator.SetBool("IsWalking", walking);
    }

}