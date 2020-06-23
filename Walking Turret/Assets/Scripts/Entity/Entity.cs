
using System;
using System.Collections.Generic;
using UnityEngine;

/* An Entity is the abstract representation of any being 
 * that can move around and do stuff.
 * 
 */

// ViewModel. Unity specific
public abstract class Entity: MonoBehaviour
{
    protected EntityController controller;
    protected abstract EntityController GetController();

    private HealthBar healthBar;

    private void Awake() {
        controller = GetController();

        // Create UI elements
        healthBar = UICanvas.CreateNewHealthBar(this);
    }

    private void Start() {
        controller.position.Observe(value => transform.position = value);
        controller.rotation.Observe(value => transform.rotation = value);
    }
}