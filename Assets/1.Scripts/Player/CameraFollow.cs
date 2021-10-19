using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    public float smoothing = 5.0f;
    private Vector3 offset;
    private Transform tr;

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    private void Start()
    {
        offset = tr.position - player.transform.position;
    }

    private void Update()
    {
        Vector3 newCamPos = player.transform.position + offset;
        tr.position = Vector3.Lerp(tr.position, newCamPos, smoothing * Time.deltaTime);
    }
}
