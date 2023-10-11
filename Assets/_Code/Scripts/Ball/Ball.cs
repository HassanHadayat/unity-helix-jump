using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody m_rb;
    [SerializeField] private TrailRenderer m_Trail;
    [SerializeField] private MeshRenderer m_MeshRenderer;
    [SerializeField] private GameObject splash;

    [SerializeField] private Material normalMaterial;
    [SerializeField] private Material stepMaterial;
    [SerializeField] private Material fireMaterial;
    [SerializeField] private Material fireEndMaterial;

    public float force;
    private int score = 0;

    private bool isBouncing = true;

    public bool isFireMovement = false;
    public int fireCount = 0;

    private void Start()
    {
        score = 0;
        isBouncing = true;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!isBouncing) return;

        if (collision.collider.CompareTag("Step"))
        {
            Debug.Log("Collided!");

            // Instantiate Bounce Splash
            GameObject splashGO = Instantiate(splash, collision.collider.transform);
            splashGO.transform.position = collision.contacts[0].point + (Vector3.up * 0.03f);
            float randRot = Random.Range(0f, 180f);
            splashGO.transform.Rotate(Vector3.forward, randRot);

            // Bounce
            m_rb.velocity = Vector3.zero;
            m_rb.velocity = Vector3.up * force;


            // Reset Fire Configs
            if (isFireMovement)
            {
                // Set to Normal Mode
                NormalMode();


                // Break Step
                collision.collider.transform.parent.GetComponent<Step>().Explode(fireEndMaterial);

            }
            fireCount = 0;

        }
        else if (collision.collider.CompareTag("Step Bad"))
        {
            if (isFireMovement)
            {

                // Break Step
                collision.collider.transform.parent.GetComponent<Step>().Explode(fireEndMaterial);

                // Set to Normal Mode
                NormalMode();
            }
            else
            {
                isBouncing = false;

                // Bounce
                m_rb.velocity = Vector3.zero;
                m_rb.velocity = Vector3.up * force / 3;

                // Level Failed
                UIManager.Instance.ShowLevelFailedPanel();

            }
            fireCount = 0;


        }
        else if (collision.collider.CompareTag("Step Finish"))
        {
            isBouncing = false;
            NormalMode();

            // Bounce
            m_rb.velocity = Vector3.zero;
            m_rb.velocity = Vector3.up * force;

            // Level Completed
            UIManager.Instance.ShowLevelCompletedPanel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isBouncing) return;

        if (other.CompareTag("Step Good"))
        {

            // Increment Score
            score++;
            UIManager.Instance.UpdateScore(score);

            if (isFireMovement)
            {
                other.transform.parent.GetComponent<Step>().Explode(fireMaterial);
            }
            else
            {
                other.transform.parent.GetComponent<Step>().Explode(stepMaterial);

                // Increment Fire Configs
                fireCount++;
                if (fireCount == 3)
                {
                    // Initiate Fire
                    FireMode();
                }
            }
        }
    }

    private void FireMode()
    {
        isFireMovement = true;
        m_Trail.startColor = Color.red;

        m_MeshRenderer.material = fireMaterial;
    }
    public void NormalMode()
    {
        isFireMovement = false;
        fireCount = 0;
        m_Trail.startColor = Color.white;

        m_MeshRenderer.material = normalMaterial;
    }
}
