using System.Collections;
using UnityEngine;

public class foodBehaviour : MonoBehaviour
{
    

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(DestroyFood());
    }


    private IEnumerator DestroyFood()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
