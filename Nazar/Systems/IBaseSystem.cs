namespace Nazar.Systems;

/// <summary>
///     Interface for a base system that defines common functionality for all systems.
/// </summary>
public interface IBaseSystem
{
    /// <summary>
    ///     Gets or sets a value indicating whether the system is enabled.
    /// </summary>
    bool IsEnabled { get; set; }

    /// <summary>
    ///     Updates the system with the given state.
    /// </summary>
    /// <param name="state">The state to update the system with.</param>
    void Update(float state);

    /// <summary>
    ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    void Dispose();
}