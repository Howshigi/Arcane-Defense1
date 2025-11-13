using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Autokillfortest : MonoBehaviour
{
    [Tooltip("ปริมาณดาเมจที่จะมอบ (9999 = auto kill)")]
    public int damage = 9999;

    [Tooltip("ถ้า true จะทำงานแค่กับ tag ที่กำหนด")]
    public bool useTagFilter = true;
    public string targetTag = "Enemy";

    [Tooltip("ถ้าทำเป็น oneShot จะทำลายกำแพงหลังชนครั้งเดียว")]
    public bool oneShot = false;

    private Collider2D col;

    void Reset()
    {
        col = GetComponent<Collider2D>();
        if (col != null) col.isTrigger = true;
    }

    void Awake()
    {
        col = GetComponent<Collider2D>();
        if (col != null) col.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (useTagFilter && !other.CompareTag(targetTag)) return;

        // ถ้ามี Enemy script ทำ TakeDamage
        var enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        else
        {
            Destroy(other.gameObject);
        }

        if (oneShot)
            Destroy(gameObject);
    }
}
