using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Over : MonoBehaviour
{
    public GameObject infoText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, -3f);
    }

    void OnCollisionEnter(Collision other)
    {
        infoText.GetComponent<InfoText>().GameOver();
    }
}
