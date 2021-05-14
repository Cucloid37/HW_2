using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewController : MonoBehaviour
{
    
    [SerializeField] private float speed = 6.0F; //�������� ������������
    [SerializeField] private float jumpSpeed = 8.0F; //��������� �������� ������
    [SerializeField] private float gravity = 20.0F; //���� ����������
    private Vector3 moveDirection = Vector3.zero; //����������� ���������
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>(); //����� ��� CharacterController
        if (controller.isGrounded)
        { //� ��� ���� ����������, ������� ���� �����, ����� �� �� �� �����. � ���� �� �����...
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //����� �������� ������ WASD ��� ��������� � ������� ������, ����������� � ������ �������
            moveDirection = transform.TransformDirection(moveDirection); //��������� ��������� ���������� � ��������������� ����������
            moveDirection *= speed; //moveDirection - ��� ����������� ��������. ������� �� �������� ��� �� ������������ ��������, ����� �������� �������
            if (Input.GetButton("Jump")) //���� �� �������� ������
                moveDirection.y = jumpSpeed; //�� ������� �������� ������

        }
        moveDirection.y -= gravity * Time.deltaTime; //��� �������� ����������
        controller.Move(moveDirection * Time.deltaTime); //� ������� ��� ������ � �����-������ �� �������� ���������� Move � ���� �� ��� ������ �����������. � ��� ���� ����� ������� ������ ��������� ��� ����. ��� ����������� ������ �����, ��� addForce � ������ �����.
    }
}
