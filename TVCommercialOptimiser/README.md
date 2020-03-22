# TV Commercial Optimiser
This is a Console application implemented using c#, .Net core 

## Structure
- Program.cs file to kick start the application
- Commercials.cs file which has Break Creation metod calls and Commercial placement logic
- Brek.cs file has Break creation and validation
- enum.cs has the Enums

## Requirements
- Visual Studio
- .Net Core 3.1
- C#

### Clone this project

```
git clone https://github.com/jiteshkaranjkar/TVCommercialOptimiser.git
```
### Setup
If git is not installed automatically on your mac, follow these instructions:

1. Download Mac installer: https://git-scm.com/download/mac
2. Double click the installer to start the installation.
3. Use Visual Studio possibly latest version
4. Open the cloned project

### Building
- Open Visual Studio -> Build -> Build All

### Execution
- Open Visual Studio -> Run -> Start Without Debugging

## Current Implementation
#### The current implementation of the Tv Commercial Optimiser is as following:
        • Place 3 commercials in each of the breaks with no violations of the restrictions above.
        • Calculate the sum of the ratings achieved by all placed commercials, based on the demographic/rating
        of the break it is in.
        • Find the optimal placement that maximises the total ratings.
        • Print the final placement structure along with the sum of the ratings achieved.
#### Additional Questions (Bonus Points):
        • Uneven break structure i.e. one break takes 2, one takes 3 and one takes 4 commercials
        • You have an additional commercial (10 in total) so you must place 9 and leave 1 unplaced:

### Output
-- Welcome to TV Commercial Optimiser! -- 

 Press Enter key to Place commercials in the breaks

In Break1 Total ratings of the three commercials before optimisation is 430
In Break2 Total ratings of the three commercials before optimisation is 370
In Break3 Total ratings of the three commercials before optimisation is 1000

 Press Enter key to start Optimisation

 The optimal rating achieved is
 This is Break1 with Commercial7 of type Finance with Demographic Men1835 and rating 350 and Optimised rating 100
 This is Break1 with Commercial8 of type Automotive with Demographic Total1840 and rating 150 and Optimised rating 250
 This is Break1 with Commercial9 of type Travel with Demographic Women2530 and rating 500 and Optimised rating 80
 In Break1 Maximum Total ratings of the three commercials is 1000


 This is Break2 with Commercial4 of type Automotive with Demographic Men1835 and rating 50 and Optimised rating 120
 This is Break2 with Commercial2 of type Travel with Demographic Men1835 and rating 100 and Optimised rating 120
 This is Break2 with Commercial5 of type Automotive with Demographic Men1835 and rating 120 and Optimised rating 120
 In Break2 Maximum Total ratings of the three commercials is 270


 This is Break3 with Commercial1 of type Automotive with Demographic Women2530 and rating 80 and Optimised rating 350
 This is Break3 with Commercial3 of type Travel with Demographic Total1840 and rating 250 and Optimised rating 500
 This is Break3 with Commercial6 of type Finance with Demographic Women2530 and rating 200 and Optimised rating 350
 In Break3 Maximum Total ratings of the three commercials is 530


 So Total ratings is 1800
 So Total Optimised Ratings is 1990

 Press Enter key to Add Additonal Bonus Points with Commercial 10

 The optimal rating achieved is
 This is Break1 with Commercial10 of type Finance with Demographic Total1840 and rating 500 and Optimised rating 250
 This is Break1 with Commercial1 of type Automotive with Demographic Women2530 and rating 80 and Optimised rating 80
 In Break1 Maximum Total ratings of the three commercials is 580


 This is Break2 with Commercial5 of type Automotive with Demographic Men1835 and rating 120 and Optimised rating 120
 This is Break2 with Commercial2 of type Travel with Demographic Men1835 and rating 100 and Optimised rating 120
 This is Break2 with Commercial8 of type Automotive with Demographic Total1840 and rating 150 and Optimised rating 200
 In Break2 Maximum Total ratings of the three commercials is 370


 This is Break3 with Commercial6 of type Finance with Demographic Women2530 and rating 200 and Optimised rating 350
 This is Break3 with Commercial3 of type Travel with Demographic Total1840 and rating 250 and Optimised rating 500
 This is Break3 with Commercial7 of type Finance with Demographic Men1835 and rating 350 and Optimised rating 150
 This is Break3 with Commercial9 of type Travel with Demographic Women2530 and rating 500 and Optimised rating 350
 In Break3 Maximum Total ratings of the three commercials is 1300


 So Total ratings is 2250
 So Total Optimised Ratings is 2120

