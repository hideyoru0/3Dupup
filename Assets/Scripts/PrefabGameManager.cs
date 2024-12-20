using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> mapList;  //시작할 때 생설할 맵 프리팹
    [SerializeField] GameObject goalMap;        //골라인으로 지정할 프리팹으로 z축으로 제일 떨어진곳에 생성
    [SerializeField] GameObject player;         //복제할 플레이어 오브젝트
    [SerializeField] Transform spawnPoint;      //플레이어 오브젝트가 생성될 위치

    // Start is called before the first frame update
    void Start()
    {
        //int randomCount = Random.Range(0, 2);
        //Instantiate(mapList[2]);

        // 맵을 필요한 만큼 생성하고 랜덤한 위치값을 가지게 한다.
        for(int i = 0; i < 100; i++)
        {
            int randomCount = Random.Range(0, 3000) % 3;
            var position = new Vector3(Random.Range(-100.0f, 1.0f), Random.Range(100.0f, 1.0f), Random.Range(100.0f, 1.0f));
            Instantiate(mapList[randomCount], position, Quaternion.identity);
        }

        // 마지막 골라인 맵을 생성하고 y축 150.0f, z축으로 50.0f만큼 떨어진 곳에 생성한다.
        //Instantiate(goalMap, new Vector3(0, 10.0f, 10.0f), Quaternion.identity); // 테스트용 좌표
        Instantiate(goalMap, new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(150.0f, 50.0f), Random.Range(100.0f, 10.0f)), Quaternion.identity);

        //플레이어를 spawnPoint에 생성한다.
        Instantiate(player, spawnPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
