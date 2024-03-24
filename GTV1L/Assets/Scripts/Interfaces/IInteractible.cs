
/// <summary>
/// The interface IInteractible
/// Any class that 'extends' this class _must_ implement the function Interact()
/// Therefor other scripts can rely on that class having a function called Interact()
/// </summary>
public interface IInteractible
{
    void Interact();
}
