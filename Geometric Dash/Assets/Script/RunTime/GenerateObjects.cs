using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObjects : MonoBehaviour
{
    [Header("Tableau Generate Object")]
    public GameObject[] _objectToGenerate;

    [Header("List Object Instance")]
    public List<GameObject> ListObj = new List<GameObject>();

    public Vector3 position;
    private GameObject go;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            GenerateObject();
            
        if (Input.GetKeyDown(KeyCode.E))
            DestroyLastObj();
        
    }

    void GenerateObject()
    {
        int index = Random.Range(0, _objectToGenerate.Length);
        position = new Vector3(Random.Range(-10f, 10f), 0f, 0f);
        go = Instantiate(_objectToGenerate[index], position, Quaternion.identity);
        ListObj.Add(go);
    }

    public void DestroyLastObj()
    {
        if (ListObj.Count > 0)
        {
            GameObject lastObj = ListObj[ListObj.Count - 1];
            ListObj.RemoveAt(ListObj.Count - 1);
            Destroy(lastObj);
        }
    }
}
