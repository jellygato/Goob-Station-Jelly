using Content.Shared.Clothing.EntitySystems;
using Content.Shared.Inventory;
using Robust.Shared.Containers;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Shared.Clothing.Components;

/// <summary>
///     This component gives an item an action that will equip or un-equip some clothing e.g. hardsuits and hardsuit helmets.
/// </summary>
[Access(typeof(ToggleableClothingSystem))]
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class ToggleableClothingComponent : Component
{
    public const string DefaultClothingContainerId = "toggleable-clothing";

    /// <summary>
    ///     Action used to toggle the clothing on or off.
    /// </summary>
    [DataField, AutoNetworkedField]
    public EntProtoId Action = "ActionToggleSuitPiece";

    [DataField, AutoNetworkedField]
    public EntityUid? ActionEntity;

    /// <summary>
    ///     Default clothing entity prototype to spawn into the clothing container.
    /// </summary>
    [DataField(required: true), AutoNetworkedField]
    public EntProtoId ClothingPrototype = default!;

    /// <summary>
    ///     The inventory slot that the clothing is equipped to.
    /// </summary>
    [ViewVariables(VVAccess.ReadWrite)]
    [DataField, AutoNetworkedField]
    public string Slot = "head";

    /// <summary>
    ///     The inventory slot flags required for this component to function.
    /// </summary>
    [DataField("requiredSlot"), AutoNetworkedField]
    public SlotFlags RequiredFlags = SlotFlags.OUTERCLOTHING;

    /// <summary>
    ///     The container that the clothing is stored in when not equipped.
    /// </summary>
    [DataField, AutoNetworkedField]
    public string ContainerId = DefaultClothingContainerId;

    [ViewVariables]
    public ContainerSlot? Container;

    /// <summary>
    ///     The Id of the piece of clothing that belongs to this component. Required for map-saving if the clothing is
    ///     currently not inside of the container.
    /// </summary>
    [DataField, AutoNetworkedField]
    public EntityUid? ClothingUid;

    /// <summary>
    ///     Time it takes for this clothing to be toggled via the stripping menu verbs. Null prevents the verb from even showing up.
    /// </summary>
    [DataField, AutoNetworkedField]
    public TimeSpan? StripDelay = TimeSpan.FromSeconds(3);

    /// <summary>
    ///     Text shown in the toggle-clothing verb. Defaults to using the name of the <see cref="ActionEntity"/> action.
    /// </summary>
    [DataField, AutoNetworkedField]
    public string? VerbText;
}
