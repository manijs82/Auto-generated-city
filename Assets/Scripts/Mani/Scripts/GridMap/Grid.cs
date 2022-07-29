using System;
using TMPro;
using UnityEngine;

namespace Mani.Scripts.GridMap
{
    public class Grid<TGridObject>
    {
        public delegate void GridValueChangeHandler(int x, int y);
        public event GridValueChangeHandler OnGridValueChange; 
        
        private int width;
        private int height;
        private float cellSize;
        private Vector3 origin;
        private TGridObject[,] gridArray;
        private TextMeshPro[,] debugObj;
        
        public int Height => height;

        public int Width => width;

        public float CellSize => cellSize;

        public Grid(int width, int height, float cellSize, Func<Grid<TGridObject>,int,int,TGridObject> createGridObject,Vector3 origin = default, bool shouldDebug = false)
        {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;
            this.origin = origin;

            gridArray = new TGridObject[width, height];
            debugObj = new TextMeshPro[width, height];

            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    gridArray[x, y] = createGridObject(this,x,y);
                }
            }

            if(shouldDebug)
                EnableDebug();
        }

        private void EnableDebug()
        {
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    debugObj[x, y] = Utils.CreateWorldText(gridArray[x, y].ToString(), null,
                        GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) / 2, 6,
                        Color.white);
                    
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + this.cellSize / 2, y), Color.white,
                        Mathf.Infinity);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + this.cellSize / 2), Color.white,
                        Mathf.Infinity);
                }
            }

            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(height, width), Color.white, Mathf.Infinity);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(height, width), Color.white, Mathf.Infinity);
            OnGridValueChange += (x, y) => { debugObj[x, y].text = gridArray[x, y].ToString(); };
        }

        public Vector3 GetWorldPosition(float x, float y) => new Vector3(x, y) * cellSize + origin;
        
        private void GetXY(Vector3 pos, out int x, out int y)
        {
            x = Mathf.FloorToInt((pos - origin).x / cellSize);
            y = Mathf.FloorToInt((pos - origin).y / cellSize);
        }

        public void SetValue(int x, int y, TGridObject value)
        {
            if (x >= 0 && y >= 0 && x <= width && y <= height)
            {
                gridArray[x, y] = value;
                OnGridValueChange?.Invoke(x,y);
            }
        }

        public void SetValue(Vector3 worldPos, TGridObject value)
        {
            GetXY(worldPos, out var x, out var y);
            SetValue(x, y, value);
        }

        public TGridObject GetValue(int x, int y)
        {
            if (x >= 0 && y >= 0 && x <= width && y <= height)
                return gridArray[x, y];
            else
                return default(TGridObject);
        }

        public TGridObject GetValue(Vector3 worldPos)
        {
            GetXY(worldPos, out var x,out var y);
            return GetValue(x, y);
        }
    }
}