using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopDisplay : MonoBehaviour
{
    [SerializeField] Text t;
    [SerializeField] GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t.text = "Population:" + gm.population;
    }
}
