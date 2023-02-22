# 6 Hour Challenge

Improve the *White Blood Cell* mobile game in 6 hours.

## Time Log

| Event                         | Date      | Time          |
|-------------------------------|-----------|---------------|
|Challenge start                | 2023/2/22 | 12:30PM EST   |
|Initial commit                 | 2023/2/22 | 01:00PM EST   |
|First checkpoint               | 2023/2/22 | 04:10PM EST   |
|Lunch break (time pause)       | 2023/2/22 | 04:30PM EST   |
|Lunch break end (time resume)  | 2023/2/22 | 05:10PM EST   |
|Second checkpoint              | 2023/2/22 | 05:55PM EST   |

## Plans

After briefly playtesting the game, I came up with the following changes that I'd like to make to the game:

- Changes to game mechanics:
    - [x] Make Viruses eat the Red Blood Cells instead of having them be idle.
    - [x] If a Virus consumes a Red Blood Cell, a score penalty is applied.
    - [x] Consuming Viruses extends the player's momentum.
    - Turn system overhaul:
        - [x] Change the turns system to use an analog bar instead of a fixed number of turns.
        - [x] Make the turns bar deplete on its own to disincentivize camping/farming.
    - Boost system overhaul:
        - [ ] Display boost direction and force as the player charges the boost.
        - [x] Apply drag to player movement.
        - [x] The longer a boost is charged for, the more of the turn bar is depleted.
- Fixes/improvements:
    - [x] Fix UI canvases to properly scale dynamically.
    - [ ] Add juice to players consuming Viruses/Red Blood Cells.
    
## Unplanned Extra Features

The following features were added during the 6 hour window which weren't originally planned, but either came up organically during the development process or were deemed necessary while playtesting:

- Replace UI assets.
- Font change throughout the UI (now using [Indestructible Type](https://indestructibletype.com/)'s [Gnomon](https://indestructibletype.com/Gnomon.html) font).
- Spawn enemies in bursts with delay inbetween each enemy in the burst.
- Preview the amount of energy that will be consumed in the movement bar.
- Added background graphic so that walls are visible