using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCap : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = 120;
    }
}
