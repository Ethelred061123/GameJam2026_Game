using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_move : MonoBehaviour
{
    //怪物追踪逻辑脚本
    public float speed = 2f;
    public float chaseDistance = 5f;
    public Transform pointA;
    public Transform pointB;
    public float viewDistance = 4f;   
    public float loseDistance = 7f;   

    private bool isChasing = false;
    public bool canChase = true;
    private NewBehaviourScript playerInvis;



    private Transform currentTarget;
    private Transform player;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
        {
            player = p.transform;
            playerInvis = p.GetComponent<NewBehaviourScript>();
        }
        else
        {
            Debug.LogError("没找到 Tag=Player 的物体");
        }

        if (pointA != null && pointB != null)
            currentTarget = pointA;
        else
            Debug.LogError("PointA / PointB 没有设置");
    }

    void Update()
    {
        if (playerInvis != null && playerInvis.isInvisible)
        {
            isChasing = false;
            return; 
        }

        if (!canChase)
        {
            isChasing = false;
        }


        if (player == null || currentTarget == null) return;

        float distanceToPlayer =
            Vector2.Distance(transform.position, player.position);


        if (canChase && !isChasing && distanceToPlayer <= viewDistance)
        {
            isChasing = true;
        }



        if (isChasing)
        {
            Move2D(player.position);

           
            if (distanceToPlayer >= loseDistance)
            {
                isChasing = false;
                currentTarget = pointA; 
            }
        }
        else
        {
            
            Move2D(currentTarget.position);

            if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
            {
                currentTarget = currentTarget == pointA ? pointB : pointA;
            }
        }
    }

    void Move2D(Vector2 targetPos)
    {
        Vector2 dir =
            (targetPos - (Vector2)transform.position).normalized;

        transform.position +=
            (Vector3)(dir * speed * Time.deltaTime);

       
        if (dir.x != 0)
        {
            transform.localScale = new Vector3(
                dir.x > 0 ? 1 : -1,
                1,
                1
            );
        }
    }
    public void DisableChase(float time)
    {
        StartCoroutine(DisableChaseRoutine(time));
    }

    IEnumerator DisableChaseRoutine(float time)
    {
        canChase = false;
        isChasing = false;

        yield return new WaitForSeconds(time);

        canChase = true;
    }
}
