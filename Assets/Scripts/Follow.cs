using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;    //���� ��ǥ
    public Vector3 offset;  //��ġ ������

    void Update()
    {
        transform.position = target.position + offset;  //ī�޶� ��ġ = ���� ��ġ + ��ǥ ��ġ
    }
}