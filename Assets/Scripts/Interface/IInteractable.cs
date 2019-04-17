
public interface IInteractable<T>
{
    bool IsInteracting();
    bool CanStartInteraction();
    void InteractionComplete();
    void Interact(T objectToInteract);
    void ReadyForInteraction();

    void ExitInteractable();
}
