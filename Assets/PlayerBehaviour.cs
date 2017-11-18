using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    bool hasCollided = false;
    Animator animator;

    bool _isPlaying_idle = false;
    bool _isPlaying_plainpunch = false;

    const int STATE_IDLE = 0;
    const int STATE_PLAINPUNCH = 1;

    int _currentAnimationState = STATE_IDLE;

    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        keyboardBehaviour();
    }

    public bool GetHasCollided()
    {
        return hasCollided;
    }


    void keyboardBehaviour()
    {
        Vector3 v = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 playerPos = v;
        Collider2D hitCollider = Physics2D.OverlapPoint(playerPos);
        if (Input.GetKey("up"))
        {
            changeState(STATE_PLAINPUNCH);

            if (hitCollider)
            {
                if (hitCollider.gameObject.transform.tag.Equals("Enemy"))
                {
                    Debug.Log("hit");
                    Destroy(hitCollider.gameObject);
                }
            }
        }
        else if (Input.GetKeyUp("up"))
        {
            Debug.Log("key released");
            changeState(STATE_IDLE);
        }

        //check if crouch animation is playing
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("CyberPunk_idle"))
            _isPlaying_idle = true;
        else
            _isPlaying_idle = false;

        //check if hadooken animation is playing
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("CyberPunk_plainpunch"))
            _isPlaying_plainpunch = true;
        else
            _isPlaying_plainpunch = false;
    }

    void changeState(int state)
    {

        if (_currentAnimationState == state)
            return;

        switch (state)
        {

            case STATE_IDLE:
                animator.SetInteger("state", STATE_IDLE);
                break;

            case STATE_PLAINPUNCH:
                animator.SetInteger("state", STATE_PLAINPUNCH);
                break;
        }

        _currentAnimationState = state;
    }

}

