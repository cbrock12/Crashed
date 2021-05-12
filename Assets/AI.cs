using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AI : MonoBehaviour
{
    private Vector3 walkPoint;
    public float walkSpeed;
    public float runSpeed;
    private float pointX;
    private float pointZ;
    private NavMeshAgent agent;
    public bool sighted;
    public GameObject player;
    public float angle;
    public float radius;
    public float height;
    public LayerMask targetLayer;
    public LayerMask obstructionLayer;
    private Animator animate;
    private static readonly string level = "level";
    private float index = 1;

    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetFloat(level, SceneManager.GetActiveScene().buildIndex);
        agent = GetComponent<NavMeshAgent>();
        animate = GetComponent<Animator>();
        RandomPoints();
    }

    void RandomPoints()
    {
        int[] points = new int[3] {-35, 0, 35};
        
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("First Floor"))
        {
            pointX = Random.Range(-30, 30);
            pointZ = Random.Range(0, 30);

        } else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Second Floor")) {
            pointX = points[(int)(Random.Range(0, 3))];

            if (player.transform.position.z < 0) {
                pointZ = points[(int)(Random.Range(0, 2))];
            } else {
                pointZ = points[(int)(Random.Range(1, 3))];
            }

        } else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Third Floor")) {
            if (player.transform.position.x < 0) {
                pointX = points[(int)(Random.Range(0, 2))];
            } else {
                pointX = points[(int)(Random.Range(1, 3))];
            }

            pointZ = points[(int)(Random.Range(0, 3))];

        } else {
            if (player.transform.position.x < 0) {
                pointX = points[(int)(Random.Range(0, 2))];
            } else {
                pointX = points[(int)(Random.Range(1, 3))];
            }

            if (player.transform.position.z < 0) {
                pointZ = points[(int)(Random.Range(0, 2))];
            } else {
                pointZ = points[(int)(Random.Range(1, 3))];
            }
        }
        
        walkPoint = new Vector3(pointX, 0, pointZ);
        agent.speed = walkSpeed;
        StartCoroutine(Delay());
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            RandomPoints();
        }

        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Death");
        }
    }

    void inSight()
    {
        Collider[] check = Physics.OverlapSphere(transform.position, radius, targetLayer);

        if (check.Length != 0)
        {
            Transform target = check[0].transform;
            Vector3 direction = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, direction) < angle / 2)
            {
                float distance = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position + Vector3.up * height, direction, distance, obstructionLayer))
                {
                    sighted = true;
                } else {
                    sighted = false;
                }
            } else {
                sighted = false;
            }
        } else if (sighted) {
            sighted = false;
        }
    }

    public IEnumerator Delay()
    {
        animate.SetInteger("state", 0);
        yield return new WaitForSeconds(3);
        agent.destination = walkPoint;
        animate.SetInteger("state", 1);
    }

    void Update()
    {
        if (agent.remainingDistance == 0)
        {
            RandomPoints();
        }

        inSight();

        if (sighted)
        {
            animate.SetInteger("state", 2);
            walkPoint = player.transform.position;
            agent.destination = walkPoint;
            agent.speed = runSpeed;
        }
    }
}
