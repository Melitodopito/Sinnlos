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

    public bool getVision() { return vision; }

    [SerializeField] List<string> exceptions = new List<string>();


    private GameObject[] allGameObjects;
    public GameObject[] GetAllGameObjects() { return allGameObjects; }
    
    private SpriteRenderer SpriteRenderer;
    private MeshRenderer MeshRenderer;

    private LineRenderer[] smells;
    private ParticleSystem[] soundVisualEffects;
    private AudioSource[] sounds;




    void Start()
    {

        allGameObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        smells = FindObjectsByType<LineRenderer>(FindObjectsSortMode.None);
        soundVisualEffects = FindObjectsByType<ParticleSystem>(FindObjectsSortMode.None);
        sounds = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
    }

    
    void Update()
    {
        if (!vision) Blindness(exceptions, allGameObjects);
        else Vision(allGameObjects);
        if (!smell) Anosmia(smells);
        else Smell(smells);
        if (!hearing) Deafness(soundVisualEffects,sounds);
        else Hearing(soundVisualEffects, sounds);
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

    void Hearing(ParticleSystem[] soundVisualEffects, AudioSource[] sounds) 
    {
        foreach (ParticleSystem pS in soundVisualEffects)
        {
            if (pS != null)
            {
                pS.Play();
            }
        }

        foreach (AudioSource aS in sounds)
        {
            if (aS != null)
            {
                aS.Play();
            }
        }
    }

    void Deafness(ParticleSystem[] soundVisualEffects, AudioSource[] sounds)
    {
        foreach (ParticleSystem pS in soundVisualEffects)
        {
            if (pS != null)
            {
                pS.Pause();
            }
        }

        foreach (AudioSource aS in sounds)
        {
            if (aS != null)
            {
                aS.Stop();
            }
        }


    }

    public int CountObjectWithTag(GameObject[] allGameObjects, string enemyTag)
    {
        int enemyCount = 0;
        foreach(GameObject obj in allGameObjects)
        {
            if (obj.tag == enemyTag)
            {
                enemyCount++;
            }
        }
        return enemyCount;
    }
}
