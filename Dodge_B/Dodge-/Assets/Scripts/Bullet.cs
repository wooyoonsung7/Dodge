using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;                 //ź���� �ӷ�
    private Rigidbody bulletRigidbody;       //ź�˿� ���Ǵ� ���� ������Ʈ�� ������ ����

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;               //transforward.forward = vecto3(0f, 0f, 1f);
        

        Destroy(gameObject, 3.0f);           //3�ʵڿ��ڽ��� �ı�

    }    
        //Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼���
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