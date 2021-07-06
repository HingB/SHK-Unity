using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerCollision))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _normalSpeed;
    [SerializeField] private float _baffSpeed;
    [SerializeField] private float _timeSpeedBaffAction;

    private float _currentSpeed;
    private Coroutine _setNormalSpeedJob;
    private PlayerCollision _playerCollision;

    private void OnEnable()
    {
        _playerCollision = GetComponent<PlayerCollision>();

        _playerCollision.BoosterTaken += OnBoosterTaken;
    }

    private void OnDisable()
    {
        _playerCollision.BoosterTaken -= OnBoosterTaken;
    }

    private void Start()
    {
        _currentSpeed = _normalSpeed;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 direction;

        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        transform.Translate(direction * _currentSpeed * Time.deltaTime);
    }

    private void StartSetNormalSpeed()
    {
        if (_setNormalSpeedJob != null)
            StopCoroutine(_setNormalSpeedJob);
 
        _setNormalSpeedJob = StartCoroutine(SetNormalSpeed(_timeSpeedBaffAction));
    }

    private void OnBoosterTaken()
    {
        _currentSpeed = _baffSpeed;

        StartSetNormalSpeed();
    }

    private IEnumerator SetNormalSpeed(float waitingTime)
    {
        yield return new WaitForSeconds(waitingTime);

        _currentSpeed = _normalSpeed;
    }
}
