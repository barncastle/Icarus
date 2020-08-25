# Icarus

A free move tool for all pre-flight versions of WoW (≤ 2.0.0.5921). This app also allows toggling render flags. 

Requires .Net Framework 4.8.



##### Controls:

All key bindings can be changed with the default as below:

- Default controls are *W*, *A*, *S*, *D* for movement

- *Space* for ascending and X for decending

- *LShift* for a 2x speed increase and *LControl* for 2x speed decrease

- *F1* for toggling free move on/off

  

#####Notes:

- The client is likely to crash if you move beyond the loaded cells and/or above the height box limit - hence the project name. 
  - To move into new regions the character will need to be moved to load the desired cells.

- The app automatically disables the upper farclip limit which allows increasing the amount of cells loaded at anyone time.
  -  This value can be changed in-game with `/console farclip x` 
  - The max value before client crashes occur is ~1200 for pre-TBC and ~2000 thereafter
- Restarting the client after setting the farclip above 777 will result in a crash on launch so will need to be reset in `Config.wtf`. 
  - Alternatively the "Patch Executable" button can be used to create a client without this limitation.