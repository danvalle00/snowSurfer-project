using UnityEngine;
public class SnowTrail : MonoBehaviour

{
    [SerializeField] private ParticleSystem snowTrail;
    int groundLayer;
    private void Start()
    {
        groundLayer = LayerMask.NameToLayer("Floor");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            snowTrail.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            snowTrail.Stop();
        }
    }
}
