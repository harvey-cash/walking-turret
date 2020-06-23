using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Singleton pattern
public class UICanvas : MonoBehaviour
{
    public static UICanvas instance;

    private Canvas canvas;

    private void Awake() {
        if (instance != null) { Destroy(instance); }
        instance = this;
        canvas = GetComponent<Canvas>();
    }
    public static HealthBar CreateNewHealthBar(Entity entity) {
        GameObject healthBarGameObject = new GameObject(entity.name + " health bar");
        healthBarGameObject.AddComponent<CanvasRenderer>();
        Image image = healthBarGameObject.AddComponent<Image>();
        image.color = Color.red;
        healthBarGameObject.transform.SetParent(instance.transform, false);
        HealthBar healthBar = healthBarGameObject.AddComponent<HealthBar>();
        healthBar.Initialise(entity);
        return healthBar;
    }

    public static Vector3 WorldPosToScreenPos(Vector3 position) {
        Vector3 screenSize = new Vector3(Screen.width, 0, Screen.height);
        return Camera.main.WorldToScreenPoint(position) - (screenSize / 2);
    }
}
