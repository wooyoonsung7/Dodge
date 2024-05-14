using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public GameObject gameoverText;         // ���ӿ��� �� Ȱ��ȭ��
    public Text timeText;                        //����
    public Text recordText;

    private float surviveTime;
    private bool isGameover;

    public AudioSource audioGameOver;

    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        isGameover = false;

        audioGameOver = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ������ �ƴ� ����
        if (!isGameover)
        {
            // ���� �ð� ����
            surviveTime += Time.deltaTime;
            // ������ ���� �ð��� timeText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
            timeText.text = "Time : " + (int) surviveTime;
        }
        else
        {
            gameoverText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("gameScenes");  
            }
        }
    }

    public void EndGame()
    {
        // ���� ���¸� ���ӿ��� ���·� ��ȯ
        isGameover = true;
        // ���� ���� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);

        //BestTime Ű�� ����� ���������� �ְ� ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");
        
        if (surviveTime > bestTime)
        {
            bestTime = surviveTime;

            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time : " + (int) bestTime;

        audioGameOver.Play();
    }

}
