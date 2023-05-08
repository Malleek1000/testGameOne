using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mycamerascript : MonoBehaviour
{

    public Transform ObjectToFollow;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, ObjectToFollow.position, 0.5f);
        transform.position = new Vector3(newPosition.x, newPosition.y, -10.0f);

    }
}
