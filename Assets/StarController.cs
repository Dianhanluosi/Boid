using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;
using Random = UnityEngine.Random;


public class StarController : MonoBehaviour
{

    public Vector3 thisPos;

    public Spawn m;

    public float xMin = -35f;
    public float xMax = 35f;
    public float yMin = -19.5f;
    public float yMax = 19.5f;
    public float sUnit = 1f;

    public GameObject newStar;

    public bool spanwed;
    public bool canSpawn = true;
    
    public List<Vector3> ranPos = new List<Vector3>();
    public int rp;
    
    //public Vector3[] positions;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //thisPos = gameObject.transform.position;
        
        m = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Spawn>();


        m.trs.Add(gameObject.transform);

        //ranPos = new Vector3[4];
        //ranPos.Add(gameObject.transform.position + new Vector3(sUnit, 0, 0));
        //ranPos.Add(gameObject.transform.position - new Vector3(sUnit, 0, 0));
        //ranPos.Add(gameObject.transform.position + new Vector3(0, sUnit, 0));
        //ranPos.Add(gameObject.transform.position - new Vector3(0, sUnit, 0));

        StartCoroutine(GenDelay());
    }

    private IEnumerator GenDelay()
    {
        yield return new WaitForSeconds(Random.Range(0.2f, 0.4f));
        Generator();
    }

    // Update is called once per frame
    void Update()
    {
        //m.trs[InList()] = gameObject.transform.position;
        
        //Generator();
        
    }

    public void PositionRandomizer()
    {
        ranPos.Clear();
        
        ranPos.Add(gameObject.transform.position + new Vector3(sUnit, 0, 0));
        ranPos.Add(gameObject.transform.position - new Vector3(sUnit, 0, 0));
        ranPos.Add(gameObject.transform.position + new Vector3(0, sUnit, 0));
        ranPos.Add(gameObject.transform.position - new Vector3(0, sUnit, 0));

        rp = Random.Range(0, 3);
        
        //canSpawn = true;

    }
    
    public void Generator()
    {
        PositionRandomizer();

        
        if (!spanwed)
        {
            
            for (int i = 0; i < m.trs.Count; i++)
            {
                if (m.trs[i].position == ranPos[rp])
                {
                    
                    Generator();
                    return;
                }
            }

            //if (canSpawn)
            //{
                Instantiate(newStar, ranPos[rp], quaternion.identity);
                spanwed = true;
            //}
        }

    }

    /*public int InList()
    {
        int index = -1;
        for (int i = 0; i < m.trs.Count; i++)
        {
            if (m.trs[i].position == thisPos)
            {
                
                index = i;
            }
        }

        return index; //if index = -1, this child doesn't exist;
    }*/
    
    
}
