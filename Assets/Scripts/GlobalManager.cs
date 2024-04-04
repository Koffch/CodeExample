using Level;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    [SerializeField] private LevelContentController LevelContentController;

    private readonly DescriptionManager _descriptionManager = new();

    public void Awake()
    {
        _descriptionManager.Load();
        LevelContentController.Init(_descriptionManager.ItemsData);
    }
}