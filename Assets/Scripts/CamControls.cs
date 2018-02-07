using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControls : MonoBehaviour
{
    public GameObject player;
    Vector2 lastPos;
    Vector2 currentPos;

	void Update ()
    {
        currentPos = player.transform.position;

        if (currentPos.y < lastPos.y)
        {
            return;
        }
        else
        {
            Vector3 pos = new Vector3(0f, player.transform.position.y, -10f);
            transform.position = pos;
        }

        lastPos = currentPos;
    }
}
