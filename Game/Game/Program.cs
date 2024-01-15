using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;

class Board
{
    public int Width { get; }
    public int Height { get; }

    public Board(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public void Draw(int snakeX, int snakeY, List<(int, int)> snakeBody, int fruitX, int fruitY)
    {
        Console.Clear(); //it works be re-dreawing whole terminal all over again hence the need for clear function
        for (int y = 0; y < Height; y++) //looping through the whole board, there are probably better, faster and more efficient ways to do it but I dont have time :((
        {
            for (int x = 0; x < Width; x++)
            {
                if (x == 0 || y == 0 || x == Width - 1 || y == Height - 1) //🦅🇺🇸 the wall
                {
                    Console.Write("#");
                }
                else if (x == snakeX && y == snakeY) //drawing head of the snake
                {
                    Console.Write("O");
                }
                else if (x == fruitX && y == fruitY) //drawing da fruit
                {
                    Console.Write("*");
                }
                else if (snakeBody.Contains((x, y))) // drawing body of the snake
                {
                    Console.Write("o");
                }
                else //51% matter, 49% anti-matter, 42
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
            //Console.WriteLine($"snakeX: {snakeX}, snakeY: {snakeY}, snakeBody: {snakeBody}");
        }
    }
}

class Snake
{
    public int X { get; set; } //prepearing vars
    public int Y { get; set; }
    public List<(int, int)> Body { get; }

    public Snake(int startX, int startY)
    {
        X = startX;
        Y = startY;
        Body = new List<(int, int)>() { (X, Y) };
    }

    public void Move(ConsoleKey direction)
    {
        switch (direction)
        {
            case ConsoleKey.UpArrow:
                Y--;
                break;
            case ConsoleKey.DownArrow:
                Y++;
                break;
            case ConsoleKey.LeftArrow:
                X--;
                break;
            case ConsoleKey.RightArrow:
                X++;
                break;
        }

        Body.Insert(0, (X, Y));  //movement logic --> head moves with controls and body gets removed from the back 
        Body.RemoveAt(Body.Count - 1);
    }

    public void Grow()
    {
        Body.Add((-1, -1));
    }
}

class Fruit
{
    public int X
    {
        get; private set;
    }
    public int Y
    {
        get; private set;
    }
    public Fruit(int boardWidth, int boardHeight)
    {
        Respawn(boardWidth, boardHeight);
    }

    public void Respawn(int boardWidth, int boardHeight) //calc new fruit
    {
        Random random = new Random();
        X = random.Next(1, boardWidth - 1);
        Y = random.Next(1, boardHeight - 1);
    }
}

class Game //tie it all together
{
    private Board board;
    private Snake snake;
    private Fruit fruit;
    private int score;
    private ConsoleKey direction;

    public Game(int boardWidth, int boardHeight)
    {
        board = new Board(boardWidth, boardHeight);
        snake = new Snake(boardWidth / 2, boardHeight / 2);
        fruit = new Fruit(boardWidth, boardHeight);
        score = 0;
        direction = ConsoleKey.RightArrow;  //starting direction
    }

    public void Run()
    {
        while (true)
        {
            if (Console.KeyAvailable) //input handeling
            {
                var key = Console.ReadKey(true).Key;
                if ((key == ConsoleKey.UpArrow && direction != ConsoleKey.DownArrow) ||
                    (key == ConsoleKey.DownArrow && direction != ConsoleKey.UpArrow) ||
                    (key == ConsoleKey.LeftArrow && direction != ConsoleKey.RightArrow) ||
                    (key == ConsoleKey.RightArrow && direction != ConsoleKey.LeftArrow))
                {
                    direction = key;
                }
            }

            snake.Move(direction);

            if (snake.X == fruit.X && snake.Y == fruit.Y)
            {
                score++;
                fruit.Respawn(board.Width, board.Height);
                snake.Grow();
            }

            board.Draw(snake.X, snake.Y, snake.Body, fruit.X, fruit.Y);
            Console.WriteLine("Score: " + score);

            if (IsGameOver())
            {
                Console.Clear();
                Console.WriteLine("Game Over");
                Console.WriteLine("Score: " + score);
                Process.Start(new ProcessStartInfo("https://i.kym-cdn.com/photos/images/original/000/041/494/1241026091_youve_been_rickrolled.gif") { UseShellExecute = true }); //special sauce


                break;
            }

            Thread.Sleep(200); // amount of sedatives snake receives
        }
    }

    private bool IsGameOver()
    {
        return snake.X <= 0 || snake.Y <= 0 || snake.X >= board.Width - 1 || snake.Y >= board.Height - 1 || snake.Body.GetRange(1, snake.Body.Count - 1).Contains((snake.X, snake.Y)); //wannabe collision detection

    }

}

class Program
{
    static void Main()
    {
        Game game = new Game(30, 20);
        game.Run();
    }
}

// shout out to https://www.gamedev.net/blogs/entry/2266700-c-console-snake-game/ && ChatGPT for helping with some really annoying bugs