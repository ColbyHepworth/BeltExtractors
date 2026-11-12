# Belt Extractors - VFE Factory Patch

A RimWorld mod for Vanilla Furniture Expanded - Factory. Conveyor belts pull items from adjacent storage buildings,
such as shelves and chests, with no new buildings and nothing to configure.

[Steam Workshop page](https://steamcommunity.com/sharedfiles/filedetails/?id=3694555789)

## How it works

Point a conveyor belt away from a storage building, so the belt's input face touches it. The belt finds the storage
and pulls items onto itself, one stack at a time while it's empty. Its graphic and label change to show it's an
extractor belt. Only a belt facing directly away from the storage becomes an extractor: placing one beside it does
nothing.

It works with any building that uses RimWorld's standard storage. Factory hoppers are left out, since VFE Factory
already moves items between them and belts.

Safe to add to an existing save, and safe to remove: it adds no buildings and saves nothing, so belts just go back to
normal. Deconstructing an extractor belt clears everything it kept.

## Requirements

- [Harmony](https://steamcommunity.com/sharedfiles/filedetails/?id=2009463077)
- [Vanilla Expanded Framework](https://steamcommunity.com/sharedfiles/filedetails/?id=2023507013)
- [Vanilla Furniture Expanded - Factory](https://steamcommunity.com/sharedfiles/filedetails/?id=3686924415)

## License

MIT. The picture in `Workshop/` shows conveyor belt art from Vanilla Furniture Expanded - Factory, which belongs to its
authors and isn't covered by this license.
