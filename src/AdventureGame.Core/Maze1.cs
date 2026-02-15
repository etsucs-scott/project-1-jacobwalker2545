using System;

namespace AdventureGame.Core;

public class Maze
{
    private char[,] _grid;
    public int Width { get; }
    public int Height { get; }

    public int PlayerX { get; private set; }
    public int PlayerY { get; private set; }
//Maze dimensions, relationship shown with player
    public Maze(int width, int height)
    {
        Width = width;
        Height = height;
        _grid = new char[width, height];

        Initialize();
    }

    private void Initialize()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                _grid[x, y] = '.';
            }
        }

        PlayerX = 0;
        PlayerY = 0;
    }
//starting point of player
    public void SetTile(int x, int y, char value)
    {
        _grid[x, y] = value;
    }

    public char GetTile(int x, int y)
    {
        return _grid[x, y];
    }

    public (int, int) Move(int dx, int dy)
    {
        int newX = PlayerX + dx;
        int newY = PlayerY + dy;

        if (newX < 0 || newX >= Width || newY < 0 || newY >= Height)
            return (PlayerX, PlayerY);

        return (newX, newY);
    }
//showing the movement of the player in the maze 
    public void UpdatePlayerPosition(int x, int y)
    {
        PlayerX = x;
        PlayerY = y;
    }
//updating by each key movement
    public void Print()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (x == PlayerX && y == PlayerY)
                    Console.Write('P');
                else
                    Console.Write(_grid[x, y]);
            }
            Console.WriteLine();
        }
    }
}

