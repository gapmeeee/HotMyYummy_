using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI : MonoBehaviour
{
    public float speed;
    NavMeshAgent agent;
    private float waitTime;
    public float startWaitTime;
    public Transform Player;
    public Transform[] moveSpots;
    private int randomSpot;
    public bool is_cold_gun = false;
    public float StartTimeBeetwenShoots = 1f;
    protected float TimeBeetwenShoots;
    public GameObject projectile;
    private GameObject bullet;
    public float distance;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        TimeBeetwenShoots = StartTimeBeetwenShoots;
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (Vector2.Distance(transform.position, Player.position) > 10f)
        {
            agent.SetDestination(moveSpots[randomSpot].position);
            if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Length);
                    waitTime = startWaitTime;

                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
        else if (is_cold_gun == true)
        {
            agent.SetDestination(Player.position);
        }
        else if (is_cold_gun == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Player.position, distance);
            Debug.DrawRay(gameObject.transform.position, Player.position, Color.white,1f);
            Debug.Log(hit.collider.tag);
            if (hit.collider.tag == "Player")
            {
                Debug.Log("NiceNefor");
                if (TimeBeetwenShoots <= 0)
                {
                    bullet = Instantiate(projectile, Player.position, Quaternion.identity); //Здесь нужно добавить оружие врагу и настроить стрельбу

                    TimeBeetwenShoots = StartTimeBeetwenShoots;
                }
                else
                {
                    
                    TimeBeetwenShoots -= Time.deltaTime;
                }
            }
            else
            {
                agent.SetDestination(Player.position);
            }
        }

        


        
        
    }
}
