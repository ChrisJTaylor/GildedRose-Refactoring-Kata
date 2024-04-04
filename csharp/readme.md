# CSharp attempt

I split this into separate projects for the App and the Tests, in order to make it easier to run the `Stryker` mutation test tool.

This is my first exploration into mutation tests. I consider myself to be a strong TDD-er, so I was keen to see what kind of results I would get. 

## Mutatation test results

### First run

![image](https://github.com/ChrisJTaylor/GildedRose-Refactoring-Kata/assets/2196813/12f0f10d-1c99-44f5-acf3-46b6a76c73ce)

This had a couple of timeouts, which the documentation suggests not to worry too much about.

While these results are good, I was expecting to see some issues due to this exercise involving retrofitting some tests. There is always a chance to miss something.

Nevertheless, I ran it again and grabbed a fresh coffee.

### Second run

![image](https://github.com/ChrisJTaylor/GildedRose-Refactoring-Kata/assets/2196813/f6c0e7ce-f020-4e4c-8d1b-b8c8adc7d631)

This is "better", as it now shows a couple of mutants survived.

The issue found is that I'm redundantly checking the equality of a value, as well as the variance.

![image](https://github.com/ChrisJTaylor/GildedRose-Refactoring-Kata/assets/2196813/938a666b-0050-40fe-bf54-88ad72b52f85)

I removed the equality check on both methods, and re-ran the mutation tests, and it's back to 100% again.

Just to check, I ran the mutation tests several more times, and still got 100%, so it looks stable now.

![image](https://github.com/ChrisJTaylor/GildedRose-Refactoring-Kata/assets/2196813/4de87cfb-e773-46ff-ad17-ccdcc60ac438)

### A little while later...

I ran the mutation tests again, and got one failure. 

![image](https://github.com/ChrisJTaylor/GildedRose-Refactoring-Kata/assets/2196813/8b7874cf-ff95-4a58-8909-51654b8d7a92)

This was effectively the same as the first issues, but now saying that equality doesn't break the code. 
I don't love this feedback, as it doesn't really change the logic. However, I can circumvent it by clamping the values instead. 
Obviously, underneath the hood this is effectively doing the same thing, but it's the .Net SDK's problem, and beyond the reach of the mutants.

## Notes

I liked the feedback that I got from the mutation tests. I like the confidence that I gained from the high positives, 
and that confidence is validated by the two failures it found. I can see how this could be added to a pipeline to help
identify issues that a human reader may miss in a review / pairing session.

I imagine mutation tests are more valuable the higher your code coverage is. Assuming your coverage is high, 
if the mutation tests show an issue, does that illustrate that TDD was not likely employed? 
Specifically, that a decision was made in the code which wasn't validated by a test?

I'll try this out on other code bases and see what comes out of it.
