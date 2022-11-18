using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public void Update()
    {
        Vector3 pos=new Vector3(player.transform.position.x +4f,player.transform.position.y + 3.5f ,-10);
        gameObject.transform.position=pos;
    }

}
