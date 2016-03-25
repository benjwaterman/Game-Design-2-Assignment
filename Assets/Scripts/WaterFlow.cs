using UnityEngine;
using System.Collections;

public class WaterFlow : MonoBehaviour {

    public float scrollSpeed = 0.5F;
    public Renderer rend;

    private float currentYOffset;
    void Start()
    {
        rend = GetComponent<Renderer>();
        currentYOffset = rend.material.mainTextureOffset.y;
    }
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(offset, currentYOffset);
    }
}
