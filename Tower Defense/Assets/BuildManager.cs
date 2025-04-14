using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    public Material validMaterial;
    public Material invalidMaterial;
    public LayerMask placementLayer;
    public LayerMask overlapCheckLayer;

    private GameObject _towerToBuild;
    private GameObject _previewInstance;
    private bool _isPlacing = false;

    void Awake()
    {
        Instance = this;
    }

    public void StartPlacingTower(GameObject prefab)
    {
        _towerToBuild = prefab;
        if (_previewInstance != null) Destroy(_previewInstance);

        _previewInstance = Instantiate(_towerToBuild);
        SetPreviewMode(_previewInstance);
        _isPlacing = true;
    }

    void Update()
    {
        if (!_isPlacing || _previewInstance == null) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, placementLayer))
        {
            Vector3 placementPosition = hit.point;
            _previewInstance.transform.position = placementPosition;

            bool canPlace = CanPlaceHere(placementPosition);
            UpdatePreviewMaterial(canPlace ? validMaterial : invalidMaterial);

            if (Input.GetMouseButtonDown(0) && canPlace)
            {
                Instantiate(_towerToBuild, placementPosition, Quaternion.identity);
                CancelPlacement();
            }

            if (Input.GetMouseButtonDown(1))
            {
                CancelPlacement();
            }
        }

    }

    private void SetPreviewMode(GameObject obj)
    {
        foreach (Renderer r in obj.GetComponentsInChildren<Renderer>())
        {
            r.material = validMaterial;
        }

        // Optionnel : désactiver scripts, collisions, etc.
        obj.tag = "Preview";
    }

    private void UpdatePreviewMaterial(Material mat)
    {
        foreach (Renderer r in _previewInstance.GetComponentsInChildren<Renderer>())
        {
            r.material = mat;
        }
    }

    private bool CanPlaceHere(Vector3 position)
    {
        Collider[] overlaps = Physics.OverlapSphere(position, 0.5f, overlapCheckLayer);
        return overlaps.Length == 0;
    }

    private void CancelPlacement()
    {
        if (_previewInstance != null) Destroy(_previewInstance);
        _isPlacing = false;
        _towerToBuild = null;
    }
}
