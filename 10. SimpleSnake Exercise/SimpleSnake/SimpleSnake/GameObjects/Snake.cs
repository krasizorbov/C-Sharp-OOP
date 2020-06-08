using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        Queue<Point> snakeElements;
        Wall wall;
        Food[] food;
        int foodIndex;
        public Snake(Wall wall)
        {
            this.wall = wall;
            snakeElements = new Queue<Point>();
            food = new Food[3];
            foodIndex = RandomFoodNumber;
            GetFood();
            CreateSnake();
        }
        private void CreateSnake()
        {
            for (int topY = 1; topY < 6; topY++)
            {
                snakeElements.Enqueue(new Point(2, topY));
            }
        }
        private void GetFood()
        {
            food[0] = new FoodHash(wall);
            food[1] = new FoodDollar(wall);
            food[2] = new FoodAsterisk(wall);
        }
        private void GetNextPoint(Point direction, Point snakeHead)
        {
            var nextLeftX = snakeHead.LeftX + direction.LeftX;
            var nextTopY = snakeHead.TopY + direction.TopY;
        }
        public bool IsPointOfWall(Point snake)
        {
            return snake.TopY == 0 || snake.LeftX == 0 ||
                snake.LeftX == LeftX - 1 || snake.TopY == TopY;
        }
        public bool IsMooving(Point direction)
        {
            Point currentSnakeHead = snakeElements.Last();
            GetNextPoint(direction, currentSnakeHead);
            bool isPointOfSnake = snakeElements.Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);
            if (isPointOfSnake)
            {
                return false;
            }
            Point snakeNewHead = new Point(nextLeftX, nextTopY);
            if (Wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }
            return true;
        }
        private const char snakeSymbol = '\u25CF';
        snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);
        
        if (food[foodIndex].IsFoodPoint(snakeNewHead))
	    {
            Eat(direction, currentSnakeHead);
	    }
        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = food[foodIndex].FoodPoints;
            for (int i = 0; i < length; i++)
            {
                snakeElements.Enqueue(new Point(nextLeftX, nextTopY));
                GetNextPoint(direction, currentSnakeHead);
            }
            foodIndex = RandomFoodNumber;
            food[foodIndex].SetRandomPosition(snakeElements);
        }
    }
}
