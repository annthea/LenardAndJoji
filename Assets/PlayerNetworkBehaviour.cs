using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkBehaviour : NetworkBehaviour {

    bool hasCollided = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        else
        {
            keyboardBehaviour();
        }
    }

    public bool GetHasCollided()
    {
        return hasCollided;
    }


    void keyboardBehaviour()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * 10 * Time.deltaTime;
        gameObject.transform.position += (Vector3)move;

        Vector3 v = gameObject.transform.position;
        Vector2 playerPos = v;
        Collider2D hitCollider = Physics2D.OverlapPoint(playerPos);

        if (hitCollider)
        {
            if (hitCollider.gameObject.transform.tag.Equals("Enemy"))
                if (Input.GetKeyDown("up"))
                {
                    Debug.Log("hit");
                    Destroy(hitCollider.gameObject);
                }
        }
    }
}
