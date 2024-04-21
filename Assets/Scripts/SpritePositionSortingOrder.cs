using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePositionSortingOrder : MonoBehaviour {

    [SerializeField] private bool runOnce;
    [SerializeField] private float offsetY;
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LasteUpdate() {
        float percisionMultiplier = 5f;

        spriteRenderer.sortingOrder = (int) (-(transform.position.y + offsetY) * percisionMultiplier);

        if (runOnce) {
            Destroy(this);
        }
    }
}
