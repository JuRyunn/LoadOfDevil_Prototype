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
    
    void LateUpdate() // 프레임이 종료되기 이전에 실행되는 생명주기 함수
    {
        if (inputVec.x != 0) // inputVec.x가 눌리거나 눌리지 않았을 때
        {
            spriter.flipX = inputVec.x < 0; // inputVec.x가 0보다 작으면 flipx 체크
        }
    }

    void OnMove(InputValue value)
        {
            inputVec = value.Get<Vector2>();
        }

}
