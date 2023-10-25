using System;

class MazeSolver
{
    static int[,] maze = {
        {0, 1, 0, 0, 0},
        {0, 1, 0, 1, 0},
        {0, 0, 0, 1, 0},
        {0, 1, 1, 1, 0},
        {0, 0, 0, 0, 0}
    };

    static int mazeSize = 5;

    static bool FindPath(int x, int y)
    {
        // Проверка, находится ли текущая позиция в пределах лабиринта и не является ли стеной
        if (x < 0 || x >= mazeSize || y < 0 || y >= mazeSize || maze[x, y] == 1)
            return false;

        // Проверка, является ли текущая позиция конечной точкой
        if (x == mazeSize/2 && y == mazeSize/2 )
        {
            Console.WriteLine($"Путь найден: ({x}, {y})");
            return true;
        }

        // Помечаем текущую клетку как посещенную
        maze[x, y] = 1;

        // Рекурсивные вызовы для всех соседних клеток
        if (FindPath(x + 1, y) || FindPath(x - 1, y) || FindPath(x, y + 1) || FindPath(x, y - 1))
        {
            Console.WriteLine($"Путь найден: ({x}, {y})");
            return true;
        }

        // Снимаем пометку с текущей клетки, так как она не находится на пути к выходу
        maze[x, y] = 0;

        return false;
    }

    public static void Main(string[] args)
    {
        if (FindPath(0, 0))
            Console.WriteLine("Путь найден!");
        else
            Console.WriteLine("Путь не найден.");
    }
}
