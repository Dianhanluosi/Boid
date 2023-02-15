using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine.Assertions.Must;
using Random = UnityEngine.Random;


public class StarController : MonoBehaviour
{

    public Vector3 thisPos;

    public Spawn m;

    public float xMin = -34f;
    public float xMax = 34f;
    public float yMin = -18.5f;
    public float yMax = 18.5f;
    public float sUnit = 2f;

    public GameObject newStar;

    public bool spanwed;
    public bool canSpawn = true;
    
    public List<Vector3> ranPos = new List<Vector3>();
    public int rp;

    public float[] d = { 0.2f, 0.4f, 0.6f, 0.8f };

    public int rand;

    public AudioSource aus;
    public AudioClip[] pianos;
    public int ranp;

    public bool move;

    private float cd = 2f;

    //private float cd2 = 18f;

    //public Rigidbody rb;
    
    //public Vector3[] positions;

    public bool played;
    
    // Start is called before the first frame update
    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody>();
        
        aus = gameObject.GetComponent<AudioSource>();
        ranp = Random.Range(0, pianos.Length - 1);
        aus.clip = pianos[ranp];
        aus.Play();

        m = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Spawn>();
        

        m.trs.Add(gameObject.transform);

        rand = Random.Range(0, d.Length - 1);
        StartCoroutine(GenDelay());
        //StartCoroutine(SelfDestruct());
        //gameObject.transform.position -= new Vector3(0, 0, gameObject.transform.position.z);

        move = false;

    }

    private IEnumerator GenDelay()
    {
        yield return new WaitForSeconds(d[rand]);
        Generator();
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //m.trs[InList()] = gameObject.transform.position;
        
        //Generator();
       /* if (transform.position.x >= xMax)
        {
            transform.position = new Vector3(xMax, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= xMin)
        {
            transform.position = new Vector3(xMin, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= yMax)
        {
            transform.position = new Vector3(transform.position.x, yMax, transform.position.z);
        }
        if (transform.position.x <= yMin)
        {
            transform.position = new Vector3(transform.position.x, yMin, transform.position.z);
        }*/

    }

    private void FixedUpdate()
    {
        cd -= Time.deltaTime;

        if (move)
        {
            SelfMoving();
        }
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

            if (ranPos[rp].x > xMax || ranPos[rp].x <= xMin || ranPos[rp].y >= yMax || ranPos[rp].y <= yMin)
            {
                Generator();
                return;
            }

            //if (canSpawn)
            //{
                Instantiate(newStar, ranPos[rp], quaternion.identity);
                spanwed = true;
            //}
        }
        
        

    }

    void SelfMoving()
    {
        Vector2 nextPos = new Vector2(Random.Range(xMin,xMax), Random.Range(yMin,yMax));
        //gameObject.GetComponent<Transform>().position = nextPos;
        Vector2 direction = nextPos - gameObject.GetComponent<Rigidbody2D>().position;
        float distance = direction.magnitude;
        float forceMagnitude = (gameObject.GetComponent<Rigidbody2D>().mass * 1000 / Mathf.Pow(distance, 2));
        gameObject.GetComponent<Rigidbody2D>().AddForce(direction.normalized * forceMagnitude);
        
        if (cd <= 0)
        {
            nextPos = new Vector2(Random.Range(xMin,xMax), Random.Range(yMin,yMax));
            cd = 2f;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Finish") && !played)
        {
            aus.PlayOneShot(aus.clip);
            played = true;
        }

        if (other.gameObject.GetComponent<Attractor>().tg != gameObject.GetComponent<Attractor>().tg)
        {
            aus.PlayOneShot(aus.clip);
            played = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        played = false;
    }
}
