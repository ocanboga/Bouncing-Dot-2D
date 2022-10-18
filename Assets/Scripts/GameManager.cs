using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject hexagon,circle,startText;
    public Transform startPos;
    private bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        hexagon.GetComponent<Turn>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !start)
        {
            circle.transform.position = startPos.position;
            hexagon.GetComponent<Turn>().enabled = true;
            startText.SetActive(false);

            start = true;
        }
    }
}
