using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ImpactOnCollision : MonoBehaviour
{

    [SerializeField] private SpriteRenderer impactPrefab;
    [SerializeField] private float offset = 0.01f;
    [SerializeField] private Sprite sprite;

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            SpriteRenderer render = Instantiate(impactPrefab);
            render.transform.position = contact.point + -contact.normal * offset;
            render.transform.forward = -contact.normal;

            if (sprite != null)
            {
                render.sprite = sprite;
            }
        }
    }
}
