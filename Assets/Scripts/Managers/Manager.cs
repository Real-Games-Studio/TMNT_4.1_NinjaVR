using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    [SerializeField] private FruitsSpawner _fruitsSpawner;
    [SerializeField] private FruitsPool _fruitsPool;
    [SerializeField] private ParticlesPool _particlesPool;
    [SerializeField] private RandomTrainingFruit _randomTrainingFruit;
    [SerializeField] private TimeController _timeController;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private SceneManagement _sceneManager;

    public FruitsSpawner FruitsSpawner { get => _fruitsSpawner; set => _fruitsSpawner = value; }
    public FruitsPool FruitsPool { get => _fruitsPool; set => _fruitsPool = value; }
    public ParticlesPool ParticlesPool { get => _particlesPool; set => _particlesPool = value; }
    public RandomTrainingFruit RandomTrainingFruit { get => _randomTrainingFruit; set => _randomTrainingFruit = value; }
    public TimeController TimeController { get => _timeController; set => _timeController = value; }
    public GameManager GameManager { get => _gameManager; set => _gameManager = value; }
    public SceneManagement SceneManager { get => _sceneManager; set => _sceneManager = value; }

    private void Awake()
    {
        Instance = this;
    }
}