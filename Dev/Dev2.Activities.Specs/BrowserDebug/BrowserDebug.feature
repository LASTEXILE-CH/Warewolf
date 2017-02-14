﻿Feature: BrowserDebug
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Executing an empty workflow
		Given I have a workflow "BlankWorkflow"
		When "BlankWorkflow" is executed
		Then the workflow execution has "AN" error
		And I Debug "http://localhost:3142/secure/BlankWorkflow.debug?" in Browser
		And The Debug in Browser content contains "The workflow must have at least one service or activity connected to the Start Node."

Scenario: Executing a workflow with no inputs and outputs
		Given I have a workflow "NoInputsWorkflow"
		When "NoInputsWorkflow" is executed
		Then the workflow execution has "NO" error
		And I Debug "http://localhost:3142/secure/NoInputsWorkflow.debug?" in Browser
		And The Debug in Browser content contains has children with no Inputs and Ouputs

Scenario: Executing Assign workflow with inputs and outputs
		Given I have a workflow "AssignedVariableWF"
		When "AssignedVariableWF" is executed
		Then the workflow execution has "NO" error
		And I Debug "http://localhost:3142/secure/AssignedVariableWF.debug?" in Browser
		And The Debug in Browser content contains has inputs and outputs

Scenario: Executing Hello World workflow
		Given I have a workflow "Hello World"
		When "Hello World" is executed
		Then the workflow execution has "NO" error
		And I Debug "http://localhost:3142/secure/Hello World.debug?" in Browser
		And The Debug in Browser content contains has inputs and outputs

#Scenario: Executing a Sequence workflow
#Scenario: Executing a Foreach workflow
#Scenario: Executing a Dotnet plugin workflow
#Scenario: Executing a Recordset sort workflow