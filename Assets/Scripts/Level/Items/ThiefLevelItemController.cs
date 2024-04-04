using Descriptions.LevelItem;
using Tools;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Level.Items
{
    public class ThiefLevelItemController : LevelItemController<ThiefLevelItemDescription>
    {
        [SerializeField] private LevelItemCounterController CounterController;
        [SerializeField] private Transform Detector;

        private Vector3 _targetPosition;

        public override void Init(ILevelItemDescription description)
        {
            base.Init(description);
            _targetPosition = GetRandomPoint();
            CounterController.Value = 0;
            var diagonal = Description.DetectRadius * 2;
            Detector.localScale = new Vector3(diagonal, diagonal, 1);
        }

        private void Update()
        {
            var div = _targetPosition - transform.position;
            var magnitude = div.magnitude;
            if (magnitude < 0.1)
            {
                _targetPosition = GetRandomPoint();
                div = _targetPosition - transform.position;
            }

            var direction = div.normalized;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Description.RotationSpeed * Time.deltaTime);

            var moveSpeed = Description.MoveSpeed;
            if (magnitude < 2)
                moveSpeed *= magnitude / 2;
            transform.position += transform.right * (moveSpeed * Time.deltaTime);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Guard"))
            {
                _targetPosition = transform.position * 2 - other.transform.position;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Guard"))
            {
                _targetPosition = GetRandomPoint();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Treasure"))
                _targetPosition = other.transform.position;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Guard"))
            {
                CounterController.Value = 0;
                transform.position = GetRandomPoint();
                _targetPosition = GetRandomPoint();
            }
            else if (other.gameObject.CompareTag("Treasure"))
            {
                CounterController.Value++;
                _targetPosition = GetRandomPoint();
            }
        }

        private Vector3 GetRandomPoint()
        {
            return new Vector3(Random.Range(-12, 12), Random.Range(-12, 12));
        }
    }
}