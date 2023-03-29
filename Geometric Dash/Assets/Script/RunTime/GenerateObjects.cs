using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GenerateObjects : MonoBehaviour
{
    [Header("Tableau Generate Object")]
    public GameObject[] _objectToGenerate;

    [Header("Value Random Position")]
    public Vector2 _randomRangeX;
    public Vector2 _randomRangeY;
    public Vector2 _randomRangeZ;

    private List<GameObject> ListObj = new List<GameObject>();

    private Vector3 position;
    private GameObject go;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            GenerateObject();

        // if (Input.GetKeyDown(KeyCode.E))
        //     DestroyLastObj();

    }

    private void Start()
    {

    }

    public void GenerateObject()
    {
        int index = Random.Range(0, _objectToGenerate.Length);

        position = new Vector3(Random.Range(_randomRangeX.x , _randomRangeX.y),
             Random.Range(_randomRangeY.x , _randomRangeY.y) ,
             Random.Range(_randomRangeZ.x, _randomRangeZ.y));


        go = Instantiate(_objectToGenerate[index], position, Quaternion.identity);
        ListObj.Add(go);
    }


    #region Destroy Object 
    public void DestroyLastObj()
    {
        if (ListObj.Count > 0)
        {
            GameObject lastObj = ListObj[ListObj.Count - 1];
            ListObj.RemoveAt(ListObj.Count - 1);
            Destroy(lastObj);
        }
    }
    #endregion

}
