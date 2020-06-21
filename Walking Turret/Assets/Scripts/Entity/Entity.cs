
using System;
using System.Collections.Generic;
using UnityEngine;

/* An Entity is the abstract representation of any being 
 * that can move around and do stuff.
 * 
 */

// View. Unity specific
class Entity: MonoBehaviour
{
    EntityViewModel viewModel;

    public void Start() {
        viewModel = new EntityViewModel();
    }

    public void Update() {
        // Test movement
        viewModel.Position += 
            Vector3.forward * Mathf.Sin(Time.time) * Time.deltaTime  +
            Vector3.right * Mathf.Cos(Time.time) * Time.deltaTime;

        UpdateView();
    }

    // Represent the current state of the Entity
    public void UpdateView() {
        transform.position = viewModel.Position;
    }
}

// ViewModel. Interaction between View and Controller. Unity specific.
class EntityViewModel
{
    EntityModel model;
    EntityController controller;

    public EntityViewModel() {
        model = new EntityModel();
        controller = new EntityController(model);
    }

    public Vector3 Position {
        get {
            float[] position = model.Position;
            // Take data from Model and make it Unity-specific.
            return new Vector3(position[0], 0, position[1]);
        }
        set {
            // Take input from Unity and make it non Unity-specific
            controller.MoveToPosition(new float[] { value.x, value.z });
        }        
    }
}

// Controller. Game logic. No dependencies on Unity. Stateless, depends on Model.
class EntityController
{
    EntityModel model;

    public EntityController(EntityModel model) {
        this.model = model;
    }
    
    public void MoveToPosition(float[] position) {
        model.Position = position;
    }
}

// Model. Game logic, no dependencies on Unity. Has state (which may need to be saved).
class EntityModel
{
    public float[] Position { get; set; } = new float[] { 0, 0 };
}