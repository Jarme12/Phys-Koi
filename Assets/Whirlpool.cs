using UnityEngine;

public class Whirlpool : MonoBehaviour
{
    public float maxSuction = 12f;
    public float minSuction = 2f;
    public float swirlStrength = 8f;
    public float centerRadius = 0.5f;
    public float fishSuctionMultiplier = 0.3f; 
    public float escapeResistance = 0.4f;      

    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D rb = other.attachedRigidbody;
        if (rb == null) return;

        Vector2 toCenter = (Vector2)transform.position - rb.position;
        float distance = toCenter.magnitude;
        Vector2 dir = toCenter.normalized;

        float suction = (distance > centerRadius)
            ? Mathf.Lerp(minSuction, maxSuction, 1f - (distance / 5f))
            : maxSuction;

        if (other.CompareTag("Player"))
            suction *= fishSuctionMultiplier;

        float dot = Vector2.Dot(rb.linearVelocity.normalized, -dir);

        if (dot > 0.2f)
        {
            suction *= escapeResistance; 
        }

        Vector2 tangent = new Vector2(-dir.y, dir.x);

        Vector2 finalVelocity =
            dir * suction +
            tangent * swirlStrength;

        rb.linearVelocity = finalVelocity;
    }
}
