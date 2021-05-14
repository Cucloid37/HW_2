using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Controller : MonoBehaviour
{
    [SerializeField] private float _speed; // Скорость движения, а в дальнейшем ускорение
    [SerializeField] private float _jumpForce; // Сила прыжка
    [SerializeField] private Vector3 _direction; // Направление движения
    [SerializeField] private float gravity = 20.0F; // Сила гравитации
    [SerializeField] private GameObject _bomb;

    private Rigidbody _rb; 
    private bool _isGrounded;
   
    private void Start()
    {    
        _rb = GetComponent<Rigidbody>();

        print(_isGrounded);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Vector3 VectorBomb = new Vector3();
            VectorBomb = _rb.position;
            Instantiate(_bomb, VectorBomb, Quaternion.identity);
            Debug.Log($"позиция тела: {_rb.position}");
            Debug.Log($"Вектор: {_direction}");
            Debug.Log($"Трансформ объекта: {gameObject.transform}");
        }
    }

    private void FixedUpdate()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        MoveLogic();
        JumpLogic();
        Gravity();


    }

    private void MoveLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        
        

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Translate(movement * _speed * Time.fixedDeltaTime);


    }

    private void JumpLogic()
    {
        var x = Input.GetAxis("Jump");
        Debug.Log(x);
        if (Input.GetAxis("Jump") > 0)
        {
            Debug.Log(x);
            Debug.Log(_isGrounded);
            if (_isGrounded)
            {
                _rb.AddForce(transform.up * _jumpForce);
                
            }
        }
    }

    private void Gravity()
    {
        if(_isGrounded == false)
        {
            while (_isGrounded)
            {
                _rb.AddForce(Vector3.down * gravity);
            }
            Debug.Log("No!");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        Debug.Log("Yes!");
        if (collision.gameObject.GetComponent<Collider>())
        {
            _isGrounded = value;
        }
    }

}
