using UnityEngine;
using UnityEngine.AI;

public class x_NavPlayer : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agent;
    public float turnSmoothing = 15f;
    public GameObject navMarker;	//A reference to the prefab that is our "Nav Marker"

    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = true;
        agent.updatePosition = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();
    }



    public void SetTargetPosition(Vector3 _v3TargetPosition)
    {
        try
        {
            if (!agent.enabled)
                agent.enabled = true;

            if (agent.enabled == true)
            {
                agent.SetDestination(_v3TargetPosition);
            }

            if (navMarker != null)
            {
                navMarker.transform.position = _v3TargetPosition;
                navMarker.SetActive(true);
            }
        }
        finally
        {

        }        
    }

    void UpdateAnimation()
    {
        if (!agent.enabled)
            return;

        //Record the desired speed of the navmesh agent
        float speed = agent.desiredVelocity.magnitude;

        //Tell the animator how fast the navmesh agent is going
        anim.SetFloat("Speed", speed);

        //If the player if moving...
        if (speed > 0f)
        {
            //...calculate the angle the player should be facing...
            Quaternion targetRotation = Quaternion.LookRotation(agent.desiredVelocity);
            //...and rotate over time to face that direction
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSmoothing * Time.deltaTime);
        }

        try
        {
            //If we are within our "Stopping Distance" of the destination...
            if (agent.remainingDistance <= agent.stoppingDistance && navMarker != null)
            {
                //...disable (hide) the nav marker
                if (agent.hasPath)
                    navMarker.SetActive(false);
                //agent.Stop();
            }
        }
        catch (System.Exception e)
        {

        }

    }
}
