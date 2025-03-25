# [Kingdom Hearts II](../../index.md) - 00worldpoint.bin

Contains a list of save points where the player can teleport to from the world map.

The structure of this file is very simple as it is just an array of a structure we will call Area:

| Offset | Description
|--------|-------------
| 0      | [World ID](../../worlds.md)
| 1      | Area ID
| 2      | Entrance
| 3      | padding

The entrance will always have a decimal value of `99` as that is the one used to teleport onto a savepoint.

For Kingdom Hearts II: Final Mix there is a total of 54 teleport points.

Worldpoint entries are referenced by index in the Save file in the WorldPoint section, and must be toggled on to be selectable from the world map.

For example, the first worldpoint, Room 02 in Agrabah, is toggled on by enabling the first bitmask in the first byte of the WorldPoint section in the save file, 0x01. The second worldpoint, Room 06 in Agrabah would be toggled on by enabling the second bitmask in the first byte, 0x02.
