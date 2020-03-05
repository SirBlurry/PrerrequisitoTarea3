using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int depth = 20;

    public int widht = 256;
    public int height = 256;

    public float scale = 20f;

    public float offSetX = 100f;
    public float offSetY = 100f;

    private void Start()
    {
        offSetX = Random.Range(0f, 9999f);
        offSetY = Random.Range(0f, 9999f);
    }

    private void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);

        offSetX += Time.deltaTime * 5f;
    }

    private TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = widht + 1;

        terrainData.size = new Vector3(widht, depth, height);

        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    private float[,]GenerateHeights()
    {
        float[,] heights = new float[widht, height];
        for (int x = 0; x < widht; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }

        return heights;
    }

    private float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / widht * scale + offSetX;
        float yCoord = (float)y / height * scale + offSetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
