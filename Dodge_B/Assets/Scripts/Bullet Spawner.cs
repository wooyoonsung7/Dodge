using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefad;  //������ ź���� ���� ������
    public float spawnRateMin = 0.5f; //�ּ� ���� �ֱ�
    public float spawnRateMax = 3f;   //�ִ� ���� �ֱ�

    private Transform target;  //�߻��� ���
    private float spawnRate;  //���� �ֱ�
    private float TimAfterSpawn;  //�ֱ� ���� �������� ���� �ð�

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

            //��ź ������ ��ź �߻��� ����
            audioPlayer.Play();
        }
    }
}
