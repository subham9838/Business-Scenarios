using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using System.ServiceModel;
using Microsoft.Xrm.Sdk.Messages;

namespace Business_Scenarios
{
    public class RestrictPayment : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Obtain the tracing service
            ITracingService tracingService =
            (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            // Obtain the execution context from the service provider.  
            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));

            Entity entity = (Entity)context.InputParameters["Target"];
            Entity preEntityImage = context.PreEntityImages["preImage"];

            // Obtain the IOrganizationService instance which you will need for  
            // web service calls.  
            IOrganizationServiceFactory serviceFactory =
                (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            tracingService.Trace("followingerror: Start1");
            try
            {
                if (context.InputParameters.Contains("Target") &&
                context.InputParameters["Target"] is Entity)
                {
                    tracingService.Trace("followingerror: {0}");
                    //if (entity.Attributes.Contains("fax"))
                    //{
                    //    tracingService.Trace("followingerror: {1}");
                    //    string fax = (string)entity["fax"];
                    //    tracingService.Trace("followingerror: {2}");
                    //    entity["address1_line1"] = fax;
                    //}
                    //if(entity.Attributes.Contains("fax"))
                    //{
                    //    string newFax = (string)entity["fax"];
                    //    string oldFax = string.Empty;
                    //    if(preEntityImage.Attributes.Contains("fax"))
                    //    {
                    //        oldFax = (string)preEntityImage["fax"];
                    //    }

                    //    entity["address1_line1"] = "Old fax " + oldFax + " New fax " + newFax;
                    //}
                    if (entity.Attributes.Contains("crb9e_term"))
                    {
                        //string newTerm = entity.FormattedValues["crb9e_term"];
                        ////int newTerm = (int)entity.Attributes["crb9e_term"];
                        ////string name = (string)entity["crb9e_name"];
                        //string oldTerm = string.Empty;
                        //if (preEntityImage.Attributes.Contains("crb9e_term"))
                        //{
                        //    oldTerm = preEntityImage.FormattedValues["crb9e_term"];

                        //    //if (int.TryParse(newTerm, out int result1) < int.TryParse(oldTerm, out int result2))
                        //    if()
                        //    {
                        //        throw new InvalidPluginExecutionException("You cannot change term from higher to lower");
                        //    }
                        //}
                        //entity["crb9e_value"] = newTerm;
                        tracingService.Trace("followingerror: Start1");
                        OptionSetValue newTerm = (OptionSetValue)entity["crb9e_term"];
                        tracingService.Trace("followingerror: {0}");
                        int newTermValue = newTerm.Value;
                        tracingService.Trace("followingerror: {1}");
                        if (preEntityImage.Attributes.Contains("crb9e_term"))
                        {
                            tracingService.Trace("followingerror: {2}");
                            OptionSetValue oldTerm = (OptionSetValue)preEntityImage["crb9e_term"];
                            tracingService.Trace("followingerror: {3}");
                            int oldTermValue = oldTerm.Value;
                            tracingService.Trace("followingerror: {4}");
                            if (oldTermValue > newTermValue)
                            {
                                tracingService.Trace("followingerror: {5}");
                                throw new InvalidPluginExecutionException("You cannot change term from higher to lower");
                            }
                            tracingService.Trace("followingerror: {6}");
                        }
                    }
                }
            }
            
            catch (Exception ex)
            {
                tracingService.Trace("followingerror: {7}");
                throw new InvalidPluginExecutionException("You cannot change term from higher to lower", ex);
            }
        }
    }
}
