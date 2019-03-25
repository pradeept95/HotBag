using Hangfire;
using System;

namespace HotBag.Scheuler
{
    public class Job : IJob
    { 
        public void InitializeAllJobs()
        {
            //#Fire-and-forget
            //This is the main background job type, persistent message queues are used to handle it. Once you create a fire-and-forget job, it is saved to its queue ("default" by default, but multiple queues supported). The queue is listened by a couple of dedicated workers that fetch a job and perform it.
            BackgroundJob.Enqueue(() => FireAndForgetHelper());

            //#Delayed
            //If you want to delay the method invocation for a certain type, call the following method. After the given delay the job will be put to its queue and invoked as a regular fire-and-forget job.
            BackgroundJob.Schedule(() => FireAndForgetHelper(), TimeSpan.FromSeconds(1));

            //#Recurring
            //To call a method on a recurrent basis (hourly, daily, etc), use the RecurringJob class. You are able to specify the schedule using CRON expressions to handle more complex scenarios.
            //RecurringJob.AddOrUpdate(() => sendMail(), Cron.Minutely);

            RecurringJob.AddOrUpdate(() => RecurringHelper(), Cron.Minutely);


            //#Continuations
            //Continuations allow you to define complex workflows by chaining multiple background jobs together.
            var id = BackgroundJob.Enqueue(() => Console.WriteLine("Hello, "));
            BackgroundJob.ContinueWith(id, () => Console.WriteLine("world!"));
        }


        public void FireAndForgetHelper()
        {
            Console.WriteLine("Fire-and-forget");

        }

        public void DelayedHelper()
        {
            Console.WriteLine("Delayed");
        }

        public void RecurringHelper()
        {
            Console.WriteLine("Recurring");
        }
    }
}
