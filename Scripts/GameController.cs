using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController controller;

    public GameObject go;
    public GameObject a;
    public GameObject[] B;

    // Start is called before the first frame update
    void Start()
    {
        controller = this;
    }

    public void End()
    {
        go.SetActive(true);
    }

    // Update is called once per frame
    void Update(){
        foreach (var b in B)
        {
            if (b == null)
                continue;

                if (Vector3.Distance(a.gameObject.gameObject.GetComponent<Transform>().position, b.gameObject.gameObject.transform.position) < 0.2f)
                {
                    a.SendMessage("SendMEssage", b);
                }

        }
    }
}
