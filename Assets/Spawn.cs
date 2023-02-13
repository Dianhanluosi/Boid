using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;


public class Spawn : MonoBehaviour
{
    public List<Transform> trs = new List<Transform>();


    public Vector3 spawnPos;

    public GameObject[] pawns;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Click();
        
        //Debug.Log(spawnPos);
    }

    void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;

            mousePos.z = Camera.main.nearClipPlane;
            
            spawnPos = Camera.main.ScreenToWorldPoint(mousePos);

            Instantiate(pawns[Random.Range(0, pawns.Length)], spawnPos, quaternion.identity);

        }
    }

    void AddPos()
    {
        /*GameObject[] stars = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject star in stars)
        {
            star.transform.position = new Vector3(0, 0, 0);
        }*/
    }
    
}
