using System;
using System.Collections.Generic;

namespace AdventureGame.Core;

public class GameEngine
{
    private Maze _maze;
    private Player _player;
//relationship between these classes 
    private Dictionary<(int, int), Monster> _monsterPositions = new();
    private Dictionary<(int, int), Item> _itemPositions = new();
//depends where the monsters spawn 
    private Random _rand = new Random();

    public GameEngine()
    {
        _player = new Player("Hero");
        _maze = new Maze(10, 10);

        PlaceWalls();
        PlaceExit();
        PlaceMonsters();
        PlaceItems();

        _maze.UpdatePlayerPosition(1, 1);
    }
//this created a 10/10 grid for the maze
    private void PlaceWalls()
    {
        int w = _maze.Width;
        int h = _maze.Height;

        for (int x = 0; x < w; x++)
        {
            _maze.SetTile(x, 0, '#');
            _maze.SetTile(x, h - 1, '#');
        }
//this placed the walls of the maze
        for (int y = 0; y < h; y++)
        {
            _maze.SetTile(0, y, '#');
            _maze.SetTile(w - 1, y, '#');
        }

        for (int i = 0; i < 15; i++)
        {
            int x = _rand.Next(1, w - 1);
            int y = _rand.Next(1, h - 1);
            if (_maze.GetTile(x, y) == '.')
                _maze.SetTile(x, y, '#');
        }
    }

    private void PlaceMonsters() //this places the monsters in the game 
    {
        for (int i = 0; i < 5; i++)
        {
            int x, y;
            do
            {
                x = _rand.Next(1, _maze.Width - 1);
                y = _rand.Next(1, _maze.Height - 1);
            } while (_maze.GetTile(x, y) != '.');

            _maze.SetTile(x, y, 'M');
            _monsterPositions[(x, y)] = new Monster($"Monster{i + 1}");
        }
    }

    private void PlaceExit() //places exit in game 
    {
	    int x, y;
	    do
	    {
		    x = _rand.Next(1,_maze.Width - 1);
		    y = _rand.Next(1, _maze.Height -1);
	    }
	    while (_maze.GetTile(x,y) != '.');
	    _maze.SetTile(x,y, 'E');}
    private void PlaceItems() //places the items you can pick up.
    {
        
        int wx, wy;
        do
        {
            wx = _rand.Next(1, _maze.Width - 1);
            wy = _rand.Next(1, _maze.Height - 1);
        } while (_maze.GetTile(wx, wy) != '.');

        var sword = new Weapon("Sword", 5);
        _maze.SetTile(wx, wy, 'W');
        _itemPositions[(wx, wy)] = sword;
// a sword that deals 5 damage 
        
        int px, py;
        do
        {
            px = _rand.Next(1, _maze.Width - 1);
            py = _rand.Next(1, _maze.Height - 1);
        } while (_maze.GetTile(px, py) != '.');

        var potion = new Potion("Potion");
        _maze.SetTile(px, py, 'P');
        _itemPositions[(px, py)] = potion;
    }
//places the potions 
    public void Run()
    {
        while (true)
        {
            Console.Clear();
            _maze.Print();
            Console.WriteLine($"Hp: {_player.Health} Attack: {_player.AttackPower}");
            Console.WriteLine("Move with the keys WASD");
//gives prompts to user
            var key = Console.ReadKey(true).Key;

            int dx = 0, dy = 0;
            switch (key)
            {
                case ConsoleKey.W: dy = -1; break;
                case ConsoleKey.S: dy = 1; break;
                case ConsoleKey.A: dx = -1; break;
                case ConsoleKey.D: dx = 1; break;
                default: continue;
            }
//sets default movement keys for players 
            MovePlayer(dx, dy);

            if (!_player.IsAlive())
            {
                Console.Clear();
                Console.WriteLine("You died, Game Over.");
                break;
            }
        }
    }

    private void MovePlayer(int dx, int dy)
    {
        var (newX, newY) = _maze.Move(dx, dy);
        char tile = _maze.GetTile(newX, newY);

        
        if (tile == '#')
        {
            Console.WriteLine("You ran into a wall");
            Console.ReadKey(true);
            return;
        }
//boundary set for walls 
        
        if (tile == 'M' && _monsterPositions.TryGetValue((newX, newY), out Monster monster))
        {
            Console.Clear();
            Console.WriteLine($"You came across {monster.Name}!");
            Battle(monster);
//notification for running into monstyers
            if (!monster.IsAlive())
            {
                Console.WriteLine($"You defeated {monster.Name}!");
                _maze.SetTile(newX, newY, '.');
                _monsterPositions.Remove((newX, newY));
            }
//given for the monsters you kill
            Console.ReadKey(true);
        }

        
        if (_itemPositions.TryGetValue((newX, newY), out Item item))
        {
            Console.WriteLine(item.PickupMessage);

            if (item is Weapon weapon)
                _player.Inventory.Add(weapon);
            else if (item is Potion potion)
                potion.Use(_player);

            _maze.SetTile(newX, newY, '.');
            _itemPositions.Remove((newX, newY));
            Console.ReadKey(true);
        }
//which if u pick up weapons or potions 
        
        if (tile == 'E')
        {
            Console.Clear();
            Console.WriteLine("You reached the exit, you win!");
            Environment.Exit(0);
        }
//winning screen
        _maze.UpdatePlayerPosition(newX, newY);
    }

    private void Battle(Monster monster)
    {
        while (_player.IsAlive() && monster.IsAlive())
        {
            monster.TakeDamage(_player.AttackPower);
            Console.WriteLine($"You hit {monster.Name} for {_player.AttackPower} damage. Monster HP is: {monster.Health}");

            if (!monster.IsAlive())
                break;

            _player.TakeDamage(monster.AttackPower);
            Console.WriteLine($"{monster.Name} hit you for {monster.AttackPower} damage. Your HP: {_player.Health}");

            Console.ReadKey(true);
        }
    }
}
//this shows the battle between the monster
