﻿using System.Drawing;

namespace PACMAN.GL
{
    internal class VerticalEnemy : Enemy
    {
        GameDirection direction;
        public VerticalEnemy(Image image, GameCell CurentCell, GameDirection direction) : base(GameObjectType.ENEMY, image)
        {
            this.direction = direction;
            this.CurrentCell = CurentCell;
        }
        public override GameCell Move()
        {
            GameCell currentCell = CurrentCell;
            GameCell nextCell = currentCell.NextCell(direction);
            GameObjectType type = nextCell.CurrentGameObject.GameObjectType;
            CurrentCell = nextCell;
            if (nextCell == currentCell)
            {
                if (direction == GameDirection.UP)
                    direction = GameDirection.DOWN;
                else
                    direction = GameDirection.UP;

                nextCell = currentCell.NextCell(direction);
                CurrentCell = nextCell;
            }
            if (type == GameObjectType.REWARD)
                currentCell.SetGameObject(Game.GetRewardGameObject());
            else
                currentCell.SetGameObject(Game.GetBlankGameObject());

            return nextCell;
        }
    }
}
