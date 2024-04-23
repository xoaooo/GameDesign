using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    private Tilemap tilemap;

    Dictionary<ushort, List<Tile>> tileset;
    public List<Tile> grass;
    public List<Tile> soil;
    public List<Tile> contourA;
    public List<Tile> contourB;
    public List<Tile> contourC;
    public List<Tile> contourD;
    public List<Tile> contourE;
    public List<Tile> contourF;
    public List<Tile> contourG;
    public List<Tile> contourH;
    public List<Tile> contourI;
    public List<Tile> contourJ;
    public List<Tile> contourK;
    public List<Tile> contourL;

    private const ushort id_grass = 0b11111111;
    private const ushort id_soil = 0b00000000;
    private const ushort id_contourA = 0b00001011;
    private const ushort id_contourB = 0b00011111;
    private const ushort id_contourC = 0b00010110;
    private const ushort id_contourD = 0b01101011;
    private const ushort id_contourE = 0b11010110;
    private const ushort id_contourF = 0b01101000;
    private const ushort id_contourG = 0b11111000;
    private const ushort id_contourH = 0b11010000;
    private const ushort id_contourI = 0b01111111;
    private const ushort id_contourJ = 0b11011111;
    private const ushort id_contourK = 0b11111110;
    private const ushort id_contourL = 0b11111011;

    public int map_width;
    public int map_height;

    List<List<ushort>> noise_grid = new List<List<ushort>>();

    //manter entre 4 e 20
    public float magnification = 7.0f;
    public int x_offset = 0;
    public int y_offset = 0;

    void Start()
    {
        CreateTileset();
        CreateTilemap();
        GenerateMap();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //CreateTilemap();
            GenerateMapTerrainContours();
        }
        
    }

    void CreateTileset()
    {
        tileset = new Dictionary<ushort, List<Tile>>();
        tileset.Add(id_grass, grass);
        tileset.Add(id_soil, soil);
        tileset.Add(id_contourA, contourA);
        tileset.Add(id_contourB, contourB);
        tileset.Add(id_contourC, contourC);
        tileset.Add(id_contourD, contourD);
        tileset.Add(id_contourE, contourE);
        tileset.Add(id_contourF, contourF);
        tileset.Add(id_contourG, contourG);
        tileset.Add(id_contourH, contourH);
        tileset.Add(id_contourI, contourI);
        tileset.Add(id_contourJ, contourJ);
        tileset.Add(id_contourK, contourK);
        tileset.Add(id_contourL, contourL);
    }

    void CreateTilemap()
    {
        (x_offset, y_offset) = (UnityEngine.Random.Range(1, 10000), UnityEngine.Random.Range(1, 10000));
        tilemap = new GameObject("MAP").AddComponent<Tilemap>();
        tilemap.AddComponent<TilemapRenderer>();
        tilemap.transform.SetParent(gameObject.transform);
        tilemap.transform.localPosition = new Vector3(0, 0, 0);
    }

    void GenerateMap()
    {
        GenerateMapTerrain();
        GenerateMapTerrainContours();
    }

    void GenerateMapTerrain()
    {
        for (int x = 0; x < map_width; x++)
        {
            noise_grid.Add(new List<ushort>());

            for (int y = 0; y < map_height; y++)
            {
                ushort tile_id = GetTerrainId(x, y);
                noise_grid[x].Add(tile_id);

                //InsertTile(tile_id, x, y);
            }
        }
    }

    void GenerateMapTerrainContours()
    {
        for (int x = 1; x < map_width - 1; x++)
        {
            for (int y = 1; y < map_height - 1; y++)
            {
                bool tile1 = noise_grid[x - 1][y + 1] == id_grass;
                bool tile2 = noise_grid[x][y + 1] == id_grass;
                bool tile3 = noise_grid[x + 1][y + 1] == id_grass;
                bool tile4 = noise_grid[x - 1][y] == id_grass;
                bool tile5 = noise_grid[x + 1][y] == id_grass;
                bool tile6 = noise_grid[x - 1][y - 1] == id_grass;
                bool tile7 = noise_grid[x][y - 1] == id_grass;
                bool tile8 = noise_grid[x + 1][y - 1] == id_grass;

                ushort tileId = noise_grid[x][y];
                Debug.Log("x=" + x + " y=" + y +" t="+ noise_grid[x][y]);
                Debug.Log(string.Format("" + tile1 + "|" + tile2 + "|" + tile3 + "\n" + tile4 + "|tile|" + tile5 + "\n" + tile6 + "|" + tile7 + "|" + tile8 + "\n"));
                if (tile1 == false && tile2 == true && tile3 == true && tile4 == true && tile5 == true && tile6 == true && tile7 == true && tile8 == true)
                {
                    Debug.Log("I");
                    tileId = id_contourI;
                }
                else if (tile1 == true && tile2 == true && tile3 == false && tile4 == true && tile5 == true && tile6 == true && tile7 == true && tile8 == true)
                {
                    Debug.Log("J");
                    tileId = id_contourJ;
                }
                else if (tile1 == true && tile2 == true && tile3 == true && tile4 == true && tile5 == true && tile6 == true && tile7 == true && tile8 == false)
                {
                    Debug.Log("K");
                    tileId = id_contourK;
                }
                else if (tile1 == true && tile2 == true && tile3 == true && tile4 == true && tile5 == true && tile6 == false && tile7 == true && tile8 == true)
                {
                    Debug.Log("L");
                    tileId = id_contourL;
                }
                else if (tile2 == false && tile4 == true && tile5 == true && tile6 == true && tile7 == true && tile8 == true && tileId == id_grass)
                {
                    Debug.Log("B");
                    tileId = id_contourB;
                }
                else if (tile2 == true && tile3 == true && tile4 == false && tile5 == true && tile7 == true && tile8 == true && tileId == id_grass)
                {
                    Debug.Log("D");
                    tileId = id_contourD;
                }
                else if (tile1 == true && tile2 == true && tile4 == true && tile5 == false && tile6 == true && tile7 == true && tileId == id_grass)
                {
                    Debug.Log("E");
                    tileId = id_contourE;
                }
                else if (tile1 == true && tile2 == true && tile3 == true && tile4 == true && tile5 == true && tile7 == false && tileId == id_grass)
                {
                    Debug.Log("G");
                    tileId = id_contourG;
                }
                else if (tile1 == false && tile2 == false && tile4 == false && tile5 == true && tile7 == true && tile8 == true && tileId == id_grass)
                {
                    Debug.Log("A");
                    tileId = id_contourA;
                }
                else if (tile2 == false && tile3 == false && tile4 == true && tile5 == false && tile6 == true && tile7 == true && tileId == id_grass)
                {
                    Debug.Log("C");
                    tileId = id_contourC;
                }
                else if (tile2 == true && tile3 == true && tile4 == false && tile5 == true && tile6 == false && tile7 == false && tileId == id_grass)
                {
                    Debug.Log("F");
                    tileId = id_contourF;
                }
                else if (tile1 == true && tile2 == true && tile4 == true && tile5 == false && tile7 == false && tile8 == false && tileId == id_grass)
                {
                    Debug.Log("H");
                    tileId = id_contourH;
                }
                InsertTile(tileId, x, y);
            }
        }
    }

    private ushort GetTerrainId(int x, int y)
    {
        float perlin_noise = Mathf.PerlinNoise(
            (x - x_offset) / magnification,
            (y - y_offset) / magnification
        );
        float normalized_noise = Mathf.Clamp01(perlin_noise);
        return Mathf.RoundToInt(normalized_noise) == 1 ? id_grass : id_soil;
    }
    
    void InsertTile(ushort tile_id, int x, int y)
    {
        List<Tile> terrain = tileset[tile_id];
        Tile tile = terrain[UnityEngine.Random.Range(0, terrain.Count)];
        Vector3Int cell = new Vector3Int(x, y, 0);

        tilemap.SetTile(cell, tile);
    }
}
