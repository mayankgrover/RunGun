using UnityEngine;

namespace Firing
{
    public class ArrowController : MonoBehaviour
    {
        private new Rigidbody2D rigidbody2D;
        public bool IsLive { get; private set; }

        public float arrowSpeed;

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            IsLive = false;
        }

        // Use this for initialization
        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.parent != null && collision.transform.parent.tag == "Platform")
            {
                IsLive = false;
                rigidbody2D.velocity = Vector2.zero;
            }
        }

        public void PickUp()
        {
            gameObject.SetActive(false);
        }

        public void Fire(Vector3 startPosition, Vector3 targetDirection)
        {
            IsLive = true;
            transform.position = startPosition;
            gameObject.SetActive(true);
            rigidbody2D.AddForce(targetDirection * arrowSpeed, ForceMode2D.Impulse);
        }
    }
}
