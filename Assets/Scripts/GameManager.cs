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
    private LineRenderer[] smells;
    private ParticleSystem[] sounds;

    private SpriteRenderer SpriteRenderer;
    private MeshRenderer MeshRenderer;

    void Start()
    {

        allGameObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        smells = FindObjectsByType<LineRenderer>(FindObjectsSortMode.None);
        sounds = FindObjectsByType<ParticleSystem>(FindObjectsSortMode.None);
        //Blindness(exceptions);
    }

    
    void Update()
    {
        if (!vision) Blindness(exceptions, allGameObjects);
        else Vision(allGameObjects);
        if (!smell) Anosmia(smells);
        else Smell(smells);
        if (!hearing) Deafness(sounds);
        else Hearing(sounds);
    }


    void Blindness(List<string> exceptions, GameObject[] allGameObjects)
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

    void Vision(GameObject[] allGameObjects)
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

    // Anosmia means not being able to smell
    void Anosmia(LineRenderer[] smells)
    {
        foreach (LineRenderer lr in smells)
        {
            if (lr != null)
            {  
                lr.enabled = false;
            }
        }
    }
    void Smell(LineRenderer[] smells)
    {
        foreach (LineRenderer lr in smells)
        {
            if (lr != null)
            {
                lr.enabled = true;
            }
        }
    }

    void Hearing(ParticleSystem[] sounds) 
    {
        foreach (ParticleSystem pS in sounds)
        {
            if (pS != null)
            {
                pS.Play();
            }
        }
    }

    void Deafness(ParticleSystem[] sounds)
    {
        foreach (ParticleSystem pS in sounds)
        {
            if (pS != null)
            {
                pS.Pause();
            }
        }
    }


}
