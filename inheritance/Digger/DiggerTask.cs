using System;
using Avalonia.Input;
using Digger.Architecture;

namespace Digger;

public class Terrain : ICreature
{
    public string GetImageFileName() => "Terrain.png";

    public int GetDrawingPriority() => 3;

    public CreatureCommand Act(int x, int y) => new CreatureCommand { DeltaX = 0, DeltaY = 0 };

    public bool DeadInConflict(ICreature conflictedObject) => true;
}

public class Player : ICreature
{
    public string GetImageFileName() => "Digger.png";

    public int GetDrawingPriority() => 1;
    public CreatureCommand Act(int x, int y)
    {
        var movement = GetMovementDelta(Game.KeyPressed);
        int newX = x + movement.X, newY = y + movement.Y;

        if (IsValidMove(newX, newY))
            return new CreatureCommand { DeltaX = movement.X, DeltaY = movement.Y };

        return new CreatureCommand { DeltaX = 0, DeltaY = 0 };
    }

    private static (int X, int Y) GetMovementDelta(Key key)
    {
        return key switch
        {
            Key.Up => (0, -1),
            Key.Down => (0, 1),
            Key.Left => (-1, 0),
            Key.Right => (1, 0),
            _ => (0, 0)
        };
    }

    private bool IsValidMove(int x, int y)
    {
        if (!IsWithinBounds(x, y))
            return false;

        var target = Game.Map[x, y];
        return target is null or Terrain or Gold;
    }

    private bool IsWithinBounds(int x, int y) =>
        x >= 0 && x < Game.MapWidth && y >= 0 && y < Game.MapHeight;
    
    public bool DeadInConflict(ICreature conflictedObject)
    {
        return conflictedObject is Sack { IsFalling: true } or Monster;    
    }
}

public class Sack : ICreature
{
    public bool IsFalling = false;
    private int fallDistance = 0;

    public string GetImageFileName() => "Sack.png";

    public int GetDrawingPriority() => 0;
    
    public CreatureCommand Act(int x, int y)
    {
        if (IsFalling)
        {
            return ContinueFalling(x, y);
        }

        return CanStartFalling(x, y) ? StartFalling() : new CreatureCommand { DeltaX = 0, DeltaY = 0 };
    }

    private CreatureCommand StartFalling()
    {
        IsFalling = true;
        fallDistance = 1;
        return new CreatureCommand { DeltaX = 0, DeltaY = 1 };
    }

    private CreatureCommand ContinueFalling(int x, int y)
    {
        if (!CanContinueFalling(x, y))
        {
            IsFalling = false;
            if (fallDistance > 1)
                return new CreatureCommand { TransformTo = new Gold() };
            fallDistance = 0;
            return new CreatureCommand { DeltaX = 0, DeltaY = 0 };
        }

        fallDistance++;
        return new CreatureCommand { DeltaX = 0, DeltaY = 1 };
    }

    private bool CanStartFalling(int x, int y) =>
        y + 1 < Game.MapHeight && Game.Map[x, y + 1] == null;

    private bool CanContinueFalling(int x, int y)
    {
        if (y + 1 >= Game.MapHeight)
        {
            return false;
        }

        var below = Game.Map[x, y + 1];
        return below is null or Player or Monster;
    }

    
    public bool DeadInConflict(ICreature conflictedObject)
    {
        return false;
    }
}


public class Gold : ICreature
{
    public string GetImageFileName() => "Gold.png";

    public int GetDrawingPriority() => 2;

    public CreatureCommand Act(int x, int y) => new CreatureCommand { DeltaX = 0, DeltaY = 0 };

    public bool DeadInConflict(ICreature conflictedObject)
    {
        switch (conflictedObject)
        {
            case Player:
                Game.Scores += 10;
                return true;
            case Monster:
                return true;
            default:
                return false;
        }
    }
}


public class Monster : ICreature
{
    public string GetImageFileName() => "Monster.png";

    public int GetDrawingPriority() => 0;

    public CreatureCommand Act(int x, int y)
    {
        var playerPosition = FindPlayerPosition();
        if (playerPosition == null)
        {
            return new CreatureCommand { DeltaX = 0, DeltaY = 0 };
        }

        var delta = GetMovementDeltaTowards(x, y, playerPosition.Value);
        int newX = x + delta.X, newY = y + delta.Y;

        if (IsValidMove(newX, newY))
        {
            return new CreatureCommand { DeltaX = delta.X, DeltaY = delta.Y };
        }

        return new CreatureCommand { DeltaX = 0, DeltaY = 0 };
    }

    private (int X, int Y)? FindPlayerPosition()
    {
        for (var i = 0; i < Game.MapWidth; i++)
            for (var j = 0; j < Game.MapHeight; j++)
                if (Game.Map[i, j] is Player)
                    return (i, j);
        return null;
    }

    private (int X, int Y) GetMovementDeltaTowards(int x, int y, (int X, int Y) target)
    {
        int deltaX = 0, deltaY = 0;

        if (x != target.X)
        {
            deltaX = x < target.X ? 1 : -1;
        }
        else if (y != target.Y)
        {
            deltaY = y < target.Y ? 1 : -1;
        }

        return (deltaX, deltaY);
    }

    private bool IsValidMove(int x, int y)
    {
        if (!IsWithinBounds(x, y))
        {
            return false;
        }

        var target = Game.Map[x, y];
        return target is null or Player or Gold;
    }

    private bool IsWithinBounds(int x, int y) =>
        x >= 0 && x < Game.MapWidth && y >= 0 && y < Game.MapHeight;

    public bool DeadInConflict(ICreature conflictedObject) =>
        conflictedObject is Monster or Sack { IsFalling: true };
}
