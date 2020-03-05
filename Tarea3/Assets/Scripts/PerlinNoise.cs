using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    public int widht = 256;
    public int height = 256;

    public float scale = 20f;

    public float offSetX = 100f;
    public float offSetY = 100f;

    private void Start()
    {
        offSetX = Random.Range(0f, 99999f);
        offSetY = Random.Range(0f, 99999f);
    }

    private void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
    }

    private Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(widht, height);

        for (int x = 0; x < widht; x++) 
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
        return texture;
    }

    private Color CalculateColor(int x, int y)
    {
        float xCoord = (float)x / widht * scale + offSetX;
        float yCoord = (float)y / height * scale + offSetY;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}
