using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using System.ServiceModel;
using Microsoft.Crm.Sdk.Messages;

namespace Business_Scenarios
{
    public class StudentandCourses : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {

            // Obtain the tracing service
            ITracingService tracingService =
            (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            // Obtain the execution context from the service provider.  
            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));

            string fieldName = (string)context.InputParameters["san_TargetFieldName"];
            string entityName = (string)context.InputParameters["san_TargetEntityName"];
            string entityId = (string)context.InputParameters["san_TargetEntityId"];

            // Obtain the IOrganizationService instance which you will need for  
            // web service calls.  
            IOrganizationServiceFactory serviceFactory =
                (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            tracingService.Trace("followingerror: Start1");
            try
            {
                tracingService.Trace("followingerror: {0}");
                CalculateRollupFieldRequest request = new CalculateRollupFieldRequest
                {
                    Target = new EntityReference(entityName, new Guid(entityId)),
                    FieldName = fieldName
                };
                tracingService.Trace("followingerror: {1}");
                CalculateRollupFieldResponse response = (CalculateRollupFieldResponse)service.Execute(request);
                tracingService.Trace("followingerror: {2}");
                context.OutputParameters["san_ResponseValue"] = "New Rollup field updated successfully!!!";
                tracingService.Trace("followingerror: {3}");
            }
            catch (Exception ex)
            {
                tracingService.Trace("followingerror: {4}");
                throw new InvalidPluginExecutionException("Error occured", ex);
            }
        }
    }
}
