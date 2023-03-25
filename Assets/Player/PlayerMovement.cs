using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

/*    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }*/

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }
    
    void LateUpdate() // �������� ����Ǳ� ������ ����Ǵ� �����ֱ� �Լ�
    {
        if (inputVec.x != 0) // inputVec.x�� �����ų� ������ �ʾ��� ��
        {
            spriter.flipX = inputVec.x < 0; // inputVec.x�� 0���� ������ flipx üũ
        }
    }

    void OnMove(InputValue value)
        {
            inputVec = value.Get<Vector2>();
        }

}
