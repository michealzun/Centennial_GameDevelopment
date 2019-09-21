using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyVer2 : MonoBehaviour
{
    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    Vector3 playerPos;
    Animator anime;
    [HideInInspector]
    public Vector3 directionToPlayer;
    [HideInInspector]
    public Vector3 directionToGoal;
    public int ammoCount;
    public GameObject[] patrolNodes;
    [HideInInspector]
    public int goalNode;
    [HideInInspector]
    public bool forward;
    [HideInInspector]
    public float shotCD;
    Vector3 visionAngle;
    public GameObject head;
    bool turnleft = true;
    int headAngle=0;
    NavMeshAgent navMeshAgent;
    

    // Use this for initialization
    public void Start()
    {
        shotCD = 0;
        player = GameObject.Find("ThirdPersonController");
        anime = this.GetComponent<Animator>();
        ammoCount = 6;
        goalNode = 0;
        navMeshAgent= GetComponent<NavMeshAgent>();
        if (navMeshAgent.agentTypeID == 0) navMeshAgent.SetAreaCost(3, 1000);
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        //for firing, there's a weird problem with model you gave us.every time the bullet shoot at the players feet. so i'm manuelly adjusting the player postion
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y + 0.7f, player.transform.position.z);
        directionToPlayer = playerPos - this.gameObject.transform.position;
        //vision
        anime.SetFloat("distanceToGoalNode", Vector3.Distance(patrolNodes[goalNode].transform.position, this.gameObject.transform.position));
        Ray ray = new Ray(this.gameObject.transform.position, directionToPlayer);
        RaycastHit hit = new RaycastHit();
        float visionAngle = Vector3.Angle(directionToPlayer,transform.forward);
        if (visionAngle<30 && Physics.Raycast(ray, out hit, 20)&&hit.collider.gameObject == player)
        { anime.SetBool("TargetPlayer", true); }
        else
        { anime.SetBool("TargetPlayer", false); }
        //for debugging
        directionToGoal = patrolNodes[goalNode].transform.position - this.gameObject.transform.position;
        Debug.DrawRay(this.gameObject.transform.position, directionToGoal, Color.red);
        Debug.DrawRay(this.gameObject.transform.position, directionToPlayer, Color.green);
        //distance
        anime.SetFloat("DistanceToPlayer", Vector3.Distance(this.gameObject.transform.position, playerPos));
        //ammo
        anime.SetInteger("Ammo", ammoCount);
        shotCD += Time.deltaTime;

        head.transform.rotation = Quaternion.Euler(0, headAngle, 0);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Indentity>()){ 
            if (other.GetComponent<Indentity>().identity==Indentity.IdentityTypes.Door)
            {
                if (turnleft)
                {
                headAngle--;
                }
                else
                {
                headAngle++;
                }
                if (headAngle > 30) turnleft = true;
                if (headAngle < -30) turnleft = false;
            }
        }
    }
}
