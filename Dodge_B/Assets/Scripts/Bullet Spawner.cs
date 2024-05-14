using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefad;  //생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f; //최소 생성 주기
    public float spawnRateMax = 3f;   //최대 생성 주기

    private Transform target;  //발사할 대상
    private float spawnRate;  //생성 주기
    private float TimAfterSpawn;  //최근 생성 시점에서 지난 시간

    public AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        TimAfterSpawn = 0;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerContoller>().transform;

        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        TimAfterSpawn += Time.deltaTime;

        if (TimAfterSpawn >= spawnRate)
        {
            TimAfterSpawn = 0f;

            GameObject bullet = Instantiate(bulletPrefad, transform.position, transform.rotation);
            bullet.transform.LookAt(target);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

            //포탄 생성시 포탄 발사음 실행
            audioPlayer.Play();
        }
    }
}
