using System;
using System.Collections.Generic;
using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.EventArgs;
using TurtleChallenge.Domain.Exceptions;
using TurtleChallenge.Domain.Interfaces;
using TurtleChallenge.Domain.Orientation;

public class GameEngine
{
    private bool landedOnSomething = false;
    public event EventHandler<NotificationEventArgs> Notify;

    public IGameSettings Settings { get; private set; }

    public IEnumerable<string[]> Moves { get; private set; }

    private Compass Compass { get; set; }

    private Turtle Turtle = null;

    public GameEngine(IGameSettings settings, IEnumerable<string[]> moves)
    {
        this.Settings = settings;
        this.Moves = moves;
        this.Compass = new Compass();
    }

    public void Execute()
    {

        if (this.Settings == null)
        {
            OnNotification(NotificationEventArgs.Create("Invalid Settings"));
        }
        try
        {
            // Check if any elements start already outside the bouderies
            CheckOutOfBounderiesElements();

            foreach (var moves in this.Moves)
            {
                OnNotification(NotificationEventArgs.Create("Hacthing new turtle"));
                this.Turtle = Turtle.Hatch(this.Settings.Turtle, this.Compass.GetOrientation(this.Settings.Turtle.Orientation) ?? new North());
                
                OnNotification(NotificationEventArgs.Create($"Running sequence: {string.Join(',', moves)}"));

                RunSequence(moves);

                Reset();

                OnNotification(NotificationEventArgs.Create("_______________________________________________"));
            }

        }
        catch (OutBounderiesException e)
        {
            OnNotification(NotificationEventArgs.Create($"'{e.Message}' is outside '{this.Settings.GetType().Name}' limits"));
        }

        OnNotification(NotificationEventArgs.Create("Game completed"));
    }

    private void RunSequence(string[] sequences)
    {


        foreach (var s in sequences)
        {
            switch (s)
            {
                case "R":
                    this.Rotate(this.Turtle);
                    break;
                case "M":
                    this.Move(this.Turtle);

                    CheckBoundries(this.Turtle);

                    if (DetectCollision(this.Turtle))
                    {
                        this.landedOnSomething = true;
                        OnNotification(NotificationEventArgs.Create($"{this.Turtle.ToString()} => poor 'turtle' landed on a mine"));
                        break;
                    }
                    var _foundTheExit = FoundTheExit(this.Turtle);
                    if (_foundTheExit)
                    {
                        this.landedOnSomething = true;
                        OnNotification(NotificationEventArgs.Create($"{this.Turtle.ToString()} => exit was found"));
                        break;
                    }
                    OnNotification(NotificationEventArgs.Create(this.Turtle.ToString()));
                    break;
            }
        }

        if (!this.landedOnSomething)
        {
            OnNotification(NotificationEventArgs.Create("Out of movements, 'Turtle' was unable to find the exit, nor died!"));
        }


    }
    /// <summary>
    /// Subscribe to the notification event
    /// </summary>
    /// <param name="e"></param>
    protected void OnNotification(NotificationEventArgs e)
    {
        this.Notify?.Invoke(this, e);
    }

    /// <summary>
    /// Reset the game flags
    /// </summary>
    private void Reset()
    {
        this.landedOnSomething = false;
    }
    #region Objects Validations


    ///Checks if any entity is outbound the game limits
    private void CheckOutOfBounderiesElements()
    {

        var turtle = this.Settings.Turtle;
        var beach = this.Settings.Beach;

        CheckBoundries(turtle);

        var mines = this.Settings.Mines;
        foreach (var mine in mines)
        {
            CheckBoundries(mine);
        }


    }

    private void CheckBoundries(IObject entity)
    {
        var beach = this.Settings.Beach;

        if ((entity.Row > beach.Rows || entity.Row <= 0) || (entity.Col > beach.Cols || entity.Col <= 0))
            throw new OutBounderiesException(entity.GetType().Name);

    }
    private bool DetectCollision(IObject entity)
    {
        bool collision = false;

        foreach (var mine in this.Settings.Mines)
        {
            if (entity.Row == mine.Row && entity.Col == mine.Col)
                collision = true;
            break;
        }

        return collision;
    }

    private bool FoundTheExit(IObject entity)
    {
        return this.Settings.Exit.Col == entity.Col && this.Settings.Exit.Row == entity.Row;

    }
    #endregion

    #region Entities Movements

    private void Rotate(IRotateable entity)
    {
        var currentCardinalPoint = this.Compass.GetNextCardinalPoint(entity.Orientation);
        entity.Rotate(currentCardinalPoint);
    }

    private void Move(IMoveable entity)
    {
        entity.Move();
    }
    #endregion
}


