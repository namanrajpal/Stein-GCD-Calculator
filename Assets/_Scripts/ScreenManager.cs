﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class ScreenManager : MonoBehaviour
{

    //Screen to open automatically at the start of the Scene
    public GameObject initiallyOpen;

    GameObject currentllyOpen;

    Stack<GameObject> screenStack;

    public void Awake()
    {
        if (initiallyOpen.activeInHierarchy == false)
        {
            initiallyOpen.SetActive(true);
            
        }
        currentllyOpen = initiallyOpen;

        if (initiallyOpen == null)
            Debug.LogError("Please select a default screen in Screen Manager");
    }

    public void Start()
    {
        screenStack = new Stack<GameObject>();
    }

    public void Update()
    {
        //this will map to back button on Android
        if (Input.GetKeyDown(KeyCode.Escape) && screenStack.Count>0)
        {
            GoBack();
        }

    }

    public void OpenScreen(GameObject screenToOpen)
    {
        screenStack.Push(currentllyOpen);
        currentllyOpen.SetActive(false);

        screenToOpen.SetActive(true);
        currentllyOpen = screenToOpen;
        
    }


    public void GoBack()
    {
        
        currentllyOpen.SetActive(false);
        GameObject screenToOpen = screenStack.Pop();
        screenToOpen.SetActive(true);
        currentllyOpen = screenToOpen;

    }
    

}