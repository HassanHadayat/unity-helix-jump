using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody m_rb;
    [SerializeField] private GameObject splash;
    public float force;

    private void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Step"))
        {
            Debug.Log("Collided!");

            // Instantiate Bounce Splash
            GameObject splashGO = Instantiate(splash, collision.collider.transform);
            splashGO.transform.position = collision.contacts[0].point + (Vector3.up * 0.001f);
            float randRot = Random.Range(0f, 180f);
            splashGO.transform.Rotate(Vector3.forward, randRot);

            // Bounce
            m_rb.velocity = Vector3.zero;
            m_rb.velocity = Vector3.up * force;
        }
    }
}
