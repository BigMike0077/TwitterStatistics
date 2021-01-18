# Tritter Statistics - Programming Assignment

The Twitter API provides a stream endpoint that delivers a roughly 1% random sample of publicly available Tweets in real-time. In this assignment you will build an application that utilizes that endpoint and processes incoming tweets to compute various statistics. We'd like to see this as a .NET Core or .NET Framework project, but otherwise feel free to use any libraries or frameworks you want to accomplish this task.

The Twitter API v2 sampled stream endpoint provides a random sample of approximately 1% of the full tweet stream.

This Solution contains 3 projects:
1) EmojiData - Creates a Dictionary of the emoji.json file and a class to match emojis from the tritter data text.
2) TwitterStatistics - Main program that runs and accumulated the real-time tritter statistics.
3) TwitterStatisticsUnitTest - unit test.

Sample Output:

 < Tweet Statistics > 
Total Tweets      : 1700
Tweets/Second     : 52.27
Tweets/Minute     : 3136.00
Tweets/Hour       : 188182.00
Tweets with Emojis: Under Construction%
Top Emojis        : Under Construction
Tweets with Url   : 2%
Top Urls          : Under Construction%
 < ---------------- >


## Run Instruction

To run the TwitterStatistics program, you are required to provide your twitter bearer code.
This code must be added to the TwitterStatistics project Arguments array.


Thank you for this assignment.
It was interesting and very challanging.