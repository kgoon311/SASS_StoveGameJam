using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent : MonoBehaviour
{
    //카메라가 쫒아갈 대상
    [SerializeField] private Transform targetTrf;
    //카메라와 타겟 사이의 거리
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position.x - targetTrf.position.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FallowTarget();
    }

    //대상 추적 이동
    private void FallowTarget()
    {
        transform.position = new Vector3(targetTrf.position.x + offset, transform.position.y, transform.position.z);
    }
}
