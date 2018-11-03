using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMoving : MonoBehaviour {
    public GameObject player;
    public float movingSpeed = 1.0f;
    Transform target;
    public bool isRange = false;
    public bool isHit = false;
    bool isDead = false;
    Animator animator;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        target = player.gameObject.transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRange && !isDead)
        {
            Vector3 vec = target.position - transform.position;
            vec.Normalize();
            Quaternion q = Quaternion.LookRotation(vec);
            transform.rotation = q;
            transform.position = Vector3.MoveTowards(transform.position, player.gameObject.transform.position, movingSpeed * Time.deltaTime);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isRange = true;
            animator.SetBool("InRange", isRange);
        }
        if(other.tag == "Bullet" && !isHit)
        {
            isHit = true;
            animator.SetBool("IsHit", isHit);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isRange = false;
            animator.SetBool("InRange", isRange);
        }
    }

    public void Damage()
    {
        isDead = true;

        animator.SetBool("IsDead", isDead);
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            Destroy(gameObject);
    }
}
