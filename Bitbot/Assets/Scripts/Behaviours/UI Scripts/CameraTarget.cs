﻿using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [Header("Constraint")]
    [SerializeField] private float y = 7f;
    [SerializeField] private float x = 3f;

    private Transform player;
    private Camera cam;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    void Update()
    {
        MoveTarget();
    }

    private void MoveTarget()
    {
        this.transform.position = calcTargetPos(x, y);
    }
    private Vector3 calcTargetPos(float x, float y)
    {
        Vector3 mPos = MousePosition.GetMouseWorldPos(6f, cam);
        Vector3 tPos = (player.position + mPos) / 2f;

        tPos.x = Mathf.Clamp(tPos.x, -x + player.position.x, x + player.position.x);
        tPos.y = Mathf.Clamp(tPos.y, -y + player.position.y, y + player.position.y);

        return tPos;
    }
}
