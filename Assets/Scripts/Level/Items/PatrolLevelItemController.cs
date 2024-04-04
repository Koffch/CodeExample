using Descriptions.LevelItem;
using UnityEngine;

namespace Level.Items
{
    public class PatrolLevelItemController : LevelItemController<PatrolLevelItemDescription>
    {
        [SerializeField] private Transform Detector;
        
        private Transform _target;
        private int _patrolPointIndex;

        public override void Init(ILevelItemDescription description)
        {
            base.Init(description);
            _patrolPointIndex = 0;
            var diagonal = Description.DetectRadius * 2;
            Detector.localScale = new Vector3(diagonal, diagonal, 1);
        }

        private void Update()
        {
            Vector3 direction;

            if (_target)
            {
                direction = (_target.position - transform.position).normalized;
            }
            else
            {
                var div = (Vector3) Description.PatrolWay[_patrolPointIndex] - transform.position;
                if (div.magnitude < 0.1)
                {
                    _patrolPointIndex = (_patrolPointIndex + 1) % Description.PatrolWay.Count;
                    div = (Vector3) Description.PatrolWay[_patrolPointIndex] - transform.position;
                }

                direction = div.normalized;
            }

            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Description.RotationSpeed * Time.deltaTime);
            transform.position += transform.right * (Description.MoveSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Thief"))
                _target = other.transform;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Thief"))
                _target = null;
        }
    }
}