using System.Collections;
using UnityEngine;

namespace Firing
{
    public class ArrowController : MonoBehaviour
    {
        private new Rigidbody2D rigidbody2D;
        public bool IsLive { get; private set; }
        public bool JustShot { get; private set; }

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
            JustShot = true;
            transform.position = startPosition;
            gameObject.SetActive(true);

            Vector3 direction = targetDirection - startPosition;
            Debug.Log("Firing Dir: " + direction + " Normalized: " + direction.normalized);
            rigidbody2D.AddForce(direction.normalized * arrowSpeed, ForceMode2D.Impulse);
            StartCoroutine(MakeArrowLive());
        }

        private IEnumerator MakeArrowLive()
        {
            yield return new WaitForSeconds(0.1f);
            IsLive = true;
            JustShot = false;
        }
    }
}
