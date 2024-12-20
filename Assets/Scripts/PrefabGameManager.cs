using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> mapList;  //������ �� ������ �� ������
    [SerializeField] GameObject goalMap;        //��������� ������ ���������� z������ ���� ���������� ����
    [SerializeField] GameObject player;         //������ �÷��̾� ������Ʈ
    [SerializeField] Transform spawnPoint;      //�÷��̾� ������Ʈ�� ������ ��ġ

    // Start is called before the first frame update
    void Start()
    {
        //int randomCount = Random.Range(0, 2);
        //Instantiate(mapList[2]);

        // ���� �ʿ��� ��ŭ �����ϰ� ������ ��ġ���� ������ �Ѵ�.
        for(int i = 0; i < 100; i++)
        {
            int randomCount = Random.Range(0, 3000) % 3;
            var position = new Vector3(Random.Range(-100.0f, 1.0f), Random.Range(100.0f, 1.0f), Random.Range(100.0f, 1.0f));
            Instantiate(mapList[randomCount], position, Quaternion.identity);
        }

        // ������ ����� ���� �����ϰ� y�� 150.0f, z������ 50.0f��ŭ ������ ���� �����Ѵ�.
        //Instantiate(goalMap, new Vector3(0, 10.0f, 10.0f), Quaternion.identity); // �׽�Ʈ�� ��ǥ
        Instantiate(goalMap, new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(150.0f, 50.0f), Random.Range(100.0f, 10.0f)), Quaternion.identity);

        //�÷��̾ spawnPoint�� �����Ѵ�.
        Instantiate(player, spawnPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
