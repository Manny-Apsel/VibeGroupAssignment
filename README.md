# Vibe Group Assignment

## Assignment

There's a file in the root of the repository, input.txt, that contains words of varying lengths (1 to 6 characters).

Your objective is to show all combinations of those words that together form a word of 6 characters. That combination must also be present in input.txt
E.g.:  
<code>
foobar  
fo  
obar  
</code>

should result in the ouput:  
<code>
fo+obar=foobar
</code>

You can start by only supporting combinations of two words and improve the algorithm at the end of the exercise to support any combinations.

Treat this exercise as if you were writing production code; think unit tests, SOLID, clean code and avoid primitive obsession. Be mindful of changing requirements like a different maximum combination length, or a different source of the input data.

The solution must be stored in a git repo. After the repo is cloned, the application should be able to run with one command / script.

Don't spend too much time on this.

## Solution

The obvious first solution one is to combine all the possible word combinations that turn out to have a length of 6 words and see if that combination exist. To improve performance it's possible to see if 2 strings combined (with a length lower than 6; you'd need at least another string to get to a length of 6) would have a match with the start of an 6 letter word. If not there would be no need to continue further checking en building up new strings from that combination.

A second way to solve this would be to subdivide all words with length 6 into all possible subdivisions and see if any of them match with the a word in the input.

The first solution is written out in class SortingAlghorithm class and the second solution is written out in ImprovedSortingAlghorithm class.
