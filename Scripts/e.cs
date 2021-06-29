using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e : MonoBehaviour
{
    private Vector3 Target;

    // Start is called before the first frame update
    void Start()
    {
        Target = Random.insideUnitCircle * 4;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target, 2 * Time.deltaTime);
        if (transform.position == Target)
            Target = Random.insideUnitCircle * 4    ;
    }
}
