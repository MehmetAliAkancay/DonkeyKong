using UnityEngine;

public class Barrel : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    public float speed = 2f;
    private void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("DeathZone")){
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")) {
            rigidbody2D.AddForce(collision.transform.right * speed, ForceMode2D.Impulse);
        }
    }
}
