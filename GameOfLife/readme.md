# Conway's Game of Life

I was looking for something to do yesterday evening 
and it's been a few, (20) years or so, in Pascal, since I've tackled Conway's [Game of Life](https://en.wikipedia.org/wiki/Conway's_Game_of_Life "Game of Life")

Most implementations are of an array of arrays iterated on two for loops and sometimes a third for state.  
I decided it would be fun to implement it using more object oriented means.  
This is a simple WPF C# application that randomly generates a few of the many types 
of example patterns such as Beehive, Lightweight Spaceship, Diehard, and more.

Currently, there is only a single button that runs the generations in an async thread.  
So far I only have a few hours into this.  It was more or less just an excercise to complete
it in C# for fun.

## Concept

Given that an array of arrays can be the same thing as a table I decided to treat everything
as a "Cell".  Each Cell can have eight neighbors on the compass rose.  These are also represented by the
by references to other Cells.

The Cell can have two states,
IsAlive and NextIsAlive to represent the current and future states of the Cell as being calculated, and
likewise, swapped for the next generation.  

Extension methods have been added to help with fluently applying state to each Cell.

Given that all cells reference eachother after the matrix has been built, the Cells can therefore
be iterated in a single list.  This eases the means of iterating over all Cells and also allows for
ease of iterating all of the points for display later on.

Each cell is also represented by an *X* and *Y* coordinate. Scaling is performed against a currently hardcoded
value. 


## TODO ( maybe :) )
* Add a cancel button
* Add a reset button
* Add a pause button
* Add generation number
* Add delay adjustments (currently 50ms)
* Add image scaling
* Add ability to change colors, fill and size of blocks
* Add inputs for allowing choosing of randomization options
  * number of random patterns
  * pick allowed patterns
* Move patterns from individual methods into Strategy classes
  * Allows an easier plugin module
* Create a means of allowing manual input of patterns onto the neighborhood
  * Currently patterns are just a Point
  * and; a Pattern type
* Allow creating random or custom neighborhoods (creation null spaces)
* Allow creation of custom rules engines to test your own cellular automata
* Add momento's of cell states
  * go back in time and see how you got to your current state
* Add Unit Tests
