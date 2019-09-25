using UnityEngine;

public class ChecksBuildings : MonoBehaviour
{
    private Vector2 maxPos;
    private Vector2 minPos;

    public static bool CanBuild { get; private set; }

    private void Start()
    {
        maxPos = new Vector2(-10.45f, 0.18f);
        minPos = new Vector2(-3.371f, 0.18f);
    }
    private void LateUpdate()
    {
        CheckPosForBuild();
    }
    private void FixedUpdate()
    {
        CheckIfCollidingWithOtherBuilding();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0);
    }


    private void CheckIfCollidingWithOtherBuilding()
    {
        var hits = Physics2D.OverlapCircleAll(transform.position, 0);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].GetComponent<Buildings>() != null)
            {
                CanBuild = false;
            }
        }
    }

    private void CheckPosForBuild()
    {
        if (transform.position.x < maxPos.x)
        {
            CanBuild = false;
        }
        else if (transform.position.x > minPos.x)
        {
            CanBuild = false;
        }
        else
        {
            CanBuild = true;
        }
    }
}

