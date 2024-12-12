using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Senses
    [SerializeField] bool vision;
    [SerializeField] bool smell;
    [SerializeField] bool touch;
    [SerializeField] bool hearing;
    [SerializeField] bool taste;


    [SerializeField] List<string> exceptions = new List<string>();

    private GameObject[] allGameObjects;
    private SpriteRenderer SpriteRenderer;
    private MeshRenderer MeshRenderer;

    void Start()
    {
        allGameObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        //Blindness(exceptions);
    }

    
    void Update()
    {
        if (!vision) Blindness(exceptions);
        else Vision();
    }


    void Blindness(List<string> exceptions)
    {
        // Hides Objects if Blind 
        // TO CHANGE: make dark?
        foreach (GameObject obj in allGameObjects)
        {
            if (obj != null && !(exceptions.Contains(obj.name)) )
            {
                SpriteRenderer = obj.GetComponent<SpriteRenderer>();
                if (SpriteRenderer != null)
                {
                    SpriteRenderer.enabled = false;

                }
                else
                {
                    MeshRenderer = obj.GetComponent<MeshRenderer>();

                    if (MeshRenderer != null)
                    {
                        MeshRenderer.enabled = false;

                    }
                        
                }


            }
        }
        
    }

    void Vision()
    {
        foreach (GameObject obj in allGameObjects)
        {
            if (obj != null && !(exceptions.Contains(obj.name)))
            {
                SpriteRenderer = obj.GetComponent<SpriteRenderer>();
                if (SpriteRenderer != null)
                {
                    SpriteRenderer.enabled = true;

                }
                else
                {
                    MeshRenderer = obj.GetComponent<MeshRenderer>();

                    if (MeshRenderer != null)
                    {
                        MeshRenderer.enabled = true;

                    }

                }


            }
        }
    }

}
