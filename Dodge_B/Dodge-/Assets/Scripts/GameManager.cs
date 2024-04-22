using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // UI ���� ���̺����
using UnityEngine.SceneManagement;  //�� ���� ���� ���̺귯��

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;//���� ������ Ȱ��ȭ �ؽ�Ʈ ������Ʈ
    public Text timeText;    //���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recordText;  //�ְ� ����� ǥ���� �ؽ�Ʈ ������Ʈ

    private float survivTime;   // ���� �ð�
    private bool isGameover;    //���ӿ��� ����

    // Start is called before the first frame update
    void Start()
    {
        survivTime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            survivTime += Time.deltaTime;
            //������ ���� �ð��� timeTaxt �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
            timeText.text = "Time : " + (int)survivTime;
        }
        else
        {
            //���ӿ��� ���¿��� R Ű�� ���� ���
            if (Input.GetKeyDown(KeyCode.R))
            {
                //SampleScene ���� �ε�
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    //���� ������ ���ӿ��� ���·� �����ϴ� �ż���
    public void EndGame()
    {
        //���� ���¸� ���ӿ��� ���·� ��ȯ
        isGameover = true;
        //���� ���� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);

    }
}
