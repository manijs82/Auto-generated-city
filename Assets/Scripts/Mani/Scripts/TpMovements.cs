using UnityEngine;

namespace Mani.Scripts
{
    public interface ITpMovements
    {
        void TpMoveAndRotateTransform(float xAxis, float yAxis, float turnSmoothVelocity,
            Vector3 cameraDirection = default);

        void TpMoveTransform(float xAxis, float yAxis, Vector3 cameraDirection = default);

        void TpMoveAndRotateRigidbody(float xAxis, float yAxis, float turnSmoothVelocity,
            Vector3 cameraDirection = default);

        void TpMoveRigidbody(float xAxis, float yAxis, Vector3 cameraDirection = default);

        void TpMoveAndRotateController(float xAxis, float yAxis, float turnSmoothVelocity,
            Vector3 cameraDirection = default);

        void TpMoveController(float xAxis, float yAxis, Vector3 cameraDirection = default);
    }

    public class TpMovements : ITpMovements
    {
        private readonly Transform _transform;
        private readonly Rigidbody _rigidbody;
        private readonly CharacterController _characterController;
        private float Speed;

        public TpMovements(Transform transform, float speed)
        {
            _transform = transform;
            Speed = speed;
        }

        public TpMovements(Rigidbody rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            Speed = speed;
        }

        public TpMovements(CharacterController characterController, float speed)
        {
            _characterController = characterController;
            Speed = speed;
        }

        public void TpMoveAndRotateTransform(float xAxis, float yAxis, float turnSmoothVelocity,
            Vector3 cameraDirection = default)
        {
            Vector3 direction = new Vector3(xAxis, 0, yAxis).normalized;
            if (cameraDirection != default)
                direction += cameraDirection;
            if (!(direction.magnitude >= 0.1f)) return;

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(_transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                .1f);

            _transform.eulerAngles = new Vector3(0, angle, 0);

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            _transform.position += moveDir.normalized * (Speed * Time.deltaTime);
        }

        public void TpMoveTransform(float xAxis, float yAxis, Vector3 cameraDirection = default)
        {
            Vector3 direction = new Vector3(xAxis, 0, yAxis).normalized;
            if (cameraDirection != default)
                direction += cameraDirection;
            if (!(direction.magnitude >= 0.1f)) return;

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            _transform.position += moveDir.normalized * (Speed * Time.deltaTime);
        }

        public void TpMoveAndRotateRigidbody(float xAxis, float yAxis, float turnSmoothVelocity,
            Vector3 cameraDirection = default)
        {
            Vector3 direction = new Vector3(xAxis, 0, yAxis).normalized;
            if (cameraDirection != default)
                direction += cameraDirection;
            if (!(direction.magnitude >= 0.1f)) return;

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(_rigidbody.rotation.y, targetAngle, ref turnSmoothVelocity,
                .1f);

            _rigidbody.transform.eulerAngles = new Vector3(0, angle, 0);

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            _rigidbody.position += moveDir.normalized * (Speed * Time.deltaTime);
        }

        public void TpMoveRigidbody(float xAxis, float yAxis, Vector3 cameraDirection = default)
        {
            Vector3 direction = new Vector3(xAxis, 0, yAxis).normalized;
            if (cameraDirection != default)
                direction += cameraDirection;
            if (!(direction.magnitude >= 0.1f)) return;

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            _rigidbody.position += moveDir.normalized * (Speed * Time.deltaTime);
        }

        public void TpMoveAndRotateController(float xAxis, float yAxis, float turnSmoothVelocity,
            Vector3 cameraDirection = default)
        {
            Vector3 direction = new Vector3(xAxis, 0, yAxis).normalized;
            if (cameraDirection != default)
                direction += cameraDirection;
            if (!(direction.magnitude >= 0.1f)) return;

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(_characterController.transform.rotation.y, targetAngle,
                ref turnSmoothVelocity,
                .1f);

            _characterController.transform.eulerAngles = new Vector3(0, angle, 0);

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            _characterController.Move(moveDir.normalized * (Speed * Time.deltaTime));
        }

        public void TpMoveController(float xAxis, float yAxis, Vector3 cameraDirection = default)
        {
            Vector3 direction = new Vector3(xAxis, 0, yAxis).normalized;
            if (cameraDirection != default)
                direction += cameraDirection;
            if (!(direction.magnitude >= 0.1f)) return;

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            _characterController.Move(moveDir.normalized * (Speed * Time.deltaTime));
        }
    }
}