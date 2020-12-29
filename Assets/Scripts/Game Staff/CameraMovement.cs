using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Position Variables")]
    public Transform target;
    public Vector2 maxPosition;
    public Vector2 minPosition;
    public float smoothing;

    [Header("Animator")]
    public Animator anim;

    [Header("Position Reset")]
    public VectorValue camMin;
    public VectorValue camMax;

    // Start is called before the first frame update
    void Start()
    {
        maxPosition = camMax.initialValue;
        minPosition = camMin.initialValue;
        anim = GetComponent<Animator>();
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
    }

    
    // Update is called once per frame
    void LateUpdate()
    {
        if (this.target)
        {
            Vector3 targetPosition = new Vector3()
            {
                x = this.target.position.x,
                y = this.target.position.y,
                z = this.target.position.z - 10,
            };

            targetPosition.x = Mathf.Clamp(targetPosition.x,
                                           minPosition.x,
                                           maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y,
                                          minPosition.y,
                                          maxPosition.y);

            Vector3 pos = Vector3.Lerp( transform.position,targetPosition, smoothing);
            this.transform.position = pos;
        }
    }

    public void BeginKick()
    {
        anim.SetBool("kick_active",true);
        StartCoroutine(KickCo());
    }

    public IEnumerator KickCo()
    {
        yield return null;
        anim.SetBool("kick_active", false);
    }
}
