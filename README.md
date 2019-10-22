# product-sku-test

## Overview
This is a test application which manages Products. Products are made of 1 or more Materials.

## Technology
- C#
- MVC/Asp.Net
- Entity Framework
- Note we are specifically not using a SPA ClientSide framework like Angular or React to keep things simple.
- MS-SQL

## The Test
### Problem
It is common that users will accidently create two Materials in the system when there should only be one. In this database they have created _Box 1_ and _Box 2_. The _Toy Car_ product uses _Box 1_ and the _Train Set_ product uses _Box 2_.

The user has realized that Box 1 and Box 2 are actuall the same physical item, and would like to use *merge* Box 1 and Box 2: i.e., just use Box 1, and get rid of Box 2.

### Requirements
- When viewing a Material, they user should have access to an action which allows them to merge the material with another material.
- They will have to select the 2nd material.
- The result should be that the 2nd material is deleted, and any product that _was_ using the 2nd material is now using the other material.

### The Solution
You will be judged based on the following:
- How well you follow the requirements.
- How well your solution blends into the existing solution.

### How to submit your solution
- Fork this repository
- Code your solution in your fork
- When you are done, please email me the link to your fork.

### Tips
- Make sure to run Update-Database to get the seed data
- The .Data project contains the DB context, you you will need to use it was the project from the Package Manager console. 
- Visual Studio 2019 Community is recommended
