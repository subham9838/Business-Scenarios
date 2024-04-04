using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using System.ServiceModel;

namespace Business_Scenarios
{
    public class CreateFollowupTask : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Obtain the tracing service
            ITracingService tracingService =
            (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            // Obtain the execution context from the service provider.  
            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));

            // The InputParameters collection contains all the data passed in the message request.
            if(context.InputParameters.Contains("Target") &&
                context.InputParameters["Target"] is Entity)
            {
                // Obtain the target entity from the input parameters.  
                Entity entity = (Entity)context.InputParameters["Target"];

                // Obtain the IOrganizationService instance which you will need for  
                // web service calls.  
                IOrganizationServiceFactory serviceFactory =
                    (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

                try
                {
                    // Create a task activity to follow up with the account customer in 7 days.
                    Entity follwUp = new Entity("task");

                    follwUp["subject"] = "Send e-mail to new customer";
                    follwUp["description"] = "Follow up the customer";
                    follwUp["scheduledstart"] = DateTime.Now.AddDays(7);
                    follwUp["scheduledend"] = DateTime.Now.AddDays(7);
                    follwUp["category"] = context.PrimaryEntityName;

                    if(context.OutputParameters.Contains("id"))
                    {
                        Guid regardingobjectid = new Guid(context.OutputParameters["id"].ToString());
                        string regardingobjectidType = "account";

                        follwUp["regardingobjectid"] = new EntityReference(regardingobjectidType, regardingobjectid);

                        // Create the task in Microsoft Dynamics CRM.
                        tracingService.Trace("FollowupPlugin: Creating the task activity.");
                        service.Create(follwUp);
                    }
                }

                catch (FaultException<OrganizationServiceFault> ex)
                {
                    throw new InvalidPluginExecutionException("An error occurred in FollowUpPlugin.", ex);
                }

                catch (Exception ex)
                {
                    tracingService.Trace("FollowUpPlugin: {0}", ex.ToString());
                    throw;
                }
            }
        }
    }
}
