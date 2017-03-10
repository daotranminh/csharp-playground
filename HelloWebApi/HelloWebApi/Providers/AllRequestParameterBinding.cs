using HelloWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;
using System.Web.Http.ModelBinding;

namespace HelloWebApi.Providers
{
    public class AllRequestParameterBinding : HttpParameterBinding
    {
        private HttpParameterBinding modelBinding = null;
        private HttpParameterBinding formatterBinding = null;

        public AllRequestParameterBinding(HttpParameterDescriptor descriptor)
            : base(descriptor)
        {
            modelBinding = new ModelBinderAttribute().GetBinding(descriptor);
            formatterBinding = new FromBodyAttribute().GetBinding(descriptor);
        }

        public override async Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider,
                                                       HttpActionContext context,
                                                       CancellationToken cancellationToken)
        {
            await formatterBinding.ExecuteBindingAsync(metadataProvider, context, cancellationToken);
            var employee = GetValue(context) as Employee;

            await modelBinding.ExecuteBindingAsync(metadataProvider, context, cancellationToken);
            var employeeFromUri = GetValue(context) as Employee;

            employee = Merge(employee, employeeFromUri);

            SetValue(context, employee);
        }

        private Employee Merge(Employee @base, Employee @new)
        {
            Type employeeType = typeof(Employee);

            foreach (var property in employeeType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                object baseValue = property.GetValue(@base, null);
                object newValue = property.GetValue(@new, null);

                object defaultValue = property.PropertyType.IsValueType ?
                                        Activator.CreateInstance(property.PropertyType) : null;

                if (baseValue == null || baseValue.Equals(defaultValue))
                    property.SetValue(@base, newValue);
            }

            return @base;
        }
    }
}