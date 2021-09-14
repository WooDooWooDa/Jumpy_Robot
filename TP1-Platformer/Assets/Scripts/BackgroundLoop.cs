using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject[] levels;
    public float choke;
    private Camera mainCamera;
    private Vector2 screenBounds;

    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        foreach (GameObject obj in levels)
        {
            LoadChildObjects(obj);
        }
    }

    void LoadChildObjects(GameObject obj)
    {
        float objWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x -choke;
        int childNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objWidth);
        var clone = Instantiate(obj) as GameObject;
        for (int i = 0; i < childNeeded; i++)
        {
            var c = Instantiate(clone);
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }

    private void LateUpdate()
    {
        foreach (GameObject obj in levels)
        {
            RepositionChildObjects(obj);
        }
    }

    void RepositionChildObjects(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if (children.Length > 1)
        {
            var firstChild = children[1].gameObject;
            var lastChild = children[children.Length - 1].gameObject;
            float halfObjWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - choke;
            if (transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjWidth * 1.5)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            } else if (transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjWidth * 1.5)
            {
                lastChild.transform.SetAsLastSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }
}
