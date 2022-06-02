using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLaberer : MonoBehaviour
{
    [SerializeField] private Color _defaultColor = Color.white;
    [SerializeField] private Color _blockedColor = Color.gray;

    private TextMeshPro _label;
    private Waypoint _waypoint;

    private void Awake()
    {
        _label = GetComponent<TextMeshPro>();
        _waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }

    private void Update()
    {
        if (!Application.isPlaying)
            DisplayCoordinates();

        ColorCoordinates();
        ToogleLabels();
    }

    private void DisplayCoordinates()
    {
        Vector2Int coordinates = new(
            Mathf.RoundToInt(this.transform.parent.position.x),
            Mathf.RoundToInt(this.transform.parent.position.z)); 

        _label.text = $"({coordinates.x};{coordinates.y})";

        UpdateObjectName(coordinates);
    }

    private void UpdateObjectName(Vector2Int coordinates) => this.transform.parent.name = coordinates.ToString();

    private void ColorCoordinates()
    {
        if (_waypoint.IsPlaceable) _label.color = _defaultColor;
        else _label.color = _blockedColor;
    }

    private void ToogleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
            foreach (var text in FindObjectsOfType<TextMeshPro>())
                text.enabled = !text.enabled;
    }
}
