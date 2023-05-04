using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam1_follow_player : MonoBehaviour
{
    public Transform player_cam;

    // Update is called once per frame
    void Update()
    {
        transform.position = player_cam.transform.position + new Vector3(0, 1, -22);
    }
}
