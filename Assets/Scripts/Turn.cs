using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    private float beklemeSuresi = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(HexagonTurn());
    }
    IEnumerator HexagonTurn()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, 0));
        if (Input.GetMouseButtonDown(0) && mousePos.x>0)
        {
            transform.Rotate(0, 0, -30);
            yield return new WaitForSeconds(beklemeSuresi);
            transform.Rotate(0, 0, -30);
        }
        else if (Input.GetMouseButtonDown(0) && mousePos.x < 0)
        {
            transform.Rotate(0, 0, 30);
            yield return new WaitForSeconds(beklemeSuresi);
            transform.Rotate(0, 0, 30);
        }
    }
}
