using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;


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
    
    //public Vector3[] positions;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //thisPos = gameObject.transform.position;
        
        m = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Spawn>();


        m.trs.Add(gameObject.transform);

        
        
    }

    // Update is called once per frame
    void Update()
    {
        //m.trs[InList()] = gameObject.transform.position;
    }

    public void Generator()
    {
        
    }

    /*public int InList()
    {
        int index = -1;
        for (int i = 0; i < m.pos.Count; i++)
        {
            if (m.pos[i] == thisPos)
            {
                
                index = i;
            }
        }

        return index; //if index = -1, this child doesn't exist;
    }*/
    
    
}
