using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Entity entity;
    public void Initialise (Entity entity) {
        this.entity = entity;
    }

    private void Update() {
        // Set the position and remove the screen offset
        GetComponent<RectTransform>().localPosition = UICanvas.WorldPosToScreenPos(entity.transform.position);

        GetComponent<RectTransform>().localScale = new Vector3(
            transform.localScale.x + Mathf.Sin(Time.time) * Time.deltaTime,
            0.1f,
            0f
        );
    }
}
