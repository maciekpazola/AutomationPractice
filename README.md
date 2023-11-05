# Automated Testing Project Using Selenium, C#, SpecFlow, and POM Pattern

## Project Description
This project aims to demonstrate the process of creating and executing automated tests on the website "http://the-internet.herokuapp.com/". The tests are written in C# using the Selenium framework, SpecFlow for describing test scenarios in gherkin language, and the Page Object Model (POM) pattern for organizing the test structure.

## The project includes:
- A logging system based on MongoDB.
- A reporting mechanism for test results.
- Capturing screenshots in case of test failures.
- Running tests in parallel across different browsers using Selenium Grid.
- Using a `docker-compose` file to set up and manage the Selenium Grid server and MongoDB containeer.

## Requirements:
- Visual Studio or another C# compatible editor.
- Docker installed on your computer to run the Selenium Grid.
- MongoDB compass

## How to Run:
1. Clone this project to your computer.
2. Open a terminal and navigate to the DockerFiles folder.
3. Start the Selenium Grid server and MongoDB using the command `docker-compose up -d` in the directory where the `docker-compose.yml` file is located(to use full potential of parallel testing you should scale number of browser containeers to your environment).
4. Open the project in Visual Studio or your preferred editor.
5. Run the automated tests using SpecFlow.
6. Check logs in MongoDB(you have to configure connection to selected port in docker-compose and credentials).
7. Check report based on last test run.
