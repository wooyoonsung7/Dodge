using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;                 //탄알의 속력
    private Rigidbody bulletRigidbody;       //탄알에 사용되는 물리 컴포넌트를 연결할 변수

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;               //transforward.forward = vecto3(0f, 0f, 1f);
        

        Destroy(gameObject, 3.0f);           //3초뒤에자신을 파괴

    }    
        //트리거 충돌 시 자동으로 실행되는 메서드
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                
                PlayerContoller playerContoller = other.GetComponent<PlayerContoller>();

                if (playerContoller != null)
                {
                    playerContoller.Die();
                }
            }
        }
    }