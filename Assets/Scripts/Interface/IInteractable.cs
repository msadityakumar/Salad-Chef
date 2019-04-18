
public interface IInteractable<T>
{
    bool IsInteracting();
    bool CanStartInteraction();
    void Interact(T InteractionType);
    void ReadyForInteraction();

    void ExitInteractable();
    void CompleteInteraction();
}
