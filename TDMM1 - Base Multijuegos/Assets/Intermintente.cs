using UnityEngine;


public class Intermintente : MonoBehaviour



{
    public GameObject targetObject;
    public float changeStateTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("ChangeObjectState", 0f,changeStateTime);
    }

    // Update is called once per frame
    void ChangeObjectState()
    {
        targetObject.SetActive(!targetObject.activeInHierarchy);
    }
}
