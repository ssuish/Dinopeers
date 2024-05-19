using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform player;

    private Vector3 tempPos;
    [SerializeField]
    private float minX = -1.3f, maxX = 1.3f;
    [SerializeField]
    private float minY = -1.8f, maxY = 1.7f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!player)
            return;

        tempPos = transform.position;
        tempPos.x = player.position.x;
        tempPos.y = player.position.y;

        if (tempPos.x < minX)
            tempPos.x = minX;

        if (tempPos.x > maxX)
            tempPos.x = maxX;

        if (tempPos.y < minY)
            tempPos.y = minY;

        if (tempPos.y > maxY)
            tempPos.y = maxY;

        transform.position = tempPos;
    }
}
