using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidDrop : MonoBehaviour
{
    public int ActiveNum;
    public GameObject[] Spliteffect;

    private LineRenderer lineRenderer = null;
    private ParticleSystem splashParticle = null;
    public bool nowsplit;

    private Coroutine pourRoutine = null;
    private Vector3 targetPosition = Vector3.zero;
    private int originalNum;
    public bool isHitting;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        splashParticle = GetComponentInChildren<ParticleSystem>();
    }
    private void Start()
    {
        if (lineRenderer)
        {
            MoveToPosition(0, transform.position);
            MoveToPosition(1, transform.position);
        }
        originalNum = ActiveNum;
        StartCoroutine(SplitSpawn());
    }

    public void Begin()
    {
        if (lineRenderer)
        {
            StartCoroutine(updateParticle());
        }
        pourRoutine = StartCoroutine(BeginPour());

    }
    private IEnumerator BeginPour()
    {

        while (gameObject.activeSelf)
        {
            targetPosition = FindEndPoint();
            if (lineRenderer)
            {
                MoveToPosition(0, transform.position);
                AnimateToPosition(1, targetPosition);
            }
            yield return null;
        }
      
    }
    public void end()
    {
        StopCoroutine(pourRoutine);
        pourRoutine = StartCoroutine(EndPour());
        ActiveNum = originalNum;
    }
    private IEnumerator EndPour()
    {
        while(!HasReachedPosition(0,targetPosition))
        {
            if (lineRenderer)
            {
                AnimateToPosition(0, targetPosition);
                AnimateToPosition(1, targetPosition);
            }
            yield return null;
        }
        Destroy(gameObject);
    }
    private Vector3 FindEndPoint()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        Physics.Raycast(ray,out hit,2.0f);
        Vector3 endPoint = hit.collider ? hit.point : ray.GetPoint(2.0f);
        Debug.Log(hit.transform.tag);
        if (hit.transform.tag == "Source")
        {
            Debug.Log(ActiveNum);
            hit.transform.GetChild(0).GetChild(ActiveNum).gameObject.SetActive(true);
        }
        if(hit.transform.tag=="Split"|| hit.transform.tag == "Board")
        {
            nowsplit = true;
        }
        else
        {
            nowsplit = false;
        }
        return endPoint;
    }
    private void MoveToPosition(int index,Vector3 targetPosition)
    {
        lineRenderer.SetPosition(index,targetPosition);
    }
    private void AnimateToPosition(int index, Vector3 TargetPosition)
    {
        Vector3 currentPoint = lineRenderer.GetPosition(index);
        Vector3 newPosition = Vector3.MoveTowards(currentPoint, targetPosition, Time.deltaTime * 1.75f);
        lineRenderer.SetPosition(index, newPosition);
    }
    private bool HasReachedPosition(int index, Vector3 targetPosition)
    {
        Vector3 currentPosition = lineRenderer.GetPosition(index);

        return currentPosition==targetPosition;
    }
    private IEnumerator updateParticle()
    {
        while (gameObject.activeSelf)

        {
            splashParticle.gameObject.transform.position = targetPosition;

            isHitting = HasReachedPosition(1, targetPosition);
            splashParticle.gameObject.SetActive(isHitting);
           
            yield return null;
        }

    }
    private IEnumerator SplitSpawn()
    {
        while (true)
        {
            if (nowsplit)
            {
                int randomnum = Random.Range(0, Spliteffect.Length - 1);
                Instantiate(Spliteffect[randomnum], targetPosition+new Vector3(0,0.005f,0), Spliteffect[randomnum].transform.rotation);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
