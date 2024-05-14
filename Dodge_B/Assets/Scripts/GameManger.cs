using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public GameObject gameoverText;         // 게임오버 시 활성화할
    public Text timeText;                        //게임
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
        // 게임 오버가 아닌 동안
        if (!isGameover)
        {
            // 생존 시간 갱신
            surviveTime += Time.deltaTime;
            // 갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
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
        // 현재 상태를 게임오버 상태로 전환
        isGameover = true;
        // 게임 오버 텍스트 게임 오브젝트를 활성화
        gameoverText.SetActive(true);

        //BestTime 키로 저장된 이전까지의 최고 기록 가져오기
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
