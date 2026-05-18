# ReinforcementPrivacy

A server-side Vintage Story privacy mod that anonymizes readable player and group names in block reinforcement data.

`ReinforcementPrivacy` is designed for PvP, faction, roleplay, and privacy-focused servers where reinforced or locked blocks should not reveal free intelligence about who owns them.

In vanilla, reinforced or locked blocks can expose readable owner information through reinforcement data, such as the last player name or group name associated with the reinforcement. This mod changes that behavior on the server side by anonymizing those readable names before reinforcement data is saved and synchronized to clients.

The mod keeps the functional ownership data intact:

- `PlayerUID` is preserved
- `GroupUid` is preserved
- Reinforcement strength is preserved
- Locked state is preserved
- Lock item data is preserved

Only the readable display names are replaced:

- `LastPlayername` becomes `Unknown`
- `LastGroupname` becomes `Unknown group`

This means vanilla reinforcement ownership and permissions should continue to work normally, while clients no longer receive the real visible player or group names through this reinforcement data path.

## Relationship With HideLockerAndReinforcerName

This mod was created after discussing the idea with SiiMeR and is based on the privacy goal of the original `HideLockerAndReinforcerName` mod:

https://mods.vintagestory.at/show/mod/36662

The original mod focuses on hiding owner information in the displayed block tooltip.

`ReinforcementPrivacy` takes a stricter server-side approach: it anonymizes readable player and group names in reinforcement data before that data is saved and synchronized to clients, while preserving the internal IDs required for vanilla permissions to keep working.

Both approaches can be useful depending on the server. Use the original mod if you only need tooltip-level hiding. Use this mod if you want the readable reinforcement owner names sanitized at the server data synchronization layer.

## Important Notes

- It only runs on the server
- Clients do not need to install it
- It affects the block reinforcement system only
- It does not hide player names in chat, maps, nametags, logs, land claims, or admin tools
- Existing reinforcements are anonymized when the game rewrites or synchronizes that reinforcement data

## Usage

1. Install the mod on the server.
2. Restart the server.
3. New reinforcement data will be saved and synchronized without readable owner or group names.

Recommended test after installation:

1. Reinforce or lock a block with one player.
2. Inspect it with another player.
3. Confirm the tooltip does not expose the original owner or group name.
4. Confirm the legitimate owner can still remove or manage the reinforcement.

## Compatibility

- Vintage Story `1.22.0`
- Vintage Story `1.22.1`
- Vintage Story `1.22.2`

## Credits

- Author: `spasmos`
- Contributor: `SiiMeR`
- Based on the privacy goal of `HideLockerAndReinforcerName` by SiiMeR

## Changelog 1.0.0

- First release as `ReinforcementPrivacy`
- Renamed the project and mod identity to avoid confusion with the original mod
- Added explicit credits and relationship notes for `HideLockerAndReinforcerName`
- Preserved the stricter server-side reinforcement data anonymization approach
- Keeps `PlayerUID` and `GroupUid` intact so vanilla ownership and permissions can continue working
- Replaces readable reinforcement owner names with neutral placeholders before saving and network synchronization
- Marked the mod as server-side so clients do not need to install it
