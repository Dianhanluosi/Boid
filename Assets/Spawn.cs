using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    public int count;
    public List<Transform> trs = new List<Transform>();
    public List<Vector3> trsp = new List<Vector3>();


    public Vector3 spawnPos;

    public GameObject[] pawns;

    public List<GameObject> spawnedPawn = new List<GameObject>();

    public bool stoppedOnce;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Click();
        
        
        //Debug.Log(spawnPos);

        
        
        count = GameObject.FindGameObjectsWithTag("Player").Length;
        if (GameObject.FindGameObjectsWithTag("Player").Length >= 80)
        {
            StarController[] scs = FindObjectsOfType<StarController>();
            foreach (StarController sc in scs)
            {
                sc.spanwed = true;
            }
            
        }
        
        InitialMovement();

        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;

            mousePos.z = Camera.main.nearClipPlane;
            
            spawnPos = Camera.main.ScreenToWorldPoint(mousePos);
            //spawnPos -= new Vector3(0, 0, Camera.main.ScreenToWorldPoint(mousePos).z);

            GameObject newPawn = Instantiate(pawns[Random.Range(0, pawns.Length)], spawnPos, quaternion.identity);
            
            spawnedPawn.Add(newPawn);
        }
    }

    void InitialMovement()
    {
        for (int i = 0; i < spawnedPawn.Count; i++)
        {
            spawnedPawn[i].GetComponent<StarController>().move = true;
        }
    }
    
}
