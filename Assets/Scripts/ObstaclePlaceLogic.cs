using System.Collections;
using UnityEngine;

public class ObstaclePlaceLogic : MonoBehaviour
{
    private Vector2 _resolution;
    private Camera _camera;
    [SerializeField] private GameObject _player;

    private void Start()
    {
        _camera = Camera.main;
        _resolution = _camera.ScreenToWorldPoint(new Vector2(_camera.pixelWidth, _camera.pixelHeight));
    }

    public (Vector2 position, int rotation) SetRandomObstacle(int arrayLength, int obstacleChoose)
    {
        switch (obstacleChoose)
        {
            case 0:
                return ((Vector2)_player.transform.position + new Vector2(Random.Range(-1.5f,1.5f),Random.Range(-1.5f,1.5f)), 0);

            case 1:
            case 4:    
                return (_player.transform.position, 0);

            case 2:
                switch (Random.Range(0, 4))
                {
                    case 0:
                        return (new Vector2(-_resolution.x, Random.Range(-_resolution.y, _resolution.y) * 0.9f ) , 0);

                    case 1:
                        return (new Vector2(Random.Range(-_resolution.x, _resolution.x ) * 0.9f, _resolution.y), -90);

                    case 2:
                        return (new Vector2(_resolution.x, Random.Range(-_resolution.y, _resolution.y) * 0.9f ), -180);

                    case 3:
                        return (new Vector2(Random.Range(-_resolution.x, _resolution.x) * 0.9f, -_resolution.y), -270);

                }
                break;
            case 3:
                switch (Random.Range(0, 4))
                {
                    case 0:
                        return (new Vector2(-4, Random.Range(-6f,6f)), 0);

                    case 1:
                        return (new Vector2(Random.Range(-4f, 4f), 6), 0);

                    case 2:
                        return (new Vector2(4, Random.Range(-6f,6f)), 0);

                    case 3:
                        return (new Vector2(Random.Range(-4f, 4f), -6), 0);

                }
                break;
            case 5:
                break;
        }
        return (default, 0);
    }
}
