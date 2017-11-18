using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    int movement;

    PlayerBehaviour player;

    // Use this for initialization
    void Start () {
        movement = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += (GameObject.FindGameObjectWithTag("Player").transform.position - gameObject.transform.position).normalized * Time.deltaTime * movement;
    }

    public void Hit()
    {
        Destroy(this.gameObject);
    }
}
