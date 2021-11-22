using UnityEngine;
public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;

    [SerializeField, Range(10,100)]
    int resolution = 10;

    Transform[] points;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        points = new Transform[resolution];
        for (int i = 0; i < points.Length; i++)
        {
            float step = 2f / resolution;
            var position = Vector3.zero;
            var scale = Vector3.one * step;
            Transform point = points[i] = Instantiate(pointPrefab);
            point.localPosition = Vector3.right * i;
            position.x = (i + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;

            point.SetParent(transform,false);
        }
    }
    private void Update()
    {
        float time = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI *(position.x + time));
            point.localPosition = position;
        }
    }


}
