using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller for game logic
// Should have no dependencies on Unity specifics (aside from data types)
public abstract class EntityController
{
    const int DEFAULT_HEALTH = 100;

    public LiveData<Vector3> position = new LiveData<Vector3>(Vector3.zero);
    public LiveData<Quaternion> rotation = new LiveData<Quaternion>(Quaternion.identity);
    public LiveData<int> health = new LiveData<int>(DEFAULT_HEALTH);

    // Lower health by the damage taken
    public void TakeDamage(int damage) {
        health.Value -= damage;
    }
}