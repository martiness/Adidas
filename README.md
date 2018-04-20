# Adidas
Adidas Case Study

Requirements 
1.	Please prepare the following use cases and upload them to a public repository (e.g. GitHub or Bitbucket).	
2.	Make sure that test scripts are executable on a local machine.	
3.	Add additional information in case any software/framework is required to run those test cases (installation script is preferred).	
4.	Also, advice in form of a short readme how to execute those test scripts.		

Tasks	
API-Tests for the Adidas homepage CMS response
1.	Write API tests for https://www.adidas.fi/api/pages/landing?path=/
2.	SLAs/requirements are:
•	Response time should be bellow 1s	
•	Images should be accessible (no 404/401s)
•	Every component has at least analytics data “analytics_name” in it 
3.	Include basic reporting (e.g. HTML/XML)
	
UI-Tests for the Adidas homepage
1.	Write at least three UI tests for https://www.adidas.fi/	
2.	Tests should be executable locally
3.	(prep. Cross browser testing (Chrome/Firefox))
4.	Include basic reporting (e.g. HTML/XML)
 
Adidas API	

Task #1: API-Tests for the Adidas homepage CMS response
1.	Write API tests for https://www.adidas.fi/api/pages/landing?path=/
2.	SLAs/requirements are:
•	Response time should be bellow 1s	
•	Images should be accessible (no 404/401s)
•	Every component has at least analytics data “analytics_name” in it 
3.	Include basic reporting (e.g. HTML/XML)
Instructions
Environment Setup
1.	Install Microsoft .NET Framework 4.7
2.	Install Microsoft Visual Studio (2015/2017)
Solution/Project Setup
1.	Create New project in MS Visual Studio
•	Library Name: “AdidasAPI”
•	Solution Name: “Adidas”
•	Location:  “.\Adidas”
2.	Add Nuget Packages, need for the project
From Visual Studio >> Tools >> Nuget Package Manager >> Manage Nuget Packages for Solution find and install 
•	NUnit 3
•	Newtonsoft Json
•	Extent Report 
Create API Client (Client.cs)
1.	Rename “Class1.cs” to “Client”
2.	Create “API Client” constructor and “Get Async API response” methods. (See code in the project)
•	public Client(string url = urlAddress
•	public async Task<HttpResponseMessage> GetAsync(string path)
3.	Add External liberties:  System; System.Threading.Tasks and System.Net.Http;
Create API Model (Models.cs)
1.	How to make response working for us
2.	From https://www.adidas.fi/api/pages/landing?path=/ copy Raw Data
3.	In order to covert JSON response to C# object go to site https://app.quicktype.io/
4.	Paste Adidas API response Raw Data on the left
5.	Set QuickType output object to 
•	Language: “C#” 
•	Use T[] or List<T>: “List”
•	Output features: “Complete”
6.	Copy the result to clipboard
7.	Create new class, called Models
8.	Paste result from QuickType online converter into Models
9.	Now we have C# object containing API response 
10.	Add external liberties:  System; System.Collections.Generic; System.Globalization; Newtonsoft.Json; Newtonsoft.Json.Converters;

Create API Tests (APITests.cs)
1.	Create new test class, called “APITests”, a place holder of all API Tests
2.	Add External liberties:  System; System.Diagnostics; System.Net.Http; NUnit.Framework;
API Test #1: Response time should be bellow 1s	
1.	Create first test “CheckForReponseTimeTest()”, in order to verify that Response time should be bellow 1s (See code in the project)
2.	Run Test and Check the result
API Test #2: •	Images should be accessible (no 404/401s)
1.	Create second test “CheckForEmptyImagesTest()”, in order to verify that Images should be accessible (no 404/401s)  (See code in the project)
2.	Run Test and Check the result
API Test #3: Every component has at least analytics data “analytics_name” in it
1.	Create third test “CheckForAnalyticsData()”, in order to verify that Every component has at least analytics data “analytics_name” in it  (See code in the project)
2.	Run Test and Check the result

API Tests Results in Test Explorer after Run All Test 
 
Create API Tests Reporting Extension (APITestsReportGenerator.cs)
1.	Create new class “APITestsReportGenerator.”, a place holder for Test Suite and Report Generator
2.	Add External liberties:  System; System.Diagnostics; System.Net.Http; NUnit.Framework; AventStack.ExtentReports; AventStack.ExtentReports.Reporter; AventStack.ExtentReports.Reporter.Configuration;
3.	Modify code to use NUnit Test Suite annotations [TestFixture], [OneTimeSetUp], [SetUp] and [TearDown]
4.	Add Test Report Generator in [OneTimeSetUp]
5.	Add Web driver creation in [SetUp]
6.	Add Web driver disposal in [TearDown]
7.	Add Create Report in [OneTimeTearDown]
8.	Copy existing API Tests and rename to new class
9.	Modify test to use Try and Catch, to capture Pass and Fail test status in the Report status. (See code in the project)
10.	Rebuild Solution
11.	Run Test and Check the result
12.	Report location: "C:\Adidas\Adidas\Report\APITestsReport.html"

API Tests Report Generator Results page – Passed Successfully 
 

 
Task #2: UI-Tests for the Adidas homepage
1.	Write at least three UI tests for https://www.adidas.fi/	
2.	Tests should be executable locally
3.	(prep. Cross browser testing (Chrome/Firefox))
4.	Include basic reporting (e.g. HTML/XML)
Solution/Project Setup
1.	Add New project in MS Visual Studio
•	Library Name: “UITests”
2.	Add Nuget Packages, need for the project
From Visual Studio >> Tools >> Nuget Package Manager >> Manage Nuget Packages for Solution find and install 
•	NUnit 3
•	Selenium.WebDriver
•	Selenium WebDriver Chrome Driver
•	Selenium WebDriver Firefox Driver
•	Extent Report 
3.	Download and install Browser Drivers
•	Firefox Driver https://github.com/mozilla/geckodriver/releases
•	Chrome Driver: https://sites.google.com/a/chromium.org/chromedriver/
4.	Add System Environment Variables
Control Panel >> System -> Advanced System Settings >> Environment Variables >> User variables
Edit PATH item. 
Add browser drivers paths, as follows:
C:\BrowsersDrivers\chromedriver_win32;
C:\BrowsersDrivers\geckodriver_win64; 
Save changes.
Create UI Tests (UITests.cs)
1.	Rename “Class1.cs” to “UITests”, a place holder of all UI Tests
2.	Add External liberties:  OpenQA.Selenium; OpenQA.Selenium.Firefox; OpenQA.Selenium.Chrome; NUnit.Framework;
UI Test #1: Adidas Home page navigation in Firefox browser
1.	Create first test “CheckForMainPageNavigationInFirefox()”, in order to verify that Adidas Home page main sections navigation working correctly in Firefox browser (See code in the project)
2.	Run Test and Check the result
UI Test #2: Adidas Home page navigation in Chrome browser
1.	Create second test “CheckForMainPageNavigationInCrome()”, in order to verify that Adidas Home page main sections navigation working correctly in Chrome browser (See code in the project)
2.	Run Test and Check the result
UI Test #3: Adidas Search functionality verification with existing product
1.	Create third test “CheckForSearchFunctionalityWithValidValue()”, in order to verify that Adidas Search functionality working correctly with positive value (See code in the project)
2.	Run Test and Check the result

UI Test #4: Adidas Search functionality verification with not existing product
1.	Create third test “CheckForSearchFunctionalityWithNotValidValue()”, in order to verify that Adidas Search functionality working correctly with negative value (See code in the project)
2.	Run Test and Check the result

UI Tests Results in Test Explorer after Run only new UI Tests 
 

Create Cross Browsing UI Tests (UITestsXBrowsers.cs)
1.	Create new class “WebClient”, a place holder for Browser Drivers
2.	Add External liberties:  System; OpenQA.Selenium; OpenQA.Selenium.Firefox; OpenQA.Selenium.Chrome;
3.	Create a generic driver method public static IWebDriver CreateDriver(string browser) (See code in the project)
4.	Create new class “BrowserTypes”, a place holder of Browser Types
5.	Add external liberties:  Not required any
6.	Create new class “UITestsXBrowsers”, a placehoder for Cross Browser Tests
7.	Copy CheckForMainPageNavigation test and modify it to use generic driver (See code in the project)
8.	Add Test Case parameters to use different browsers 
[TestCase(BrowserTypes.Firefox)]
[TestCase(BrowserTypes.Chrome)]
9.	Rebuild Solution
10.	Run Test and Check the result

API Tests, Single and Cross Browsing UI Tests Results 
 
Create UI Tests Reporting Extension (UITestsReportGenerator.cs)
11.	Create new class “UITestsReportGenerator”, a place holder for Test Suite and Report Generator
12.	Add External liberties:  OpenQA.Selenium; OpenQA.Selenium.Firefox; NUnit.Framework; AventStack.ExtentReports; AventStack.ExtentReports.Reporter; AventStack.ExtentReports.Reporter.Configuration;
13.	Modify code to use NUnit Test Suite annotations [TestFixture], [OneTimeSetUp], [SetUp] and [TearDown]
14.	Add Test Report generator in [OneTimeSetUp]
15.	Add Web driver creation in [SetUp]
16.	Add Web driver disposal in [TearDown]
17.	Add Create Report in [OneTimeTearDown]
18.	Copy existing Firefox NavigationUITest and rename it to NavigationUITestWithReportGenerator.
19.	Modify test to use Try and Catch, to capture Pass and Fail test status in the Report status.
20.	Rebuild Solution
21.	Run Test and Check the result
22.	Report location: "C:\Adidas\Adidas\Report\UITestsReport.html"
UI Test Report Generator Results page – Passed Successfully 
 

Final Run of All Tests – Passed Successfully 
 
