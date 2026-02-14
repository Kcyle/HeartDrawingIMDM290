using UnityEngine;

public class HeartDrawing : MonoBehaviour
{
    GameObject[] balls;
    int total = 100;

    void Start()
    {
        balls = new GameObject[total];
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
        Vector3 spot = GetHeartPoint(angle);

        balls[idx] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        balls[idx].transform.position = spot;

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
        int idx = 0;
        while (idx < total)
        {
            Renderer rend = balls[idx].GetComponent<Renderer>();
            float h = Mathf.Sin((float)idx / total * Mathf.PI + Time.time) * 0.5f + 0.5f;
            Color col = Color.HSVToRGB(h, 1f, 1f);
            rend.material.color = col;
            idx++;
        }
    }
}