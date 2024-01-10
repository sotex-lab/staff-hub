## User
 
The User class represents individuals within the system and encapsulates information related to user accounts.
 
#### Attributes
 
1. **Name** - string: The full name of the user.
2. **Email** - string: The email address associated with the user's account.
3. **Password** - string: The secure password for the user's account.
4. **PhoneNumber** - string: The contact number of the user.
5. **Team** - string: Specifies the team to which the user belongs.

Role:  Represents the user's role within the system, which can be either "admin" or "employee."

## Leave
 
The Leave class manages information related to leave requests made by users.
 
#### Attributes
 
1. **StartDate** - DateOnly: The start date of the leave request.
2. **EndDate** - DateOnly: The end date of the leave request.
3. **Description** - string: Provides additional details or reasons for the leave.
4. **Status** - string: Indicates the current status of the leave request.

## DaysTally

The DaysTally class is associated with the User class and is specifically designed to track and manage the allocation and usage of days related to annual leave for individual users.

#### Attributes
 
1. **Amount** - int: Represents the numerical value associated with the action, such as the number of days taken or accrued.
2. **Timestamp** - DateTIme: Records the date and time when the action occurred.
3. **Action** - string: Describes the nature of the action, providing context to the days' tally.

## PublicHoliday
 
The PublicHoliday class manages information about public holidays.
 
#### Attributes
 
1. **Name** - string:  The name of the public holiday.
2. **StartDate** - DateOnly: The start date of the public holiday.
3. **EndDate** - DateOnly: The end date of the public holiday.

## Diagram

<img src='/staff-hub/assets/images/diagram.png' />
