# Contributing to IPA 5.0

Every well designed project has a good set of guidelines that govern the way the way contributions are made. This project has a relatively high contribution bar because we designing a piece of software that needs to be easily polymorphic in nature.

To achieve this goal there are some key guidelines that ALL engineers must follow and below are the details to achieve this.

# Vision

* The software should be well organized and contributors will accept merges of code that meets the coding style and doesn't adversely affect performance of the application.

* The software should be easy to configure and workflow driven with the ability to customize it for a particular customer with minimal code changes.

* Every aspect of the software **must** follow single responsibility principle. If you need to add a helper and you're not sure where it should go it is better to ask for advice then to place it anywhere that seems to fit.

* There is method to the madness, conform to the coding style, follow existing design patterns and principles laid out in the **Best Practice Patterns** guide and you will design better software with fewer bugs. Any bugs that do arise will be misunderstood requirements and not related to poor design.

# Do's and Dont's

**DO's**:

* Regularly check out the **Coding Style** and **Best Practice Patterns** guide. They were intentionally placed in the repository so there is one less place to find everything you need to be productive in the project.

* Follow existing styles that conform to our coding style and do not deviate from it. You also should not change any project setting files related to editor configuration files or linting files without first consulting with at least 2 team members on proposed changes.

* All check-in's must include tests and this includes bug fixes. If you are fixing a bug then be sure to write a test to demonstrate the failure mode and then a separate test to cover the fix.

* When you open up a pull request be sure to include three things in your description:
    * Abstract - Describing what feature, bug or problem this pull request addresses.
    * Bullet list of what changes were done from a high level. See below for an example

    ```plain
    Abstract: 
        This pull request adds a new feature to the event broker which opens up a secondary communication channel.

    Changes:
        - Added new Anonymous Pipes Channel to the Event Broker and Client Library.

        - Modified helper methods to accomodate for extra changes needed in the channel.
    ``` 

    This makes the pull request clear and concise for anyone reviewing it to understand exactly what changes are being proposed and they can quickly provide feedback.

**DONT's**:

* Pull request should not be made just to fix formatting or style changes.

* Pull Requests should not be massive in size but should be reasonably sized so proper feedback can be given. If you find yourself writing code that will end up as a massive pull request, pull a team member aside and start a discussion prior to submitting your pull request.

* Please do not commit any code that you didn't write if the code is not under permissive licensing.

    * Code that you use in the project is listed under some sort of open source permissive license. **This is OK**.

    * Code that you use in the project is not listed with any sort of licensing information. **This is OK**.

    * Code that you use in the project that is not under an open and permissive license. <span style="color:red;font-weight:bold;text-decoration:underline;">This is NOT OK</span>. In this case please open up a discussion with team members so this can be examined before usage. We would hate to have included anything at all that would require us to later remove it and update our software on hundreds or thousands of machines. This would be a PR disaster.

* Code changes should not break existing compatibility and if it does then you should not submit this for PR unless you open up a discussion with fellow team members prior to the PR submission. This is aimed at saving time and being efficient during our code review process.

* Do not modify the Squash Merge messaging for PR #.. You can tweak it slightly but every commit to a key branch **must have the PR #** embedded in it.


# Performance Benchmarking and Profiling

Performance is paramount to ensuring that our system can handle hundreds of thousands of payments per minute. To achieve this we must be able to theoretically think about our fix, practically implement it and then perform a proof on it to validate our assertions match three areas:

* Code change operates within a reasonable time complexity.

* Code change operates within a reasonable space complexity.

* Code change takes advantage of proper framework utilities that have been battle tested without re-inventing the wheel.

To this end all code that is going up for pull request which introduces a segment of work that has a lot of computation or will be called from a high usage section of the code, you must adhere to the following guidelines.

**Benchmarking DO's and DONT's**:

* <span style="color:green;font-weight:bold;">DO:</span> Run benchmarks on your code when you want to analyze how it will perform in a section of the software that is part of critical path. Critical path is any segment that is directly tied to the payment workflow.

* <span style="color:green;font-weight:bold;">DO:</span> You should benchmark deterministic code changes that we have direct control over.

* <span style="color:red;font-weight:bold;">DONT:</span> Do not benchmark code that we have no control over (File I/O, Network I/Om etc...)

* <span style="color:green;font-weight:bold;">DO:</span> You should do performance testing against release builds and not debug builds. This way your testing is similar to what the customer will see in production.

* <span style="color:green;font-weight:bold;">DO:</span> Provide relevant sample sizes to get a good idea of:

    * Minimum Execution Time
    * Average Execution Time
    * Maximum Execution Time
    * Average Memory Usage

# Profiling Tools

The .NET Core and many Microsoft teams use PerfView because it allows you to monitor the performance of the entire machine you're developing on. It allows you to collect all kinds of performance data and is relevant for examining many aspects of a project.

You are also free to utilize the Microsoft Profiler but PerfView should be your primary tool when you are examining release copies of a build to test your new additions out.

[Click Here to Download PerfView](https://github.com/Microsoft/perfview/blob/master/documentation/Downloading.md)

