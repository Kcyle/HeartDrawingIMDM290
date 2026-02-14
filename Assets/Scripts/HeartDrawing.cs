using UnityEngine;

public class HeartDrawing : MonoBehaviour
{
    GameObject[] balls;
    int total = 100;
    Vector3[] startSpots;
    Vector3[] heartSpots;
    float progress = 0f;

    void Start()
    {
        balls = new GameObject[total];
        startSpots = new Vector3[total];
        heartSpots = new Vector3[total];

        int idx = 0;
        while (idx < total)
        {
            MakeBall(idx);
            idx++;
        }
    }

    void MakeBall(int idx)
    {
        float angle = (float)idx / total * 2f * Mathf.PI;
        float radius = (float)idx / total * 15f;
        float sx = Mathf.Cos(angle * 3f) * radius;
        float sy = Mathf.Sin(angle * 3f) * radius;
        startSpots[idx] = new Vector3(sx, sy, 0f);

        heartSpots[idx] = GetHeartPoint(angle);

        balls[idx] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        balls[idx].transform.parent = this.transform;
        balls[idx].transform.localPosition = startSpots[idx];

        Renderer rend = balls[idx].GetComponent<Renderer>();
        float h = (float)idx / total;
        Color col = Color.HSVToRGB(h, 1f, 1f);
        rend.material.color = col;
    }

    Vector3 GetHeartPoint(float angle)
    {
        float xPos = 16f * Mathf.Sin(angle) * Mathf.Sin(angle) * Mathf.Sin(angle);
        float yPos = 13f * Mathf.Cos(angle) - 5f * Mathf.Cos(2f * angle) - 2f * Mathf.Cos(3f * angle) - Mathf.Cos(4f * angle);
        return new Vector3(xPos, yPos, 0f);
    }

    void Update()
    {
        if (progress < 1f)
            progress += 0.2f * Time.deltaTime;

        int idx = 0;
        while (idx < total)
        {
    
            balls[idx].transform.localPosition = Vector3.Lerp(startSpots[idx], heartSpots[idx], progress);

            Renderer rend = balls[idx].GetComponent<Renderer>();
            float h = Mathf.Sin((float)idx / total * Mathf.PI + Time.time) * 0.5f + 0.5f;
            Color col = Color.HSVToRGB(h, 1f, 1f);
            rend.material.color = col;

            idx++;
        }
    }
}