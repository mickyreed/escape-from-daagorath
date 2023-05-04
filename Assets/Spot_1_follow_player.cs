using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot_1_follow_player : MonoBehaviour
{
    public Transform player_spot;

    // Update is called once per frame
    void Update()
    {
        transform.position = player_spot.transform.position + new Vector3(0, 1, -1);
    }
}
