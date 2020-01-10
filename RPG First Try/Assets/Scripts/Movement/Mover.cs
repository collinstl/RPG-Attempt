﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            MoveToCursor();
        }   

        UpdateAnimator();
    }

    private void MoveToCursor() //Character click to move
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool  hasHit = Physics.Raycast(ray, out hit);
        if(hasHit)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }
    }

    private void UpdateAnimator() //Animation blender and character speed
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("ForwardSpeed", speed);
    }
}
