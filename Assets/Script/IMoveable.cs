using UnityEngine;

/// <summary>
/// Interface for moveable objects, providing methods for movement and jumping.
/// </summary>
public interface IMoveable
{
    /// <summary>
    /// Moves the object horizontally based on input and speed.
    /// </summary>
    /// <param name="horizontalInput">The horizontal input value.</param>
    /// <param name="speed">The movement speed.</param>
    void Move(float horizontalInput, float speed);

    /// <summary>
    /// Makes the object jump with a specified height.
    /// </summary>
    /// <param name="jumpHeight">The height of the jump.</param>
    void Jump(float jumpHeight);
}
