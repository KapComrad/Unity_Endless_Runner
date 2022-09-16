using UnityEngine;

public class EndlessGround : MonoBehaviour
{
    [SerializeField] private GameObject[] _groundGameObject;
    [SerializeField] private Transform[] _groundTransform;

    [SerializeField] private Transform _playerTransform;
    private int _index;
    void Start()
    {
        _groundGameObject = GameObject.FindGameObjectsWithTag("Ground");
        _groundTransform = new Transform[_groundGameObject.Length];
        for (int i = 0; i < _groundGameObject.Length;i++)
        {
            _groundTransform[i] = _groundGameObject[i].GetComponent<Transform>();
        }
        _index = _groundGameObject.Length;
    }
    void Update()
    {
        for(int i = 0;i < _index; i++)
        {
            if (_groundTransform[i].position.x + 25 < _playerTransform.position.x)
            {
                _groundTransform[i].position = new Vector3(_groundTransform[i].position.x + 60,
                    _groundTransform[i].position.y,
                    _groundTransform[i].position.z);
            }
        }
    }
}
