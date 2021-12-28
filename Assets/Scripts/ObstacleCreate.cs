using System.Collections;
using UnityEngine;

public class ObstacleCreate : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstaclesTemplates;

    [SerializeField] private int _createDelay;

    [SerializeField] private ObstaclePlaceLogic _obstaclePlaceLogic;

    [SerializeField] private VariablesList _variablesList;

    private Vector2 _obstaclePosition;

    private Quaternion _obstacleRotation;

    private int _obstacleRotationValue;

    private int _obstacleChoose;


    private void Start()
    {
        StartCoroutine(CreateObstacle());
    }

    private IEnumerator CreateObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(_createDelay);
    
            _obstacleChoose = Random.Range(0, _obstaclesTemplates.Length);

            (_obstaclePosition, _obstacleRotationValue) = _obstaclePlaceLogic.SetRandomObstacle(_obstaclesTemplates.Length, _obstacleChoose);
            
            _obstacleRotation = Quaternion.Euler(0,0,_obstacleRotationValue);

            GameObject obstacle = Instantiate(_obstaclesTemplates[_obstacleChoose], _obstaclePosition, _obstacleRotation);

            if (_obstacleChoose == 5)
            {
                if (obstacle.TryGetComponent(out Bullet bullet))
                {
                    switch (Random.Range(0, 4))
                    {
                        case 0:
                            obstacle.transform.position =new Vector2(-5, Random.Range(-4f, 4f));
                            bullet._transformVector = new Vector2(_variablesList.BulletMoveSpeed, 0);
                            break;
                        case 1:
                            obstacle.transform.position =new Vector2(Random.Range(-2.5f, 2.5f), 6);
                            bullet._transformVector = new Vector2(0, -_variablesList.BulletMoveSpeed);
                            break;
                        case 2:
                            obstacle.transform.position = new Vector2(5, Random.Range(-4f, 4f));
                            bullet._transformVector = new Vector2(-_variablesList.BulletMoveSpeed, 0);
                            break;
                        case 3:
                            obstacle.transform.position =new Vector2(Random.Range(-2.5f, 2.5f), -6);
                            bullet._transformVector = new Vector2(0, _variablesList.BulletMoveSpeed);
                            break;
                    }
                }
                
            }
            
        }
    }
    



}