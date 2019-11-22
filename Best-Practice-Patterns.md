# Best Practice Patterns

Writing software is hard and it requires a lot of time, patience and practice to write effective software. But effective software must also be maintainable and that is what this guide is going to discuss, how to write effective and maintainable software.

During your career as a software engineer you've come across one or two patterns and stuck to it for quite a while. The reason could be because you were simply comfortable with what you knew or that it was the best way you knew how to implement something.

Regardless of what you know you will gain something from this guide so let's begin with some basic principles.

# Maintainability Theory

There are a couple key points that you must keep in mind when you are interested in writing great software and here they are:

* When you have code organized into a class that is meant to perform a unique set of tasks and do them well you must not pollute its implementation.

* The dependencies that it has must either be:
    * Reliant on .NET Framework classes.
    * Reliant on Provider Classes (if there is a one to many relationship) or an abstract Interface (if there is a one to one relationship).

    Let's look at this one a bit more closely. The first point here is that if you have .NET Framework classes directly used in the class this is ok. In fact, it is to be expected because there is no way around this. However, if you have **ANY** class dependency that is going to be utilized which has an interface with many derived classes then it is best to ensure that it gets injected into that class.

    If you have code that is subject to change or any sort of modification then you would want to use **Provider** classes. A Provider class is one that further abstracts **how** the **what** is given back to the consumer class. Let's look at an example.

    ```csharp
    // One generic interface that has a simple method.
    internal interface IPaymentDevice {
        IDeviceInformation GetDeviceInfo();
    }

    // From this point we can have concrete implementations for a device.
    internal class VerifoneDevice : IPaymentDevice { }
    internal class IngenicoDevice : IPaymentDevice { }
    internal class IdTechDevice   : IPaymentDevice { }

    /**
     * The following code looks rather well but it creates a lot of confusion and noise.
     * The reason for this is because static classes are historically harder to test
     * unless it truly is a single unit of work and if it isn't then you have no
     * easy way of testing out all of those dependencies.
     */
    public static class PaymentDeviceFactory {
        public static IPaymentDevice GetPaymentDevice() {
            // Get some operating system information on connected devices.
            string connected_device_identifier = OS.GetActiveDevice();
            switch (connected_device_identifier) {
                case "idtech": return new IdTechDevice();
                case "ingenico": return new IngenicoDevice();
                case "verifone": return new VerifoneDevice();
                default: throw new DeviceException("No relevant payment devices detected.");
            }
        }
    }

    class DALContext {
        /**
         * The following pattern looks great but it is really clunky and will
         * inevitably lead you down a hole of no return because you can't properly
         * test this. You've tightly coupled things so testing this method is no 
         * longer a trivial task of injecting a mock.
         *
         * If testing something isn't somewhat trivial then it's the FIRST sign that * whatever you're working on is not sound design.
         */
        private void InitializeDevice() {
            IPaymentDevice paymentDevice = PaymentDeviceFactory.GetPaymentDevice();
        }
    }
    ```

    Now let's improve on this and see how we can better improve this.

    ```csharp
    /**
     * First we create a provider that only cares about locating devices on the
     * system. This way we can separate out concerns.
     */
     internal interface IDeviceLocator {
         DeviceCollection LocateConnectedPaymentDevices();
         DeviceCollection LocateRemotelyConnectedPaymentDevices(RemoteMachineConfig config);
     }

     internal class DeviceLocator : IDeviceLocator { }

     /** 
      * Now we create a class that is interested in how to create a device using
      * the locator code.
      */
      internal interface IDeviceProvider {
          IPaymentDevice GetPaymentDevice();
      }

      internal class PaymentDeviceProviderImpl : IDeviceProvider {
          /**
           * For reference purposes there are two ways in which you can approach the
           * dependency problem. The first (using Ninject) is to do property based
           * injection. The second is the more traditional form which is constructor
           * based injection.
           *
           * For our project we are using Ninject so we prefer property based
           * injection.
           */
           [Inject]
           private IDeviceLocator DeviceLocatorService {get; set;}

           /**
            * Notice here that we now have the ability to inject our own device
            * locator service and provide our own implementation.
            *
            * Secondarily, if we want to add a way to locate a device there really
            * isn't much that needs to be changed. If your requirement is to locate
            * a payment device on the local machine then you can use the locally
            * connected payment device.
            *
            * However, if your workflow allowed for locating a remotely connected 
            * device on a different machine then you would use the 2nd method
            * which would locate it on the remote machine for both cases.
            *
            * The only difference is that you would now have one method that
            * can be used to locate a device on the local machine or elsewhere.
            * We do not try to over-engineer early on but we try to optimize based on
            * current requirements and what can potentially come.
            *
            * In this case we would opt to modify the interface to this:
            *
            *   internal interface IDeviceLocator {
            *   DeviceCollection LocatePaymentDevices
            *        (RemoteMachineConfig config);
            *   }
            *
            * Now the RemoteMachineConfig can be either local or remote :).
            */
           public IPaymentDevice GetPaymentDevice() {
               DeviceCollection deviceCollection = DeviceLocatorService.LocatePaymentDevices(someConfigObject);

               return deviceCollection.First();
           }
      }
    ```

    <h2>As long as you follow this pattern and you properly isolate dependencies to the necessary place they need to be then you will never find yourself in a position that you can't get out of elegantly. The best way to know if you've deviated too much is to ask yourself if you can test any particular method in your class relatively easily. If the answer is NO then you've done something wrong and will end up creating code debt.</h2>

This is an art and it comes naturally for others then it does for other people so if you find yourself struggling to figure out the best way to organize your classes then do not try and brave it out. You must ASK someone else to assist you so that you may learn and better improve your design skills so you don't produce something that will cause maintenance headaches later on.


## Cafe Approach

What was discussed above is also known as the **Cafe Approach** which a term I coined to describe a pattern of software development that works extremely well in a wide variety of cases. The cafe approach is relatively easy and designed to ensure that you lead yourself to success by design and not by convention, at least as far as maintainability is concerned.

Here is the general workflow:

* You need something? Ok great, let's get you to someone who can help you.
* Someone else jumps on (Provider Class) to answer your question.
* You tell them what you're interested in (parameters).
* They answer your question abstracting any noise you don't need (Interface of a concrete class).

They provide the answer to you rather than you Googling it yourself is the best analogy I can give because if you Google'd it yourself you'd have to sort through all of the noise, versus someone who already knows something just telling you what's important.

**Follow the Cafe Approach and my Maintainability Theory and you will design maintainable  and effective software that can grow with your project needs.**

