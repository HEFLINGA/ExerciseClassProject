# Class Project Step 9;
## Auston Hefling
#### October 3rd, 2018

# Exercise Assistance Application:
## Functional: 
### User Interface;
	*UI1* The Application will have a menu to accept user information (ref: INPUT1-INPUT4)
	*UI2* The Application will have a window that displays different exercise (ref: EX1)
	*UI3* Application will have a UI that displays chosen exercise (ref: UI2), and will show amount of weight you should be doing for that given exercise, based on the users ExerciseMax (ref: EXM1) they enter for 5 repetitions of that Exercise.
	*UI4* Application will contain a window with the ability to enter a custom Exercise
	*UI5* Application will have a window that contains all the details of the exercise that is selected (ref: INPUT6)
	*UI6* Application will display plates needed for each exercise with the given repetitions and ExerciseMax applied (ref: PLATE1)
	*UI7* Application will display a StopWatch (ref: INPUT8) for keeping track of downtime between Sets
	

### User Input;
	*INPUT1* The Application will take user's name
	*INPUT4* The Application will take user's max for each exercise in Database (ref: EXM1, EXM2)
	*INPUT5* The Application will take in user's custom Exercises if they choose to do so (ref: DB5)
	*INPUT6* User will have the ability to select a certain exercise, and see the in-depth details of that exercise (ref: UI5)
	*INPUT7* User will have option to change ExerciseMax for each Exercise (ref: INPUT4), even after it is set by 1 Cycle being complete (ref: CYCLE1)
	*INPUT8* StopWatch will take input by user. Defaulting to 1 Minute
	

### DataBase;
	*DB1* Info input by user must be able to be added to CUSTOMER database table (ref: INPUT1-INPUT4)
	*DB2* Info input by user must be able to be deleted from the CUSTOMER database table
	*DB3* The database will hold exercises to be used and displayed to the User (ref: UI2)
	*DB4* Database will have a table for Plates
	*DB5* Database will hold Custom exercises and all there information (ref: EX2 - EX7)
	
	
### Exercises;
	*EX1* Application will contain default Exercises for User to access and use
	*EX2* Application will take input for custom Exercises (ref: INPUT5)
	*EX3* Exercises will have a Name field that is Visible to the User (ref: UI2)
	*EX4* Exercises will have an ID field that is NOT visible to the User
	*EX5* Exercises will have a Picture of each exercise that is visible to the User (ref: UI5)
	*EX6* Exercises will have a Description of each exercise that is visible to the User (ref: UI5)
	*EX7* Exercises will have the Max associated with them, based on what the User Inputs that will be visible to the User (ref: INPUT4, UI5)
	*EX8* Exercises will have Math Associated with them based on User input 5 Repetitions (ref: MATH(ALL)), This will be displayed to the User for selected Exercise
	*EX9* Exercises will have a scheme of 5 Repetitions, 5 Sets.  (ref: MATH1)
	*EX10* Exercises will have a scheme of 5 Repetitions, 4 Sets. (ref: MATH2)
	*EX11* Exercises will have a scheme of 8 Repetitions, 1 Set.  (ref: MATH3)
	*EX12* Exercises will have a scheme of 3 Repetitions, 1 Set.  (ref: MATH4)
	

### ExerciseMax;
	*EXM1* User will be able to enter there 5 Repetition Max for each given Exercise (ref: INPUT4)
	*EXM2* User ExerciseMax (ref: INPUT4) will increase to weight of The 3 Repetitions 1 Set weight (ref: MATH4) every time 1 Cycle has been completed (ref: CYCLE5) and will be the new User ExerciseMax, but can be reverted if User chooses to (ref: INPUT7)
	
	
### Math for Exercises;
	*MATH1* Math for 5 Repetitions weight, 5 Sets is as follows: 1st set = User entered 5 Repetition ExerciseMax weight. EACH following set (2-5) will have an additional 15% Decrease applied to them, Rounded to nearest 5lbs
	*MATH2* Math for 5 Repetitions weight, 4 Sets is as follows: 1st set = User entered 5 Repetition ExerciseMax weight with 15% Decrease applied on it, then EACH following set (2-4) will have an additional 15% Decrease applied to them, Rounded to nearest 5lbs
	*MATH3* Math for 8 Repetitions weight, 1 Set is as follows: Set = 3rd Set Weight (ref: MATH1)
	*MATH4* Math for 3 Repetitions weight, 1 Set is as follows: Set = User ExerciseMax weight + additional 2.5% increase to weight
	

### Cycle;
	*CYCLE1* Each Cycle will consists of 3 Phases
	*CYCLE2* Phase 1 will consist of 3 Separate Exercises; All Exercises in Phase 1 will follow 5 Sets Layout (ref: EX9)
	*CYCLE3* Phase 2 will consist of 3 Separate Exercises; All Exercises in Phase 2 will follow 4 Sets Layout (ref: EX10)
	*CYCLE4* Phase 3 will consist of 3 Separate Exercises; All Exercise of Phase 3 will follow 4 Sets Layout (ref: EX10), With the Addition of 1 Set, 3 Repetitions Layout (ref: EX12), and then 1 Set, 8 Repetitions Layout (ref: EX11)
	*CYCLE5* 1 Cycle will be considered "Complete" When all 3 phases are also complete
	
	
### Plates;
	*PLATES1* Application will calculate plates needed to == the weight for a given exercise (ref: MATH(ALL))
		*PLATES1.1* Each Plate must be used twice to reach the weight (ref: PLATE1). If weight can't be used, Next plate in the hierarchy will be tried (ref: PLATE8). Process continues until target weight is reached
	*PLATES2* Plate weight will use 45lbs as a plate
	*PLATES3* Plate weight will use 25lbs as a plate
	*PLATES4* Plate weight will use 10lbs as a plate
	*PLATES5* Plate weight will use 5lbs as a plate
	*PLATES6* Plate weight will use 2.5lbs as a plate
	*Plates7* Calculating plates needed for weight of given Exercise and ExerciseMax will have a precedence hierarchy for which plates to use before trying to use other plates
	*PLATES8* Plates Hierarchy is as follows: 45lbs > 25lbs > 10lbs > 5lbs > 2.5lbs. Application will try to use as few plates as possible in order to get to assigned weight (Using bigger plates first before smaller ones)
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	