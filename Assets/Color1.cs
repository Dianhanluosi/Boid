using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Linq;
using System.Xml.Linq;

public class Color1 : MonoBehaviour
{
    
    public string[] set = {
        "#870A30", "#EC8FD0", "#D43790", "#F2C5E0"
    };

    public Color c;
    private SpriteRenderer sr;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        
        ColorUtility.TryParseHtmlString(set[Random.Range(0,set.Length)], out c);

        sr.color = c;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
