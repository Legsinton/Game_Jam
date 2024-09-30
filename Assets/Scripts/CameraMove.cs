using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Vector3 offset = new Vector3(2, 0, -10);

    private void LateUpdate()
    {
        Vector3 target = new Vector3(0, player.position.y, player.position.z) + offset;
        transform.position = target;
    }

}
